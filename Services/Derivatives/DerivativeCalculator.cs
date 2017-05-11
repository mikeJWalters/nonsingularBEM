using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataModel.Models.SurfaceModels;

namespace Services.Derivatives
{
    public class DerivativeCalculator : IDerivativeCalculator
    {
        private readonly ICurvatureCalculator _curvatureCalculator;

        public DerivativeCalculator(ICurvatureCalculator curvatureCalculator)
        {
            _curvatureCalculator = curvatureCalculator;
        }

        public BubbleSurface CalculateDerivatives(BubbleSurface surface)
        {
            var derivatives = new DataModel.Models.Derivatives.Derivatives(surface.NumberOfNodes);

            surface.Curvatuves = _curvatureCalculator.CalculateCurvatures(derivatives);

            // also need normal and tangential derivatives for r and z


            return surface;
        }

        protected double Jacobian(DataModel.Models.Derivatives.Derivatives derivatives, int i)
        {
            return Math.Pow(derivatives.RadialDerivative[i], 2) + Math.Pow(derivatives.VerticalDerivative[i], 2);
        }
    }
}