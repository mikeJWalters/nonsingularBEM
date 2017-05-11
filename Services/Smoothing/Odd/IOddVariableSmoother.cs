namespace Services.Smoothing.Odd
{
    public interface IOddVariableSmoother
    {
        double CalculateSecondSmoothedVariable(double[] values);
        double CalculatePenultimateSmoothedVariable(double[] values);
    }
}