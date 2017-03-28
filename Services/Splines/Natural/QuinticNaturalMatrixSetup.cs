using DataModel.Models.SurfaceModels;
using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Services.Splines.Natural
{
    public static class QuinticNaturalMatrixSetup
    {
        public const double DiagonalValueA = 8;
        public const double UpperDiagonalValueA = 2;
        public const double LowerDiagonalValueA = UpperDiagonalValueA;
        public const double DiagonalValueB = -2;
        public const double UpperDiagonalValueB = 1;
        public const double LowerDiagonalValueB = UpperDiagonalValueB;
        public const double DiagonalValueC = -16/15;
        public const double UpperDiagonalValueC = -7/15;
        public const double LowerDiagonalValueC = UpperDiagonalValueC;
        public const double DiagonalValueD = 4/3;
        public const double UpperDiagonalValueD = 1/3;
        public const double LowerDiagonalValueD = 1/3;

        public static DenseMatrix BuildMatrixA(int matrixSize)
        {
            return BuildTridiagonalMatrix(matrixSize, DiagonalValueA, UpperDiagonalValueA, LowerDiagonalValueA);
        }

        public static DenseMatrix BuildMatrixB(int matrixSize)
        {
            return BuildTridiagonalMatrix(matrixSize, DiagonalValueB, UpperDiagonalValueB, LowerDiagonalValueB);
        }

        public static DenseMatrix BuildMatrixC(int matrixSize)
        {
            return BuildTridiagonalMatrix(matrixSize, DiagonalValueC, UpperDiagonalValueC, LowerDiagonalValueC);
        }

        public static DenseMatrix BuildMatrixD(int matrixSize)
        {
            return BuildTridiagonalMatrix(matrixSize, DiagonalValueD, UpperDiagonalValueD, LowerDiagonalValueD);
        }

        public static Vector BuildVectorF(SurfaceVariable surfaceVariable)
        {
            var matrixSize = surfaceVariable.MatrixSize;
            var matrix = new DenseVector(matrixSize);
            for(var i = 0; i < matrixSize - 1; i++)
            {
                matrix[i] = surfaceVariable.Values[i + 2] - 2 * surfaceVariable.Values[i + 1] - surfaceVariable.Values[i];
            }

            return matrix;
        }

        public static DenseMatrix BuildTridiagonalMatrix(int matrixSize, double diagonalValue, double upperDiagonalValue, double lowerDiagonalValue)
        {
            var array = new double[matrixSize, matrixSize];
            for (var i = 0; i < matrixSize; i++)
            {
                array[i, i] = diagonalValue;
                if (i > 0) array[i - 1, i] = upperDiagonalValue;
                if (i < matrixSize - 1) array[i + 1, i] = lowerDiagonalValue;
            }

            return DenseMatrix.OfArray(array);
        }
    }
}