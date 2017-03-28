using DataModel.Models.GaussValues;
using DataModel.Models.SurfaceModels;
using Services.Splines;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace Services.Volume
{
    public class VolumeCalculator : IVolumeCalculator
    {
        public double CalculateVolume(BubbleSurface surface)
        {
            double volume = 0;
            for(var i = 0; i < surface.NumberOfNodes - 1; i++)
            {
                volume += CalculateVolumeSegment(surface, i);
            }

            return volume;
        }

        public double CalculateVolumeSegment(BubbleSurface surface, int i)
        {
            var segmentEnd = surface.Arclength.Values[i + 1];
            var segmentStart = surface.Arclength.Values[i];
            
            double volumeSegment = 0;
            for (var j = 1; j < GaussValues.GaussOrder; j++)
            {
                volumeSegment += CalculateGaussSegment(surface, i, segmentStart, segmentEnd);
            }

            return volumeSegment;
        }

        public double CalculateGaussSegment(BubbleSurface surface, int i, double segmentStart, double segmentEnd)
        {
            var segmentLength = segmentEnd - segmentStart;
            var segment = (segmentLength * GaussValues.GaussPoints[i] + segmentEnd + segmentStart) / 2;
            var midPoint = segment - segmentStart;
            var radialValue = CalculateRadialValue(surface, i, midPoint);
            var verticalDerivative = CalculateVerticalDerivative(surface, i, midPoint);
            return Math.PI * (Math.Pow(radialValue, 2)) * verticalDerivative * GaussValues.GaussWeights[i];
        }

        public double CalculateRadialValue(BubbleSurface surface, int i, double midPoint)
        {
            return surface.RadialSplines.FirstDerivatives[i] * Math.Pow(midPoint, 5)
                    + surface.RadialSplines.SecondDerivatives[i] * Math.Pow(midPoint, 4)
                    + surface.RadialSplines.ThirdDerivatives[i] * Math.Pow(midPoint, 3)
                    + surface.RadialSplines.FourthDerivatives[i] * Math.Pow(midPoint, 2)
                    + surface.RadialSplines.FifthDerivatives[i] * midPoint + surface.RadialNodePositions.Values[i];
        }

        public double CalculateVerticalDerivative(BubbleSurface surface, int i, double midPoint)
        {
            return 5 * surface.VerticalSplines.FirstDerivatives[i] * Math.Pow(midPoint, 4)
                    + 4 * surface.VerticalSplines.SecondDerivatives[i] * Math.Pow(midPoint, 3)
                    + 3 * surface.VerticalSplines.ThirdDerivatives[i] * Math.Pow(midPoint, 2)
                    + 2 * surface.VerticalSplines.FourthDerivatives[i] * midPoint
                    + surface.VerticalSplines.FifthDerivatives[i];
        }
    }
}