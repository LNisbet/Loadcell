using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace LoadCell
{
    internal interface IProgressor
    {
        uint BatteryVoltage_mV { get; }
        WeightMeasurement WeightMeasurement { get; }
        bool LowPower { get; }

        void TareScale();
        void StartMeasurement();
        void StopMeasurement();
        void Shutdown();

    }
}
