using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataModel.Models.SurfaceModels;

namespace Services.Smoothing
{
    public class SurfaceSmoother : ISurfaceSmoother
    {
        private readonly IVariableSmoother _variableSmoother;

        public SurfaceSmoother(IVariableSmoother variableSmoother)
        {
            _variableSmoother = variableSmoother;
        }

        public BubbleSurface SmoothSurfaceVariables(BubbleSurface surface)
        {
            surface.RadialNodePositions.Values = _variableSmoother.SmoothOddVariable(surface.RadialNodePositions.Values);
            surface.VerticalNodePositions.Values = _variableSmoother.SmoothEvenVariable(surface.VerticalNodePositions.Values);
            surface.Potential.Values = _variableSmoother.SmoothEvenVariable(surface.Potential.Values);
            surface.ExtraStress.Values = _variableSmoother.SmoothEvenVariable(surface.ExtraStress.Values);

            return surface;
        }
    }
}