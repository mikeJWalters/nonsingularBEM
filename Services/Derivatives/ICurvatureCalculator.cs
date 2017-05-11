namespace Services.Derivatives
{
    public interface ICurvatureCalculator
    {
        double[] CalculateCurvatures(DataModel.Models.Derivatives.Derivatives derivatives);
    }
}