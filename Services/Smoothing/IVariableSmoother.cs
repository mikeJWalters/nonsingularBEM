using DataModel.Models.SurfaceModels;

namespace Services.Smoothing
{
    public interface IVariableSmoother
    {
        double[] SmoothEvenVariable(double[] values);
        double[] SmoothOddVariable(double[] values);
    }
}