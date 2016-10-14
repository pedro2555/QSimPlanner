﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QSP.RouteFinding.Routes;

namespace QSP.RouteFinding.RouteAnalyzers
{

    // This class is immutable.
    public class RouteSegment
    {
        public bool IsAuto { get; private set; }
        public bool IsRand { get; private set; }
        public RouteString RouteString { get; private set; }

        public static RouteSegment Auto()
        {
            return new RouteSegment(true, false, null);
        }

        public static RouteSegment Rand()
        {
            return new RouteSegment(false, true, null);
        }

        public RouteSegment(RouteString RouteString)
            : this(false, false, RouteString)
        { }

        private RouteSegment(bool IsAuto, bool IsRand,
            RouteString RouteString)
        {
            this.IsAuto = IsAuto;
            this.IsRand = IsRand;
            this.RouteString = RouteString;
        }
    }
}
