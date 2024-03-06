using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace LoadCell.Core.BluetoothLE
{
    public class WeightMeasurement
    {
        public uint Weight { get; set; }
        public uint TimeStamp { get; set; }

        public WeightMeasurement(uint weight, uint timestamp)
        {
            Weight = weight;
            TimeStamp = timestamp;
        }

    }
}
