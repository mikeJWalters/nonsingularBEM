using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataModel.Models.Derivatives
{
    public class Derivatives
    {
        public double[] RadialDerivative { get; set; }
        public double[] RadialSecondDerivative { get; set; }
        public double[] VerticalDerivative { get; set; }
        public double[] VerticalSecondDerivative { get; set; }

        public Derivatives(int numberOfNodes)
        {
            RadialDerivative = new double[numberOfNodes];
            RadialSecondDerivative = new double[numberOfNodes];
            VerticalDerivative = new double[numberOfNodes];
            VerticalSecondDerivative = new double[numberOfNodes];
        }
    }
}