using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataModel.Models.InitialConditions
{
    public class FluidInitialConditions
    {
        public int Density { get; set; }
        public double Viscosity { get; set; }
        public double RelaxationTime { get; set; }
        public int PressureField { get; set; }
        public double MachNumber { get; set; }
    }
}