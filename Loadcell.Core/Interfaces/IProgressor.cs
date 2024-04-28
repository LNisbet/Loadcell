using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Loadcell.Core
{
    public interface IProgressor
    {
        uint BatteryVoltage_mV { get; }
        WeightMeasurement WeightMeasurement { get; }
        void TareScale();
        void StartMeasurement();
        void StopMeasurement();
        void Shutdown();
    }

    public static class ProgressorUUIDs
    {
        public const string ProgressorService = "7e4e1701-1ea6-40c9-9dcc-13d34ffead57";
        public const string DataCharacteristic = "7e4e1702-1ea6-40c9-9dcc-13d34ffead57";
        public const string ControlPointCharacteristic = "7e4e1703-1ea6-40c9-9dcc-13d34ffead57";
    }
}
