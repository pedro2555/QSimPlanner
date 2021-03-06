﻿using NUnit.Framework;
using QSP.RouteFinding.Containers;
using QSP.RouteFinding.Routes;
using System.Linq;

namespace UnitTest.RouteFinding.Routes
{
    [TestFixture]
    public class RouteExtensionsTest
    {
        private Route GetRoute1()
        {
            var route = new Route();

            route.AddLastWaypoint(new Waypoint("1", 0.0, 0.0));
            route.AddLastWaypoint(new Waypoint("2", 0.0, 0.0), "A");
            route.AddLastWaypoint(new Waypoint("3", 0.0, 0.0), "B");

            return route;
        }

        private Route GetRoute2()
        {
            var route = new Route();

            route.AddLastWaypoint(new Waypoint("2", 0.0, 0.0));
            route.AddLastWaypoint(new Waypoint("4", 0.0, 0.0), "C");
            route.AddLastWaypoint(new Waypoint("3", 0.0, 0.0), "D");

            return route;
        }

        [Test]
        public void InsertRouteTest()
        {
            var route = GetRoute1();

            route.Nodes.InsertRoute(GetRoute2().Nodes, "B");

            Assert.IsTrue(route.Nodes.Select(n => n.Waypoint.ID).SequenceEqual(
                new[] { "1", "2", "4", "3" }));

            Assert.IsTrue(route.Nodes.Select(n => n.Neighbor.Airway).Take(3).SequenceEqual(
                new[] { "A", "C", "D" }));
        }

        [Test]
        public void InsertRouteNoMatchShouldLeaveRouteUntouched()
        {
            var route = GetRoute1();

            route.Nodes.InsertRoute(GetRoute2().Nodes, "A");

            Assert.IsTrue(route.Equals(GetRoute1()));
        }        
    }
}
