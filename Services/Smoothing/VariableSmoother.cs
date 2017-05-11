using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataModel.Models.SurfaceModels;
using Services.Smoothing.Even;
using Services.Smoothing.Odd;

namespace Services.Smoothing
{
    public class VariableSmoother : IVariableSmoother
    {
        private readonly IOddVariableSmoother _oddVariableSmoother;
        private readonly IEvenVariableSmoother _evenVariableSmoother;

        public VariableSmoother(IOddVariableSmoother oddVariableSmoother, IEvenVariableSmoother evenVariableSmoother)
        {
            _oddVariableSmoother = oddVariableSmoother;
            _evenVariableSmoother = evenVariableSmoother;
        }

        public double[] SmoothEvenVariable(double[] values)
        {
            var smoothedVariable = new double[values.Length];
            smoothedVariable[0] = _evenVariableSmoother.CalculateSmoothedFirstNode(values);
            smoothedVariable[1] = _evenVariableSmoother.CalculateSmoothedSecondNode(values);
            for (var i = 2; i < values.Length - 2; i++)
            {
                smoothedVariable[i] = CalculateInnerNodeSmoothedVariable(values, i);
            }
            smoothedVariable[values.Length - 2] = _evenVariableSmoother.CalculateSmoothedPenultimateNode(values);
            smoothedVariable[values.Length - 1] = _evenVariableSmoother.CalculateSmoothedFinalNode(values);

            return smoothedVariable;
        }

        public double[] SmoothOddVariable(double[] values)
        {
            var smoothedVariable = new double[values.Length];
            smoothedVariable[0] = 0;
            smoothedVariable[1] = _oddVariableSmoother.CalculateSecondSmoothedVariable(values);
            for (var i = 2; i < values.Length - 2; i++)
            {
                smoothedVariable[i] = CalculateInnerNodeSmoothedVariable(values, i);
            }
            smoothedVariable[values.Length - 2] = _oddVariableSmoother.CalculatePenultimateSmoothedVariable(values);
            smoothedVariable[values.Length - 1] = 0;

            return smoothedVariable;
        }

        private double CalculateInnerNodeSmoothedVariable(double[] values, int i)
        {
            return (-values[i - 2] + 4 * values[i - 1] + 10 * values[i] + 4 * values[i + 1] - values[i + 2]) / 16;
        }       
    }
}