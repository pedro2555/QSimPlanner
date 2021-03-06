const http = require('http')
const fs = require('fs')
const nats = require('./tracks/nats')
const util = require('./util')
const path = require('path')
const mkdirp = require('mkdirp')
const express = require('express')
const bodyParser = require('body-parser')
const SyncFileWriter = require('./sync-file-writer').SyncFileWriter
const filePath = path.join(__dirname, 'log.txt')
const savedDirectory = path.join(__dirname, 'saved/nats')
const AntiSpamList = require('./anti-spam-list').AntiSpamList

let westXml = ''
let eastXml = ''
let lastWestObj = { Message: '' }
let lastEastObj = { Message: '' }
let lastWestDate = 0
let lastEastDate = 0
let unloggedErrors = ''

let errorReportWriter = new SyncFileWriter(
    path.join(__dirname, 'error-report'), 'error-report.txt')

let userList = new AntiSpamList()
let maxRequestBodySize = 100 * 1000

const reqHandler = {
    'nats': {
        'Eastbound.xml': () => eastXml,
        'Westbound.xml': () => westXml,
    },
    'err': () => unloggedErrors === '' ? 'No unlogged error.' : unloggedErrors
}

function setReqHandler(app, parentPath, obj) {
    Object.keys(obj).forEach(k => {
        let val = obj[k]
        if (typeof val === 'function') {
            app.get(parentPath + '/:id', (req, res) => {
                handleRequest(obj, req, res)
            })
        } else {
            // Is an object
            setReqHandler(app, parentPath + '/' + k, val)
        }
    })
}

function handleRequest(obj, request, response) {
    let resGetter = obj[request.params.id]

    if (resGetter !== undefined) {
        response.end(resGetter())
    } else {
        response.statusCode = 404
        response.end('404 Not found')
    }
}

/**
 * @param {(err) => void} callback 
 */
function updateXmls(callback) {
    nats.downloadHtml((err, html) => {
        if (err) {
            callback(err)
        } else {
            updateEastXml(html, callback)
            updateWestXml(html, callback)
        }
    })
}

function xmlFileName(lastUpdated) {
    return util.sanitizeFilename(lastUpdated.match(/\d.+/)[0])
}

function saveXml(subDirectory, lastUpdated, xmlStr, callback) {
    let dir = path.join(savedDirectory, subDirectory)
    let p = path.join(dir, xmlFileName(lastUpdated) + '.txt')
    mkdirp(dir, e => {
        if (!e) {
            fs.writeFile(p, xmlStr, callback)
        } else {
            callback(e)
        }
    })
}

/**
 * @param {string} html
 * @param {Error => void}
 */
function updateEastXml(html, callback) {
    try {
        let [success, newXml] = nats.getEastboundTracks(html)

        if (success) {
            let date = util.parseDate(newXml.LastUpdated)
            if (date > lastEastDate && lastEastObj.Message !== newXml.Message) {
                let xmlStr = util.toXml(util.withoutInvalidXmlCharObj(newXml))
                eastXml = xmlStr
                lastEastObj = newXml
                lastEastDate = date
                saveXml('east', newXml.LastUpdated, xmlStr, callback)
                log('Eastbound updated.')
            } else {
                log('No change in eastbound.')
            }
        } else {
            log('Cannot find eastbound part in html.')
        }

        callback(null)
    } catch (err) {
        callback(err)
    }
}

/**
 * @param {string} html
 * @param {Error => void}
 */
function updateWestXml(html, callback) {
    try {
        let [success, newXml] = nats.getWestboundTracks(html)

        if (success) {
            let date = util.parseDate(newXml.LastUpdated)
            if (date > lastWestDate && lastWestObj.Message !== newXml.Message) {
                let xmlStr = util.toXml(util.withoutInvalidXmlCharObj(newXml))
                westXml = xmlStr
                lastWestObj = newXml
                lastWestDate = date
                saveXml('west', newXml.LastUpdated, xmlStr, callback)
                log('Westbound updated.')
            } else {
                log('No change in westbound.')
            }
        } else {
            log('Cannot find westbound part in html.')
        }

        callback(null)
    } catch (err) {
        callback(err)
    }
}

/**
 * Log the message with current time stamp.
 * @param {string} msg 
 */
function log(msg) {
    let data = new Date().toISOString() + '   ' + msg + '\n'
    fs.appendFile(filePath, data, err => {
        if (err) {
            unloggedErrors += data + '\n\n' + err.stack + '\n\n'
        }
    })
}

// Script starts here.

// Update xmls and schedule future tasks.
util.repeat(() => updateXmls(err => {
    if (err) {
        log(err.stack)
    }
}), 5 * 60 * 1000) // Update every 5 min.

let app = express()

app.use(bodyParser.json())
app.use(bodyParser.urlencoded({ extended: true }))

setReqHandler(app, '', reqHandler)

app.post('/error-report', (req, res) => {
    let ip = req.ip
    
    if (!userList.decrementToken(ip) && 
        req.body.toString().length <= maxRequestBodySize) {
        errorReportWriter.add(JSON.stringify({
            ip: req.ip,
            time: new Date(Date.now()),
            text: req.body
        }) + '\n')
    }

    res.send("OK")
})

let server = app.listen(8081, '127.0.0.1', () => {
    console.log('server started')
    log('server started')
})

exports.log = log
