using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MathNet.Numerics.LinearAlgebra.Double;
using System.Globalization;
using System.Reflection;
using MathNet.Numerics.LinearAlgebra.Double.Solvers;
using MathNet.Numerics.LinearAlgebra.Solvers;
using MathNet.Numerics.LinearAlgebra;

namespace Services.Matrices
{
    public class MatrixOperator : IMatrixOperator
    {
        private readonly CompositeSolver _solver;
        private readonly IterationCountStopCriterion<double> _iterationCountStopCriterion;
        private readonly ResidualStopCriterion<double> _residualStopCriterion;
        private readonly Iterator<double> _monitor;

        public MatrixOperator()
        {
            _solver = new CompositeSolver(SolverSetup<double>.LoadFromAssembly(Assembly.GetExecutingAssembly()));
            _iterationCountStopCriterion = new IterationCountStopCriterion<double>(1000);
            _residualStopCriterion = new ResidualStopCriterion<double>(1e-10);
            _monitor = new Iterator<double>(_iterationCountStopCriterion, _residualStopCriterion);
        }

        public Matrix<double> SolveSystemMatrixRightHandSide(DenseMatrix matrix, DenseMatrix rightHandSideMatrix)
        {            
            return matrix.SolveIterative(rightHandSideMatrix, _solver, _monitor);
        }

        public Vector<double> SolveSystemVectorRightHandSide(DenseMatrix matrix, DenseVector rightHandSideVector)
        {
            return matrix.SolveIterative(rightHandSideVector, _solver, _monitor);
        }

        public DenseMatrix AddMatrices(IEnumerable<DenseMatrix> matrices)
        {
            var matrixSize = matrices.First().RowCount;
            var result = new DenseMatrix(matrixSize);
            matrices.ToList().ForEach(matrix => result += matrix);

            return result;
        }

        public DenseMatrix MultiplyMatrices(IEnumerable<DenseMatrix> matrices)
        {
            var firstMatrix = matrices.FirstOrDefault();
            if (firstMatrix == null) throw new Exception("No matrices supplied to MultiplyMatrices method");

            var matrixSize = firstMatrix.RowCount;
            var result = firstMatrix;
            foreach(var matrix in matrices.Skip(1))
            {
                result = MultiplyMatrices(result, matrix);
            }

            return result;
        }

        public DenseMatrix MultiplyMatrices(DenseMatrix firstMatrix, DenseMatrix secondMatrix)
        {
            var matrixSize = firstMatrix.RowCount;
            return firstMatrix * secondMatrix;
        }

        public Vector<double> MultiplyMatrixAndVector(DenseMatrix matrix, DenseVector vector)
        {
            return matrix * vector;
        }
    }   
}