using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataModel.Models.InitialConditions
{
    public class NumericalModellingConditions
    {
        public int NumberOfTrapezoidalNodes { get; set; }
        public int NumberOfSplinePoints { get; set; }
        public double MaximumTimeStep { get; set; }
    }
}