using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataModel.Models.SurfaceModels
{
    public class SurfaceVariable
    {
        public double[] Values { get; set; }
        public double[] ArclengthDerivatives { get; set; }
        public double[] NormalDerivatives { get; set; }
        public int NumberOfNodes => Values.Count();
        public int MatrixSize => NumberOfNodes - 1;

        public SurfaceVariable(int numberOfNodes)
        {
            Values = new double[numberOfNodes];
            ArclengthDerivatives = new double[numberOfNodes];
            NormalDerivatives = new double[numberOfNodes];
        }
    }
}