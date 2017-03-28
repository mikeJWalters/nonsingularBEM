using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MathNet.Numerics.LinearAlgebra.Double;
using Services.Matrices;
using MathNet.Numerics.LinearAlgebra;
using DataModel.Models.SurfaceModels;
using DataModel.Models.Splines;

namespace Services.Splines.Natural
{
    public class QuinticNaturalCalculator : ISplineCalculator
    {
        public IMatrixOperator _matrixOperator;

        public QuinticNaturalCalculator(IMatrixOperator matrixOperator)
        {
            _matrixOperator = matrixOperator;
        }

        public SplineValues CalculateCoefficients(SurfaceVariable surfaceVariable)
        {
            var matrixSize = surfaceVariable.MatrixSize;
            var matrixE = SolveQuinticBDMatrix(matrixSize);
            var summedMatrices = SumMatrices(matrixSize, matrixE);
            var secondDerivatives = SolveQuinticCEDFMatrixEquation(surfaceVariable, summedMatrices);
            var fourthDerivatives = CalculateFourthDerivatives(matrixE, secondDerivatives);

            return BuildCoefficients(surfaceVariable, secondDerivatives, fourthDerivatives);
        }

        private Matrix<double> SolveQuinticBDMatrix(int matrixSize)
        {
            var matrixA = QuinticNaturalMatrixSetup.BuildMatrixA(matrixSize);
            var matrixB = QuinticNaturalMatrixSetup.BuildMatrixB(matrixSize);

            return _matrixOperator.SolveSystemMatrixRightHandSide(matrixA, matrixB);
        }

        private Matrix<double> SumMatrices(int matrixSize, Matrix<double> matrixE)
        {
            var matrixC = QuinticNaturalMatrixSetup.BuildMatrixC(matrixSize);
            var matrixD = QuinticNaturalMatrixSetup.BuildMatrixD(matrixSize);
            var denseMatrixE = (DenseMatrix)matrixE;

            return _matrixOperator.AddMatrices(new List<DenseMatrix> { matrixC, denseMatrixE, matrixD });
        }

        private Vector<double> SolveQuinticCEDFMatrixEquation(SurfaceVariable surfaceVariable, Matrix<double> summedMatrices)
        {
            var vectorF = QuinticNaturalMatrixSetup.BuildVectorF(surfaceVariable);
            return _matrixOperator.SolveSystemVectorRightHandSide((DenseMatrix)summedMatrices, (DenseVector)vectorF);
        }

        private Vector<double> CalculateFourthDerivatives(Matrix<double> matrix, Vector<double> secondDerivatives)
        {
            return _matrixOperator.SolveSystemVectorRightHandSide((DenseMatrix)matrix, (DenseVector)secondDerivatives);
        }

        public SplineValues BuildCoefficients(SurfaceVariable surfaceVariable, Vector<double> secondDerivatives, Vector<double> fourthDerivatives)
        {
            var numberOfNodes = surfaceVariable.NumberOfNodes;
            var splineValues = new SplineValues(numberOfNodes);
            
            for(var i = 1; i < numberOfNodes - 1; i++)
            {
                splineValues.SecondDerivatives[i] = secondDerivatives[i];
                splineValues.FourthDerivatives[i] = fourthDerivatives[i];
            }

            for (var i = 0; i < numberOfNodes - 1; i++)
            {
                splineValues.FirstDerivatives[i] = CalculateFirstDerivative(splineValues.SecondDerivatives, i);
                splineValues.ThirdDerivatives[i] = CalculateThirdDerivative(splineValues.SecondDerivatives, splineValues.FourthDerivatives, i);
                splineValues.FifthDerivatives[i] = CalculateFifthDerivative(surfaceVariable, splineValues, i);
            }

            return splineValues;
        }

        private double CalculateFirstDerivative(double[] secondDerivatives, int i)
        {
            return (secondDerivatives[i + 1] - secondDerivatives[i]) / 5;
        }

        private double CalculateThirdDerivative(double[] secondDerivatives, double[] fourthDerivatives, int i)
        {
            return (fourthDerivatives[i + 1] - fourthDerivatives[i]) / 3 - 2 * (secondDerivatives[i + 1] + 2 * secondDerivatives[i]) / 3;
        }

        private double CalculateFifthDerivative(SurfaceVariable surfaceVariable, SplineValues splineValues, int i)
        {
            return surfaceVariable.Values[i + 1] - surfaceVariable.Values[i] -
                    (splineValues.FourthDerivatives[i + 1] + 2 * splineValues.FourthDerivatives[i]) / 3 +
                    (7 * splineValues.SecondDerivatives[i + 1] + 8 * splineValues.SecondDerivatives[i]) / 5;
        }
    }
}