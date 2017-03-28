using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataModel.Models.InitialConditions
{
    public class BubbleInitialConditions
    {
        public double Radius { get; set; }
        public double InitialBubblePotential { get; set; }
        public double InitialHeight { get; set; }
        public int StrengthParameter { get; set; }
        public int NumberOfNodes { get; set; }
        public double SurfaceTension { get; set; }
    }
}