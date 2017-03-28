using MathNet.Numerics.LinearAlgebra.Double;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.Matrices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonSingularBEM.Tests.Services.Matrices
{
    [TestClass]
    public class MatrixOperatorTests
    {
        private MatrixOperator _operator;
        private int _matrixSize = 10;
        private DenseMatrix _firstMatrix;
        private DenseMatrix _secondMatrix;
        private DenseMatrix _thirdMatrix;
        private List<DenseMatrix> _matrices;
        private DenseVector _vector;
        private const double _threshold = 0.000001; 

        [TestInitialize]
        public void Initialise()
        {
            _operator = new MatrixOperator();
            _firstMatrix = new DenseMatrix(_matrixSize, _matrixSize);
            _secondMatrix = new DenseMatrix(_matrixSize, _matrixSize);
            _thirdMatrix = new DenseMatrix(_matrixSize, _matrixSize);
            _vector = new DenseVector(_matrixSize);

            for (var i = 0; i < _matrixSize; i++)
            {
                for (var j = 0; j < _matrixSize; j++)
                {
                    _firstMatrix[i, j] = 1;
                    _secondMatrix[i, j] = 2;
                    _thirdMatrix[i, j] = 3;
                }
                _vector[i] = 1;
            }
            _matrices = new List<DenseMatrix> { _firstMatrix, _secondMatrix, _thirdMatrix };            
        }

        [TestMethod]
        public void SolveSystemMatrixRightHandSide_SolvesEquation()
        {
            var result = _operator.SolveSystemMatrixRightHandSide(_firstMatrix, _secondMatrix);
            var recreatedSecondMatrix = _operator.MultiplyMatrices(_firstMatrix, (DenseMatrix)result);
            for (var i = 0; i < _matrixSize; i++)
            {
                for (var j = 0; j < _matrixSize; j++)
                {
                    var differenceInValue = Math.Abs(_secondMatrix[i, j] - recreatedSecondMatrix[i, j]);
                    Assert.IsTrue(differenceInValue < _threshold);
                }
            }     
        }

        [TestMethod]
        public void SolveSystemVectorRightHandSide_SolvesEquation()
        {
            var result = _operator.SolveSystemVectorRightHandSide(_firstMatrix, _vector);
            var recreatedSecondVector = _operator.MultiplyMatrixAndVector(_firstMatrix, (DenseVector)result);
            for (var i = 0; i < _matrixSize; i++)
            {
                var differenceInValue = Math.Abs(_vector[i] - recreatedSecondVector[i]);
                Assert.IsTrue(differenceInValue < _threshold);
            }
        }

        [TestMethod]
        public void AddMatrices_AddsAllEntries()
        {
            var result = _operator.AddMatrices(_matrices);

            for (var i = 0; i < _matrixSize; i++)
            {
                for (var j = 0; j < _matrixSize; j++)
                {
                    var expectedValue = _firstMatrix[i, j] + _secondMatrix[i, j] + _thirdMatrix[i, j];
                    Assert.AreEqual(result[i, j], expectedValue);
                }
            }
        }

        [TestMethod]
        public void MultiplyMatrix_TwoMatrices()
        {
            var matrices = new List<DenseMatrix> { _firstMatrix, _secondMatrix };
            var result = _operator.MultiplyMatrices(_firstMatrix, _secondMatrix);

            for (var i = 0; i < _matrixSize; i++)
            {
                for (var j = 0; j < _matrixSize; j++)
                {
                    var expectedValue = _firstMatrix.Row(i) * _secondMatrix.Column(j);
                    Assert.AreEqual(expectedValue, result[i, j]);
                }
            }
        }

        [TestMethod]
        public void MultiplyMatrix_ThreeMatrices()
        {
            var result = _operator.MultiplyMatrices(_matrices);

            for (var i = 0; i < _matrixSize; i++)
            {
                for (var j = 0; j < _matrixSize; j++)
                {
                    var expectedValue = _firstMatrix.Row(i) * _secondMatrix.Column(j) * _thirdMatrix.Values[0] * _thirdMatrix.RowCount;
                    Assert.AreEqual(expectedValue, result[i, j]);
                }
            }
        }

        [TestMethod]
        public void MultiplyMatrixAndVector_MultipliesCorectly()
        {
            var result = _operator.MultiplyMatrixAndVector(_firstMatrix, _vector);
            var expectedValue = _firstMatrix.Row(0) * _vector;

            for (var i = 0; i < _matrixSize; i++)
            {
                Assert.AreEqual(expectedValue, result[i]);
            }
        }
    }
}
