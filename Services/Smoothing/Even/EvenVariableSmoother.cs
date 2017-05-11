using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Services.Smoothing.Even
{
    public class EvenVariableSmoother : IEvenVariableSmoother
    {
        public double CalculateSmoothedFirstNode(double[] values)
        {
            return (-values[2] + 4*values[1] + 10*values[0] + 4*values[1] - values[2])/16;
        }

        public double CalculateSmoothedSecondNode(double[] values)
        {
            return (-values[1] + 4 * values[0] + 10 * values[1] + 4 * values[2] - values[3]) / 16;
        }

        public double CalculateSmoothedPenultimateNode(double[] values)
        {
            return (-values[values.Length - 4] + 4*values[values.Length - 3] + 10*values[values.Length - 2] +
                    4*values[values.Length - 1] - values[values.Length - 2])/16;
        }

        public double CalculateSmoothedFinalNode(double[] values)
        {
            return (-values[values.Length - 3] + 4*values[values.Length - 2] + 10*values[values.Length - 1] +
                    4*values[values.Length - 2] - values[values.Length - 3])/16;
        }
    }
}