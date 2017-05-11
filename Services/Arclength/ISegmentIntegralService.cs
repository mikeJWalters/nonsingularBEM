using DataModel.Models.Splines;
using DataModel.Models.SurfaceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Arclength
{
    public interface ISegmentIntegralService
    {
        SurfaceArclength SegmentIntegrate(SplineValues radialSplines, SplineValues verticalSplines);
        SurfaceArclength SegmentIntegrateArclength(SplineValues parameterisedRadialSplines, SplineValues parameterisedVerticalSplines, SurfaceArclength arclength);
    }
}
