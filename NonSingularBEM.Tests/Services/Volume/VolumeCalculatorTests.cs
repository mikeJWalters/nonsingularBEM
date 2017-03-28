using DataModel.Models.SurfaceModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.Matrices;
using Services.Splines;
using Services.Splines.Natural;
using Services.Volume;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonSingularBEM.Tests.Services.Volume
{
    [TestClass]
    public class VolumeCalculatorTests
    {
        private readonly int NumberOfNodes = 10;
        private readonly double ErrorMargin = 0.000001;
        private BubbleSurface _surface;
        private ISplineCalculator _splineCalculator;
        private IVolumeCalculator _volumeCalculator;        

        [TestInitialize]
        public void Initalise()
        {
            _splineCalculator = new QuinticNaturalCalculator(new MatrixOperator());
            _surface = new BubbleSurface(NumberOfNodes);
            for(var i = 0; i < NumberOfNodes; i++)
            {
                _surface.RadialNodePositions.Values[i] = Math.Cos(Math.PI / 2 - i * Math.PI / (NumberOfNodes - 1));
                _surface.VerticalNodePositions.Values[i] = Math.Sin(Math.PI / 2 - i * Math.PI / (NumberOfNodes - 1));
            }
            _surface.RadialSplines = _splineCalculator.CalculateCoefficients(_surface.RadialNodePositions);
            _surface.VerticalSplines = _splineCalculator.CalculateCoefficients(_surface.VerticalNodePositions);
            _volumeCalculator = new VolumeCalculator();
        }

        [TestMethod]
        public void CalculateVolume_SphereTest()
        {
            var volume = _volumeCalculator.CalculateVolume(_surface);
            var sphereVolume = 4 * Math.PI / 3;
            var error = Math.Abs(volume - sphereVolume);

            Assert.IsTrue(error < ErrorMargin);
        }

        //[TestMethod]
        //public void CalculateGaussSegment()
        //{

        //}

        //[TestMethod]
        //public void CalculateRadialValue()
        //{

        //}

        //[TestMethod]
        //public void CalculateVerticalDerivative()
        //{

        //}
    }
}
