using System;
using QSP.AviationTools;
using QSP.MathTools;

namespace QSP.WindAloft
{

    public class AvgWindCalculator
    {
        private Vector3D v1 = new Vector3D();
        private Vector3D v2 = new Vector3D();
        private WxFileLoader windData;
        private double FL;
        private int tas;
        private double lat1;
        private double lon1;
        private double lat2;
        private double lon2;

        public AvgWindCalculator(WxFileLoader item, int trueAirspd, double flightLevel)
        {
            windData = item;
            tas = trueAirspd;
            FL = flightLevel;

            SetPoint1(0, 0);
            SetPoint2(0, 0);
        }

        public void SetPoint1(double lat, double lon)
        {
            lat1 = lat;
            lon1 = lon;
            setV1();
        }

        public void SetPoint1(LatLon item)
        {
            lat1 = item.Lat;
            lon1 = item.Lon;
            setV1();
        }

        public void SetPoint2(double lat, double lon)
        {
            lat2 = lat;
            lon2 = lon;
            setV2();
        }

        public void SetPoint2(LatLon item)
        {
            lat2 = item.Lat;
            lon2 = item.Lon;
            setV2();
        }

        private void setV1()
        {
            v1 = MathTools.MathTools.LatLonToVector3D(lat1, lon1);
        }

        private void setV2()
        {
            v2 = MathTools.MathTools.LatLonToVector3D(lat2, lon2);
        }

        public double GetAvgWind(double seperation)
        {
            //lat/lon 1: "from" point
            //lat/lon 2: "to" point
            //seperation: calculate a point every () degrees
            //airspd: (of the aircraft)

            double delta_alpha = MathTools.MathTools.ToRadian(seperation);
            double T = 0;
            //total time required
            double r = 0;
            //total distance

            r = AviationConstants.RADIUS_EARTH_NM * Math.Acos(v1.InnerProductWith(v2));

            RealValuedFunction g = new RealValuedFunction(GetOneOverGS);

            T = g.Integrate(0, r, delta_alpha * AviationConstants.RADIUS_EARTH_NM);
            return r / T - tas;
        }

        private double GetOneOverGS(double r)
        {
            Vector3D v = Get_v(v1, v2, r / AviationConstants.RADIUS_EARTH_NM);
            return 1 / GetGS(v);
        }

        private Vector3D Get_v(Vector3D v1, Vector3D v2, double alpha)
        {
            Vector2D a1_a2 = new Vector2D();
            Matrix2by2 A = new Matrix2by2();
            A.a11 = 1;
            A.a22 = 1;
            A.a12 = v1.InnerProductWith(v2);
            A.a21 = v1.InnerProductWith(v2);

            double beta = Math.Acos(v1.InnerProductWith(v2));

            Vector2D b1_b2 = new Vector2D();
            b1_b2.x = Math.Cos(alpha);
            b1_b2.y = Math.Cos(beta - alpha);

            a1_a2 = A.InverseMatrix().MultiplyVector2D(b1_b2);

            Vector3D v = new Vector3D();
            v = v1.Multiply(a1_a2.x).Add(v2.Multiply(a1_a2.y));
            return v;
        }

        private double GetGS(Vector3D v)
        {
            double lat = MathTools.MathTools.ToDegree(v.phi);
            double lon = SetAngleLon(MathTools.MathTools.ToDegree(v.theta));
            Vector3D V_wind = GetWind(lat, lon);
            double V_g = 0;

            Vector3D w = Get_w(v, v1, v2);
            double gamma = Math.Acos((V_wind.Normalize()).InnerProductWith(w));
            double a = 1;
            double b = -2 * V_wind.r * Math.Cos(gamma);
            double c = V_wind.r * V_wind.r - tas * tas;
            V_g = ((-1) * b + Math.Sqrt(b * b - 4 * a * c)) / (2 * a);
            return V_g;
        }

        private double SetAngleLon(double a)
        {
            double b = a;
            while ((b < -180 || b > 180))
            {
                if (b < -180)
                {
                    b += 360;
                }
                else
                {
                    b -= 360;
                }
            }
            return b;
        }

        private Vector3D Get_w(Vector3D v, Vector3D v1, Vector3D v2)
        {
            Vector3D v3 = v1.CrossProductWith(v2);
            v3 = v3.Normalize();
            return v3.CrossProductWith(v);
        }

        private Vector3D GetWind(double lat, double lon)
        {
            //Given u-comp, V_u, and v-comp, V_v, then we have
            //V_wind=V_u(-sin(theta),cos(theta),0)+V_v(-sin(phi)cos(theta),-sin(phi)sin(theta),cos(phi))
            //lat=phi, lon=theta
            //u=lon,v=lat

            Vector3D WindVec = new Vector3D();
            double u_comp = 0;
            double v_comp = 0;

            Tuple<double, double> t = windData.GetWindUV(lat, lon, FL);

            u_comp = t.Item1;
            v_comp = t.Item2;

            var u1 = new Vector3D();
            var u2 = new Vector3D();
            u1.x = -1 * Math.Sin(MathTools.MathTools.ToRadian(lon));
            u1.y = Math.Cos(MathTools.MathTools.ToRadian(lon));
            u1.z = 0;

            u2.x = -1 * Math.Sin(MathTools.MathTools.ToRadian(lat)) * Math.Cos(MathTools.MathTools.ToRadian(lon));
            u2.y = -1 * Math.Sin(MathTools.MathTools.ToRadian(lat)) * Math.Sin(MathTools.MathTools.ToRadian(lon));
            u2.z = Math.Cos(MathTools.MathTools.ToRadian(lat));

            WindVec = ((u1.Multiply(u_comp)).Add(u2.Multiply(v_comp)));

            return WindVec;
        }

    }
}
