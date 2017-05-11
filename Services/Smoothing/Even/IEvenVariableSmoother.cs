namespace Services.Smoothing.Even
{
    public interface IEvenVariableSmoother
    {
        double CalculateSmoothedFirstNode(double[] values);
        double CalculateSmoothedSecondNode(double[] values);
        double CalculateSmoothedPenultimateNode(double[] values);
        double CalculateSmoothedFinalNode(double[] values);
    }
}