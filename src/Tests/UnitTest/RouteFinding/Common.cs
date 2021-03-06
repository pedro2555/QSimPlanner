﻿using QSP.LibraryExtension;
using QSP.RouteFinding.Airports;
using QSP.RouteFinding.AirwayStructure;
using QSP.RouteFinding.Containers;
using QSP.RouteFinding.Data.Interfaces;
using QSP.RouteFinding.Routes;
using System;
using System.Linq;

namespace UnitTest.RouteFinding
{
    public static class Common
    {
        // Format: 
        // Waypoint1, AirwayToNext, Distance,
        // Waypoint2, AirwayToNext, Distance,
        // ...
        // WaypointN
        //
        // Use a negative distance for automatic calculation
        public static Route GetRoute(params object[] para)
        {
            if (para.Length % 3 != 1)
            {
                throw new ArgumentException();
            }

            var route = new Route();
            var nodes = route.Nodes;
            nodes.AddLast(new RouteNode((Waypoint)para.Last(), null));

            for (int i = para.Length - 2; i >= 0; i -= 3)
            {
                var dis = (double)para[i];
                var wpt = (Waypoint)para[i - 2];

                if (dis < 0.0)
                {
                    var prev = nodes.First.Value.Waypoint;
                    dis = prev.Distance(wpt);
                }

                var n = new Neighbor((string)para[i - 1], dis);
                nodes.AddFirst(new RouteNode(wpt, n));
            }

            return route;
        }

        public static AirportManager GetAirportManager(params Airport[] items)
        {
            return new AirportManager(items);
        }

        public static Airport GetAirport(string icao, params RwyData[] rwys)
        {
            return new Airport(icao, "", 0.0, 0.0, 0, true, 0, 0, 0, rwys.ToList());
        }

        public static RwyData GetRwyData(string ident, double lat, double lon)
        {
            return new RwyData(ident, "", 0, 0, true, true, "", "", lat, lon, 0, 0.0, 0, "", 0);
        }

        public static void AddNeighbor(this WaypointList wptList, int index1,
            string airway, int index2)
        {
            wptList.AddNeighbor(index1, index2,
               new Neighbor(airway, wptList.Distance(index1, index2)));
        }

        public static WaypointList GetWptList(params Waypoint[] waypoints)
        {
            var wptList = new WaypointList();
            waypoints.ForEach(w => wptList.AddWaypoint(w));
            return wptList;
        }
    }
}
