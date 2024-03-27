using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Loadcell.Core
{
    public class WeightMeasurement
    {
        public float Weight { get; }
        public uint TimeStamp { get; }

        public WeightMeasurement(float weight, uint timestamp)
        {
            Weight = weight;
            TimeStamp = timestamp;
        }

    }
}
