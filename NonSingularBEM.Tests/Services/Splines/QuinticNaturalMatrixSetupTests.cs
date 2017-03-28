using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.Splines.Natural;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonSingularBEM.Tests.Services.Splines
{
    [TestClass]
    public class QuinticNaturalMatrixSetupTests
    {
        [TestMethod]
        public void QuinticNaturalMatrixSetup_BuildMatrixA_CreatesCorrectMatrix()
        {
            var matrixSize = 10;
            var matrix = QuinticNaturalMatrixSetup.BuildMatrixA(matrixSize);
            double expectedDiagonalEntry = QuinticNaturalMatrixSetup.DiagonalValueA;
            double expectedUpperDiagonalEntry = QuinticNaturalMatrixSetup.UpperDiagonalValueA;
            double expectedLowerDiagonalEntry = QuinticNaturalMatrixSetup.LowerDiagonalValueA;

            Assert.IsTrue(matrix.RowCount == matrixSize);
            Assert.IsTrue(matrix.ColumnCount == matrixSize);
            for(var i = 0; i < matrixSize; i++)
            {
                Assert.AreEqual(matrix[i, i], expectedDiagonalEntry);
                if(i > 0)
                {
                    Assert.AreEqual(matrix[i - 1, i], expectedLowerDiagonalEntry);
                }
                if(i < matrixSize - 1)
                {
                    Assert.AreEqual(matrix[i + 1, i], expectedUpperDiagonalEntry);
                }
            }
        }

        [TestMethod]
        public void QuinticNaturalMatrixSetup_BuildMatrixB_CreatesCorrectMatrix()
        {
            var matrixSize = 10;
            var matrix = QuinticNaturalMatrixSetup.BuildMatrixB(matrixSize);
            double expectedDiagonalEntry = QuinticNaturalMatrixSetup.DiagonalValueB;
            double expectedUpperDiagonalEntry = QuinticNaturalMatrixSetup.UpperDiagonalValueB;
            double expectedLowerDiagonalEntry = QuinticNaturalMatrixSetup.LowerDiagonalValueB;

            Assert.IsTrue(matrix.RowCount == matrixSize);
            Assert.IsTrue(matrix.ColumnCount == matrixSize);
            for (var i = 0; i < matrixSize; i++)
            {
                Assert.AreEqual(matrix[i, i], expectedDiagonalEntry);
                if (i > 0)
                {
                    Assert.AreEqual(matrix[i - 1, i], expectedLowerDiagonalEntry);
                }
                if (i < matrixSize - 1)
                {
                    Assert.AreEqual(matrix[i + 1, i], expectedUpperDiagonalEntry);
                }
            }
        }

        [TestMethod]
        public void QuinticNaturalMatrixSetup_BuildMatrixC_CreatesCorrectMatrix()
        {
            var matrixSize = 10;
            var matrix = QuinticNaturalMatrixSetup.BuildMatrixC(matrixSize);
            double expectedDiagonalEntry = QuinticNaturalMatrixSetup.DiagonalValueC;
            double expectedUpperDiagonalEntry = QuinticNaturalMatrixSetup.UpperDiagonalValueC;
            double expectedLowerDiagonalEntry = QuinticNaturalMatrixSetup.LowerDiagonalValueC;

            Assert.IsTrue(matrix.RowCount == matrixSize);
            Assert.IsTrue(matrix.ColumnCount == matrixSize);
            for (var i = 0; i < matrixSize; i++)
            {
                Assert.AreEqual(matrix[i, i], expectedDiagonalEntry);
                if (i > 0)
                {
                    Assert.AreEqual(matrix[i - 1, i], expectedLowerDiagonalEntry);
                }
                if (i < matrixSize - 1)
                {
                    Assert.AreEqual(matrix[i + 1, i], expectedUpperDiagonalEntry);
                }
            }
        }

        [TestMethod]
        public void QuinticNaturalMatrixSetup_BuildMatrixD_CreatesCorrectMatrix()
        {
            var matrixSize = 10;
            var matrix = QuinticNaturalMatrixSetup.BuildMatrixD(matrixSize);
            double expectedDiagonalEntry = QuinticNaturalMatrixSetup.DiagonalValueD;
            double expectedUpperDiagonalEntry = QuinticNaturalMatrixSetup.UpperDiagonalValueD;
            double expectedLowerDiagonalEntry = QuinticNaturalMatrixSetup.LowerDiagonalValueD;

            Assert.IsTrue(matrix.RowCount == matrixSize);
            Assert.IsTrue(matrix.ColumnCount == matrixSize);
            for (var i = 0; i < matrixSize; i++)
            {
                Assert.AreEqual(matrix[i, i], expectedDiagonalEntry);
                if (i > 0)
                {
                    Assert.AreEqual(matrix[i - 1, i], expectedLowerDiagonalEntry);
                }
                if (i < matrixSize - 1)
                {
                    Assert.AreEqual(matrix[i + 1, i], expectedUpperDiagonalEntry);
                }
            }
        }
    }
}
