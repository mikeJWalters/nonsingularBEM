using DataModel.Models.Splines;

namespace DataModel.Models.SurfaceModels
{
    public class BubbleSurface
    {
        public readonly int NumberOfNodes;
        public SurfaceVariable RadialNodePositions { get; set; }
        public SurfaceVariable VerticalNodePositions { get; set; }
        public SurfaceVariable Arclength { get; set; }
        public SurfaceVariable Potential { get; set; }
        public SurfaceVariable ExtraStress { get; set; }
        public SplineValues RadialSplines { get; set; }
        public SplineValues VerticalSplines { get; set; }
        
        public BubbleSurface(int numberOfNodes)
        {
            NumberOfNodes = numberOfNodes;
            RadialNodePositions = new SurfaceVariable(numberOfNodes);
            VerticalNodePositions = new SurfaceVariable(numberOfNodes);
            Arclength = new SurfaceVariable(numberOfNodes);
            Potential = new SurfaceVariable(numberOfNodes);
            RadialSplines = new SplineValues(numberOfNodes);
            VerticalSplines = new SplineValues(numberOfNodes);
        }
    }
}