using DataModel.Models.SurfaceModels;
using Services.Splines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Services.Arclength
{
    public class ArclengthCalculator : IArclengthCalculator
    {
        private readonly ISplineService _splineService;

        public ArclengthCalculator(ISplineService splineService)
        {
            _splineService = splineService;
        }

        public SurfaceVariable CalculateArclength(BubbleSurface bubbleSurface)
        {
            var radialSplines = _splineService.CalculateQuinticNaturalValues(bubbleSurface.RadialNodePositions);
            var verticalSplines = _splineService.CalculateQuinticClampedValues(bubbleSurface.VerticalNodePositions);

            return null;
        }

    }
}