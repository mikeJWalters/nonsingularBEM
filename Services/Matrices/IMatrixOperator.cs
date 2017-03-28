using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Matrices
{
    public interface IMatrixOperator
    {
        Matrix<double> SolveSystemMatrixRightHandSide(DenseMatrix matrix, DenseMatrix rightHandSideMatrix);
        Vector<double> SolveSystemVectorRightHandSide(DenseMatrix matrix, DenseVector rightHandSideVector);
        DenseMatrix AddMatrices(IEnumerable<DenseMatrix> matrices);
        DenseMatrix MultiplyMatrices(IEnumerable<DenseMatrix> matrices);
    }
}
