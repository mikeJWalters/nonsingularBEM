using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataModel.Models.Splines;
using DataModel.Models.SurfaceModels;
using Services.Splines.Natural;
using Services.Splines.Clamped;

namespace Services.Splines
{
    public class SplineService : ISplineService
    {
        private readonly ISplineCalculator _quinticNaturalCalculator;
        private readonly ISplineCalculator _quinticClampedCalculator;
        private readonly ISplineCalculator _quinticNaturalArclengthCalculator;
        private readonly ISplineCalculator _quinticClampedArclengthCalculator;

        public SplineService(ISplineCalculator quinticNaturalCalculator, ISplineCalculator quinticClampedCalculator, 
            ISplineCalculator quinticNaturalArclengthCalculator, ISplineCalculator quinticClampedArclengthCalculator)
        {
            _quinticNaturalCalculator = quinticNaturalCalculator;
            _quinticClampedCalculator = quinticClampedCalculator;
            _quinticNaturalArclengthCalculator = quinticNaturalArclengthCalculator;
            _quinticClampedArclengthCalculator = quinticClampedArclengthCalculator;
        }

        public SplineValues CalculateQuinticClampedArclengthlValues(SurfaceVariable surfaceVariable)
        {
            return _quinticClampedArclengthCalculator.CalculateCoefficients(surfaceVariable);
        }

        public SplineValues CalculateQuinticClampedValues(SurfaceVariable surfaceVariable)
        {
            return _quinticClampedCalculator.CalculateCoefficients(surfaceVariable);
        }

        public SplineValues CalculateQuinticNaturalArclengthValues(SurfaceVariable surfaceVariable)
        {
            return _quinticNaturalArclengthCalculator.CalculateCoefficients(surfaceVariable);
        }

        public SplineValues CalculateQuinticNaturalValues(SurfaceVariable surfaceVariable)
        {
            return _quinticNaturalCalculator.CalculateCoefficients(surfaceVariable);
        }
    }
}