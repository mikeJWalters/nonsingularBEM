using System;

namespace Services.Derivatives
{
    public class CurvatureCalculator : DerivativeCalculator, ICurvatureCalculator
    {
        public double[] CalculateCurvatures(DataModel.Models.Derivatives.Derivatives derivatives)
        {
            var curvatures = new double[derivatives.RadialDerivative.Length];
            for (var i = 0; i < curvatures.Length; i++)
            {
                curvatures[i] = CalculateCurvature(derivatives, i);
            }

            return curvatures;
        }

        private double CalculateCurvature(DataModel.Models.Derivatives.Derivatives derivatives, int i)
        {
            var jacobian = Jacobian(derivatives, i);
            var numerator = (derivatives.RadialDerivative[i]*derivatives.VerticalSecondDerivative[i] -
                             derivatives.RadialSecondDerivative[i]*derivatives.VerticalDerivative[i]);

            return numerator/Math.Pow(jacobian, 1.5);
        }
    }
}