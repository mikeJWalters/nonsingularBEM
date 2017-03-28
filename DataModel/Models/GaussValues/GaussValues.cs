using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataModel.Models.GaussValues
{
    public static class GaussValues
    {
        private const double GaussPoint1 = 0.97390652851717172008;
        private const double GaussPoint2 = 0.86506336668898451073;
        private const double GaussPoint3 = 0.67940956829902440623;
        private const double GaussPoint4 = 0.43339539412924719080;
        private const double GaussPoint5 = 0.14887433898163121089;
        private const double GaussPoint6 = -GaussPoint5;
        private const double GaussPoint7 = -GaussPoint4;
        private const double GaussPoint8 = -GaussPoint3;
        private const double GaussPoint9 = -GaussPoint2;
        private const double GaussPoint10 = -GaussPoint1;
        private const double GaussWeights1 = 0.06667134430868813759;
        private const double GaussWeights2 = 0.14945134915058059315;
        private const double GaussWeights3 = 0.21908636251598204400;
        private const double GaussWeights4 = 0.26926671930999635509;
        private const double GaussWeights5 = 0.29552422471475287017;
        private const double GaussWeights6 = -GaussWeights5;
        private const double GaussWeights7 = -GaussWeights4;
        private const double GaussWeights8 = -GaussWeights3;
        private const double GaussWeights9 = -GaussWeights2;
        private const double GaussWeights10 = -GaussWeights1;
        public static int GaussOrder => GaussPoints.Count();

        public static List<double> GaussPoints => new List<double>
        {
            GaussPoint1, GaussPoint2, GaussPoint3, GaussPoint4, GaussPoint5,
            GaussPoint6, GaussPoint7, GaussPoint8, GaussPoint9, GaussPoint10
        };

        public static List<double> GaussWeights => new List<double>
        {
            GaussWeights1, GaussWeights2, GaussWeights3, GaussWeights4, GaussWeights5,
            GaussWeights6, GaussWeights7, GaussWeights8, GaussWeights9, GaussWeights10
        };
    }
}