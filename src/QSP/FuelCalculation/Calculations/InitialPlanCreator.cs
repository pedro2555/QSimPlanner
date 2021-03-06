﻿using System;
using System.Collections.Generic;
using QSP.AviationTools.Heading;
using QSP.FuelCalculation.FuelData;
using QSP.FuelCalculation.Results.Nodes;
using QSP.LibraryExtension;
using QSP.MathTools;
using QSP.MathTools.Vectors;
using QSP.RouteFinding.Airports;
using QSP.RouteFinding.Data.Interfaces;
using QSP.RouteFinding.Routes;
using QSP.WindAloft;
using static QSP.AviationTools.Constants;
using static QSP.MathTools.Numbers;
using static System.Math;
using static QSP.FuelCalculation.Calculations.NextPlanNodeParameter;
using static QSP.AviationTools.SpeedConversion;

namespace QSP.FuelCalculation.Calculations
{
    // The units of variables used in this class is specified in 
    // VariableUnitStandard.txt.

    /// <summary>
    /// Creates the list of PlanNodes for the route. The route starts at origin
    /// at its optimal cruising altitude (instead of the airport elevation).
    /// Step climbs and descent to destination are included. 
    /// </summary>
    public class InitialPlanCreator
    {
        public static readonly double DeltaT = 0.5;
        public static readonly double AltDiffCriteria = 0.1;

        private readonly AirportManager airportList;
        private readonly ICrzAltProvider altProvider;
        private readonly IWindTableCollection windTable;
        private readonly Route route;
        private readonly FuelDataItem fuelData;
        private readonly double zfw;
        private readonly double landingFuel;
        private readonly double maxAlt;

        public InitialPlanCreator(
            AirportManager airportList,
            ICrzAltProvider altProvider,
            IWindTableCollection windTable,
            Route route,
            FuelDataItem fuelData,
            double zfw,
            double landingFuel,
            double maxAlt)
        {
            this.airportList = airportList;
            this.altProvider = altProvider;
            this.windTable = windTable;
            this.route = route;
            this.fuelData = fuelData;
            this.zfw = zfw;
            this.landingFuel = landingFuel;
            this.maxAlt = maxAlt;
        }

        public List<IPlanNode> Create()
        {
            // We compute the flight backwards - from destination to origin.

            var planNodes = new List<IPlanNode>();

            IPlanNode prevPlanNode = new PlanNode(
                route.Last.Value,
                windTable,
                route.Last,
                route.Last.Value.Waypoint,
                DestElevationFt(),
                zfw + landingFuel,
                landingFuel,
                0.0,
                fuelData.DescendKias);

            planNodes.Add(prevPlanNode);

            while (prevPlanNode.PrevRouteNode != null)
            {
                var nextPlanNodeInfo = GetNextPara(prevPlanNode);
                prevPlanNode = NextPlanNode(prevPlanNode, nextPlanNodeInfo);
                planNodes.Add(prevPlanNode);
            }

            planNodes.Reverse();
            return planNodes;
        }

        private NextPlanNodeParameter GetNextPara(IPlanNode node)
        {
            // Compute verical mode.
            double optCrzAlt = fuelData.OptCruiseAlt(node.GrossWt);
            double heading = HeadingCalculation.Heading(
                node.PrevWaypoint, node);
            double atcAllowedAlt = altProvider.ClosestAlt(
                node, heading, optCrzAlt);
            double targetAlt = Min(atcAllowedAlt, maxAlt);
            double altDiff = node.Alt - targetAlt;
            VerticalMode mode = GetMode(altDiff);

            // Time to next waypoint.
            double disToNextWpt = node.Distance(node.PrevWaypoint);
            double timeToNextWpt = disToNextWpt / node.Gs * 60.0;

            // Time to target altitude.
            // ClimbRate is positve for climbs and negative for descents.
            double climbGrad = ClimbGradient(node.GrossWt, mode);
            double climbRate = climbGrad * node.Ktas / 60.0 * NmFtRatio;
            bool isCruising = Abs(altDiff) < AltDiffCriteria;
            double timeToTargetAlt = isCruising ?
                double.PositiveInfinity :
                altDiff / climbRate;

            double[] times = { timeToNextWpt, DeltaT, timeToTargetAlt };
            int minIndex = times.MinIndex();
            double stepTime = times[minIndex];
            Type nodeType = minIndex == 0 ?
                typeof(RouteNode) :
                typeof(IntermediateNode);

            return new NextPlanNodeParameter(mode, nodeType, stepTime, climbRate);
        }

        private double ClimbGradient(double grossWt, VerticalMode mode)
        {
            switch (mode)
            {
                case VerticalMode.Climb:
                    return fuelData.ClimbGradient(grossWt);

                case VerticalMode.Cruise:
                    return 0.0;

                case VerticalMode.Descent:
                    return -fuelData.DescentGradient(grossWt);

                default:
                    throw new ArgumentException();
            }
        }

        private static VerticalMode GetMode(double altDiff)
        {
            if (altDiff > AltDiffCriteria)
            {
                return VerticalMode.Climb;
            }
            else if (altDiff < -AltDiffCriteria)
            {
                return VerticalMode.Descent;
            }
            else
            {
                return VerticalMode.Cruise;
            }
        }

        private double FuelFlow(double grossWt, VerticalMode mode)
        {
            switch (mode)
            {
                case VerticalMode.Climb:
                    return fuelData.ClimbFuelFlow(grossWt);

                case VerticalMode.Cruise:
                    return fuelData.CruiseFuelFlow(grossWt);

                case VerticalMode.Descent:
                    return fuelData.DescentFuelFlow(grossWt);

                default:
                    throw new ArgumentException();
            }
        }

        private double Kias(double grossWt, double alt, VerticalMode mode)
        {
            var cruiseKias = fuelData.CruiseKias(grossWt);
            if (mode == VerticalMode.Cruise) return cruiseKias;
            if (alt <= 10000.0) return 250.0;

            var optAlt = fuelData.OptCruiseAlt(grossWt);
            var optCruiseKtas = Ktas(cruiseKias, optAlt);
            var kias = mode == VerticalMode.Climb ?
                fuelData.ClimbKias : fuelData.DescendKias;
            var ktas = Ktas(kias, alt);
            return ktas > optCruiseKtas ? KtasToKcas(optCruiseKtas, alt) : kias;
        }

        private IPlanNode NextPlanNode(IPlanNode prev, NextPlanNodeParameter p)
        {
            var ff = FuelFlow(prev.GrossWt, p.ModeVertical);
            var stepFuel = p.StepTime * ff;
            double alt = prev.Alt - p.StepTime * p.ClimbRate;
            double grossWt = prev.GrossWt + stepFuel;
            double fuelOnBoard = prev.FuelOnBoard + stepFuel;
            double timeRemaining = prev.TimeRemaining + p.StepTime;
            double kias = Kias(prev.GrossWt, alt, p.ModeVertical);

            if (p.NodeType == typeof(RouteNode))
            {
                var current = prev.NextRouteNode.Previous;

                RouteNode val = current.Value;
                LinkedListNode<RouteNode> nextRouteNode = current;

                return new PlanNode(
                    val,
                    windTable,
                    nextRouteNode,
                    prev,
                    alt,
                    grossWt,
                    fuelOnBoard,
                    timeRemaining,
                    kias);
            }
            else
            {
                double stepDis = p.StepTime * prev.Gs / 60.0;
                var nodeCoord = GetV(prev, prev.PrevWaypoint, stepDis);
                var val = new IntermediateNode(nodeCoord);

                return new PlanNode(
                    val,
                    windTable,
                    prev.NextRouteNode,
                    prev,
                    alt,
                    grossWt,
                    fuelOnBoard,
                    timeRemaining,
                    kias);
            }
        }

        private double DestElevationFt()
        {
            var icao = route.Last.Value.Waypoint.ID.Substring(0, 4).ToUpper();
            return airportList[icao].Elevation;
        }

        private static ICoordinate GetV(ICoordinate p1, ICoordinate p2,
            double disNm)
        {
            return EarthGeometry.GetV(
                p1.ToVector3D(),
                p2.ToVector3D(),
                disNm / EarthRadiusNm).ToLatLon();
        }
    }
}