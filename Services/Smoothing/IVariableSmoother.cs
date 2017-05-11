using DataModel.Models.SurfaceModels;

namespace Services.Smoothing
{
    public interface IVariableSmoother
    {
        SurfaceVariable SmoothVariable(SurfaceVariable variable);
    }
}