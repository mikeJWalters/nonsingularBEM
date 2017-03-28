using System;
using MathNet.Numerics.LinearAlgebra.Double.Solvers;
using MathNet.Numerics.LinearAlgebra.Solvers;

namespace Services.Matrices
{
    public class UserBiCgStab : IIterativeSolverSetup<double>
    {
        /// <summary>
        /// Gets the type of the solver that will be created by this setup object.
        /// </summary>
        public Type SolverType
        {
            get { return null; }
        }

        /// <summary>
        /// Gets type of preconditioner, if any, that will be created by this setup object.
        /// </summary>
        public Type PreconditionerType
        {
            get { return null; }
        }

        /// <summary>
        /// Creates a fully functional iterative solver with the default settings
        /// given by this setup.
        /// </summary>
        /// <returns>A new <see cref="IIterativeSolver{T}"/>.</returns>
        public IIterativeSolver<double> CreateSolver()
        {
            return new BiCgStab();
        }

        public IPreconditioner<double> CreatePreconditioner()
        {
            return null;
        }

        /// <summary>
        /// Gets the relative speed of the solver.
        /// </summary>
        /// <value>Returns a value between 0 and 1, inclusive.</value>
        public double SolutionSpeed
        {
            get { return 0.99; }
        }

        /// <summary>
        /// Gets the relative reliability of the solver.
        /// </summary>
        /// <value>Returns a value between 0 and 1 inclusive.</value>
        public double Reliability
        {
            get { return 0.99; }
        }
    }
}