using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataModel.Models.InitialConditions
{
    public class InitialConditions
    {
        public bool WallIsPresent { get; set; }
        public BubbleInitialConditions BubbleConditions { get; set; }
        public FluidInitialConditions FluidConditions { get; set; }
        public NumericalModellingConditions NumericalValues { get; set; }

        public InitialConditions()
        {
            BubbleConditions = new BubbleInitialConditions();
            FluidConditions = new FluidInitialConditions();
            NumericalValues = new NumericalModellingConditions();
        }
    }
}