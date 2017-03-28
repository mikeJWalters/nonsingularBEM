using DataModel.Models.Splines;
using DataModel.Models.SurfaceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Splines
{
    public interface ISplineService
    {
        SplineValues CalculateQuinticNaturalValues(SurfaceVariable surfaceVariable);
        SplineValues CalculateQuinticClampedValues(SurfaceVariable surfaceVariable);
        SplineValues CalculateQuinticNaturalArclengthValues(SurfaceVariable surfaceVariable);
        SplineValues CalculateQuinticClampedArclengthlValues(SurfaceVariable surfaceVariable);
    }
}
