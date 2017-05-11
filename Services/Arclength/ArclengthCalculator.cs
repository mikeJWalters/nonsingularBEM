using DataModel.Models.Splines;
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
        private readonly ISegmentIntegralService _segmentIntegralService;
        private readonly double _errorLimit = Math.Pow(10, -15);
        private const int MaxIteratorCount = 5000;

        public ArclengthCalculator(ISplineService splineService, ISegmentIntegralService segmentIntegralService)
        {
            _splineService = splineService;
            _segmentIntegralService = segmentIntegralService;
        }

        public SurfaceArclength CalculateArclength(BubbleSurface bubbleSurface)
        {
            var radialSplines = _splineService.CalculateQuinticNaturalValues(bubbleSurface.RadialNodePositions);
            var verticalSplines = _splineService.CalculateQuinticClampedValues(bubbleSurface.VerticalNodePositions);
            var arclength = _segmentIntegralService.SegmentIntegrate(radialSplines, verticalSplines);

            return IterativeCalculateArclength(bubbleSurface, arclength, 0);
        }

        private SurfaceArclength IterativeCalculateArclength(BubbleSurface bubbleSurface, SurfaceArclength arclength, int iteratorCount)
        {
            ThrowErrorIfIteratorCountExceeded(iteratorCount);
            var parameterisedRadialSplines = _splineService.CalculateQuinticNaturalArclengthValues(bubbleSurface.RadialNodePositions);
            var parameterisedVerticalSplines = _splineService.CalculateQuinticClampedArclengthlValues(bubbleSurface.VerticalNodePositions);
            var parameterisedArclength = _segmentIntegralService.SegmentIntegrateArclength(parameterisedRadialSplines, parameterisedVerticalSplines, arclength);
            var error = CalculateError(arclength, parameterisedArclength);

            return error < _errorLimit
                ? parameterisedArclength
                : IterativeCalculateArclength(bubbleSurface, parameterisedArclength, iteratorCount++);
        }

        private void ThrowErrorIfIteratorCountExceeded(int iteratorCount)
        {
            if (iteratorCount > MaxIteratorCount)
            {
                throw new Exception("IterativeCalculateArclength stuck in loop.");
            }
        }

        private double CalculateError(SurfaceArclength arclength, SurfaceArclength parameterisedArclength)
        {
            var finalArclengthValue = arclength.Values.Last();
            var finalParameterisedArclengthValue = parameterisedArclength.Values.Last();

            return (finalParameterisedArclengthValue - finalArclengthValue) / finalArclengthValue;
        }

    }
}