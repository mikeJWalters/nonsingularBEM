using DataModel.Models.Splines;
using DataModel.Models.SurfaceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Splines
{
    public interface ISplineCalculator
    {
        SplineValues CalculateCoefficients(SurfaceVariable surfaceVariable);
    }
}
