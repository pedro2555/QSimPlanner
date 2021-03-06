﻿using QSP.RouteFinding.Airports;
using QSP.RouteFinding.Tracks.Common.TDM.Parser;
using System.Collections.Generic;
using System.Linq;
using QSP.RouteFinding.Routes;

namespace QSP.RouteFinding.Tracks.Pacots.Eastbound
{
    public class EastboundParser
    {
        private AirportManager airportList;

        public EastboundParser(AirportManager airportList)
        {
            this.airportList = airportList;
        }

        public List<PacificTrack> Parse(PacotsMessage item)
        {
            return item.EastboundTracks
                .SelectMany(i => CreateEastboundTracks(i))
                .ToList();
        }

        private PacificTrack[] CreateEastboundTracks(string item)
        {
            var timeInfo = TrackValidPeriod.GetValidPeriod(item);
            var tracksStr = new Splitter(item).Split();
            var result = new PacificTrack[tracksStr.Count];

            for (int i = 0; i < result.Length; i++)
            {
                var trk = Interpreter.Parse(tracksStr[i]);
                var mainRoute = trk.FlexRoute.ToRouteString();

                var connectionRoutes = ConnectionRouteInterpreter.Convert(
                    mainRoute,
                    ConnectionRouteSeperator.Seperate(trk.ConnectionRoute),
                    airportList);

                result[i] = new PacificTrack(
                    PacotDirection.Eastbound,
                    trk.ID.ToString(),
                    timeInfo.Start,
                    timeInfo.End,
                    trk.Remark,
                    mainRoute,
                    connectionRoutes.RouteFrom,
                    connectionRoutes.RouteTo,
                    Constants.JapanLatlon,
                    Constants.USLatlon);
            }

            return result;
        }
    }
}
