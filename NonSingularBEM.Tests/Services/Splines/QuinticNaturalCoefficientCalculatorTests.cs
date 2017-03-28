using DataModel.Models.SurfaceModels;
using MathNet.Numerics.LinearAlgebra.Double;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.Matrices;
using Services.Splines.Natural;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonSingularBEM.Tests.Services.Splines
{
    [TestClass]
    public class QuinticNaturalCoefficientCalculatorTests
    {
        private MatrixOperator _operator;
        private QuinticNaturalCalculator _coefficientCalculator;
        private SurfaceVariable _surfaceVariable;
        private const int NumberOfNodes = 10;
        private DenseVector _secondDerivatives;
        private DenseVector _fourthDerivatives;

        [TestInitialize]
        public void Initialise()
        {
            _operator = new MatrixOperator();
            _coefficientCalculator = new QuinticNaturalCalculator(_operator);
            _surfaceVariable = BuildSurfaceVariable();
            _secondDerivatives = DenseVector.OfArray(new double[NumberOfNodes] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 });
            _fourthDerivatives = DenseVector.OfArray(new double[NumberOfNodes] { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2 });
        }

        private SurfaceVariable BuildSurfaceVariable()
        {
            var surfaceVariable = new SurfaceVariable(NumberOfNodes);
            surfaceVariable.Values = new List<double>
            {
                1,2,3,4,5,6,7,8,9,10
            }.ToArray();

            return surfaceVariable;
        }

        [TestMethod]
        public void BuildCoefficients_CorrectlyBuildsCoefficients()
        {
            var splineValues = _coefficientCalculator.BuildCoefficients(_surfaceVariable, _secondDerivatives, _fourthDerivatives);

            // second derivatives
            Assert.AreEqual(0, splineValues.SecondDerivatives.First());
            Assert.AreEqual(0, splineValues.SecondDerivatives.Last());
        }
    }
}
