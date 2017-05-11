using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataModel.Models.SurfaceModels
{
    public class SurfaceArclength
    {
        public double[] Values { get; set; }
        public readonly int NumberOfNodes;
        public double SegmentLength => Values.Last() / NumberOfNodes;

        public SurfaceArclength(int numberOfNodes)
        {
            NumberOfNodes = numberOfNodes;
            Values = new double[numberOfNodes];
        }
    }
}