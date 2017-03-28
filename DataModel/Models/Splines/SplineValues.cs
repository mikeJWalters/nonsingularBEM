using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataModel.Models.Splines
{
    public class SplineValues
    {
        public double[] Values { get; set; }
        public double[] FirstDerivatives { get; set; }
        public double[] SecondDerivatives { get; set; }
        public double[] ThirdDerivatives { get; set; }
        public double[] FourthDerivatives { get; set; }
        public double[] FifthDerivatives { get; set; }
        public readonly int NumberOfNodes;

        public SplineValues(int splineNodes)
        {
            Values = new double[splineNodes];
            FirstDerivatives = new double[splineNodes];
            SecondDerivatives = new double[splineNodes];
            ThirdDerivatives = new double[splineNodes];
            FourthDerivatives = new double[splineNodes];
            FifthDerivatives = new double[splineNodes];
            NumberOfNodes = splineNodes;
        }
    }
}