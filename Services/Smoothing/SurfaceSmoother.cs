using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataModel.Models.SurfaceModels;

namespace Services.Smoothing
{
    public class SurfaceSmoother : ISurfaceSmoother
    {
        private readonly IVariableSmoother _oddVariableSmoother;
        private readonly IVariableSmoother _evenVariableSmoother;

        public SurfaceSmoother(IVariableSmoother oddVariableSmoother, IVariableSmoother evenVariableSmoother)
        {
            _oddVariableSmoother = oddVariableSmoother;
            _evenVariableSmoother = evenVariableSmoother;
        }

        public BubbleSurface SmoothSurfaceVariables(BubbleSurface surface)
        {
            surface.RadialNodePositions = _oddVariableSmoother.SmoothVariable(surface.RadialNodePositions);
            surface.VerticalNodePositions = _evenVariableSmoother.SmoothVariable(surface.VerticalNodePositions);
            surface.Potential = _evenVariableSmoother.SmoothVariable(surface.Potential);
            surface.ExtraStress = _evenVariableSmoother.SmoothVariable(surface.ExtraStress);

            return surface;
        }
    }
}