using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadCell.Core
{
    internal class Progressor200 : IProgressor
    {
        uint IProgressor.BatteryVoltage_mV => throw new NotImplementedException();

        WeightMeasurement IProgressor.WeightMeasurement => throw new NotImplementedException();

        bool IProgressor.LowPower => throw new NotImplementedException();

        void IProgressor.Shutdown()
        {
            throw new NotImplementedException();
        }

        void IProgressor.StartMeasurement()
        {
            throw new NotImplementedException();
        }

        void IProgressor.StopMeasurement()
        {
            throw new NotImplementedException();
        }

        void IProgressor.TareScale()
        {
            throw new NotImplementedException();
        }
    }
}
