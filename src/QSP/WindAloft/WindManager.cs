﻿using System.Threading.Tasks;
using System.IO;

namespace QSP.WindAloft
{
    public static class WindManager
    {
        public static readonly string DownloadFilePath =
            Path.Combine(Constants.WxFileDownloadDirectory, "wx.grib2");

        /// <summary>
        /// Download, convert and read the files into WindTableCollection.
        /// Can throw exception. 
        /// </summary>
        public static WindTableCollection LoadWind()
        {
            new GribDownloader().DownloadGribFile(DownloadFilePath);
            GribConverter.ConvertGrib();

            var handler = new WindFileHandler();
            var tables = handler.ImportAllTables();
            handler.TryDeleteCsvFiles();
            return tables;
        }

        // Can throw exception.
        public static async Task<WindTableCollection> LoadWindAsync()
        {
            return await Task.Factory.StartNew(LoadWind);
        }
    }
}
