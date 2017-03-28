using DataModel.Models.SurfaceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Volume
{
    public interface IVolumeCalculator
    {
        double CalculateVolume(BubbleSurface surface);
    }
}
