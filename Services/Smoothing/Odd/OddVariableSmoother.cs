using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Services.Smoothing.Odd
{
    public class OddVariableSmoother : IOddVariableSmoother
    {
        public double CalculateSecondSmoothedVariable(double[] values)
        {
            return (11 * values[1] + 4 * values[0] + 4 * values[2] - values[3]) / 16;
        }

        public double CalculatePenultimateSmoothedVariable(double[] values)
        {
            return (-values[values.Length - 4] + 4 * values[values.Length - 3] +
                    11 * values[values.Length - 2] + 4 * values[values.Length - 1]) / 16;
        }
    }
}