using DataModel.Models.SurfaceModels;

namespace Services.Smoothing
{
    public interface ISurfaceSmoother
    {
        BubbleSurface SmoothSurfaceVariables(BubbleSurface surface);
    }
}