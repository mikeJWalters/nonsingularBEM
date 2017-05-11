using DataModel.Models.GaussValues;
using DataModel.Models.Splines;
using DataModel.Models.SurfaceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Services.Arclength
{
    public class SegmentIntegralService : ISegmentIntegralService
    {
        public SurfaceArclength SegmentIntegrate(SplineValues radialSplines, SplineValues verticalSplines)
        {
            var arclength = new SurfaceArclength(radialSplines.NumberOfNodes);
            for(var i = 0; i < radialSplines.NumberOfNodes; i++)
            {
                arclength.Values[i] = SingleSegmentIntegrate(radialSplines, verticalSplines, i);
            }
            return arclength;
        }

        public SurfaceArclength SegmentIntegrateArclength(SplineValues parameterisedRadialSplines, SplineValues parameterisedVerticalSplines, SurfaceArclength arclength)
        {
            var parameterisedArclength = new SurfaceArclength(parameterisedRadialSplines.NumberOfNodes);
            for (var i = 0; i < parameterisedRadialSplines.NumberOfNodes; i++)
            {
                var segmentLength = arclength.Values[i + 1] - arclength.Values[i];
                parameterisedArclength.Values[i] = SingleSegmentIntegrate(parameterisedRadialSplines, parameterisedVerticalSplines, i, segmentLength);
            }
            return parameterisedArclength;
        }

        private double SingleSegmentIntegrate(SplineValues radialSplines, SplineValues verticalSplines, int nodePosition)
        {
            return SingleSegmentIntegrate(radialSplines, verticalSplines, nodePosition, 1);
        }

        private double SingleSegmentIntegrate(SplineValues radialSplines, SplineValues verticalSplines, int nodePosition, double segmentLength)
        {
            double segmentValue = 0;
            for (var gaussCounter = 1; gaussCounter < GaussValues.GaussOrder; gaussCounter++)
            {
                var radialDerivative = CalculateSplineDerivative(radialSplines, nodePosition, gaussCounter);
                var verticalDerivative = CalculateSplineDerivative(verticalSplines, nodePosition, gaussCounter);
                var jacobian = Math.Pow(Math.Pow(radialDerivative, 2) + Math.Pow(verticalDerivative, 2), 0.5);
                segmentValue += jacobian * GaussValues.GaussWeights[gaussCounter] * 0.5 * segmentLength;
            }

            return segmentValue;
        }

        private double CalculateSplineDerivative(SplineValues splineValue, int nodePosition, int gaussCounter)
        {
            var eta = (GaussValues.GaussPoints[gaussCounter] + 1) / 2;
            return 5 * splineValue.FifthDerivatives[nodePosition] * Math.Pow(eta, 4) + 4 * splineValue.FourthDerivatives[nodePosition] * Math.Pow(eta, 3)
                + 3 * splineValue.ThirdDerivatives[nodePosition] * Math.Pow(eta, 2) + 2 * splineValue.SecondDerivatives[nodePosition] * eta + splineValue.FirstDerivatives[nodePosition];
        }
    }
}