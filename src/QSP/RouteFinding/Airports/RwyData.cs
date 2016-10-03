using QSP.RouteFinding.Data.Interfaces;

namespace QSP.RouteFinding.Airports
{
    public class RwyData : ICoordinate
    {
        public string RwyIdent { get; private set; }
        public string Heading { get; private set; }
        public int LengthFt { get; private set; }
        public int WidthFt { get; private set; }
        public bool HasIlsInfo { get; private set; }
        public bool IlsAvail { get; private set; }
        public string IlsFreq { get; private set; }
        public string IlsHeading { get; private set; }
        public double Lat { get; private set; }
        public double Lon { get; private set; }
        public int Elevation { get; private set; }
        public double GlideslopeAngle { get; private set; }
        public int ThresholdOverflyHeight { get; private set; }
        public string SurfaceType { get; private set; }
        public int RwyStatus { get; private set; }

        public RwyData(
            string RwyIdent,
            string Heading,
            int LengthFt,
            int WidthFt,
            bool HasIlsInfo,
            bool IlsAvail,
            string IlsFreq,
            string IlsHeading,
            double Lat,
            double Lon,
            int Elevation,
            double GlideslopeAngle,
            int ThresholdOverflyHeight,
            string SurfaceType,
            int RwyStatus)
        {
            this.RwyIdent = RwyIdent;
            this.Heading = Heading;
            this.LengthFt = LengthFt;
            this.WidthFt = WidthFt;
            this.HasIlsInfo = HasIlsInfo;
            this.IlsAvail = IlsAvail;
            this.IlsFreq = IlsFreq;
            this.IlsHeading = IlsHeading;
            this.Lat = Lat;
            this.Lon = Lon;
            this.Elevation = Elevation;
            this.GlideslopeAngle = GlideslopeAngle;
            this.ThresholdOverflyHeight = ThresholdOverflyHeight;
            this.SurfaceType = SurfaceType;
            this.RwyStatus = RwyStatus;
        }

        public RwyData(RwyData item)
        {
            RwyIdent = item.RwyIdent;
            Heading = item.Heading;
            LengthFt = item.LengthFt;
            WidthFt = item.WidthFt;
            IlsAvail = item.IlsAvail;
            IlsFreq = item.IlsFreq;
            IlsHeading = item.IlsHeading;
            Lat = item.Lat;
            Lon = item.Lon;
            Elevation = item.Elevation;
            GlideslopeAngle = item.GlideslopeAngle;
            ThresholdOverflyHeight = item.ThresholdOverflyHeight;
            SurfaceType = item.SurfaceType;
            RwyStatus = item.RwyStatus;
        }
    }
}
