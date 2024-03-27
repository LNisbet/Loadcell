using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loadcell.Core.BluetoothLE;

namespace Loadcell.Core
{
    public class Progressor200 : IProgressor
    {
        private WindowsBluetoothLEConnection _BLEConnection;

        public EMeasurementUnits MeasurementUnits { get; set; }

        private uint batteryVoltage_mV;
        public uint BatteryVoltage_mV { 
            get 
            {
                _BLEConnection.SendCommand(Convert.ToByte(EProgressorCommands.GET_BATTERY_VOLTAGE));
                return batteryVoltage_mV;
            }
        }

        private WeightMeasurement weightMeasurement;
        public WeightMeasurement WeightMeasurement { get { return weightMeasurement; } }

        #region Constructor
        public Progressor200() 
        {
            MeasurementUnits = EMeasurementUnits.Raw;
            weightMeasurement = WeightMeasurement;
            _BLEConnection = new();
            _BLEConnection.StartScanningForDevices();
        }
        #endregion

        #region Send Commands
        public void Shutdown()
        {
            StopMeasurement();
            _BLEConnection.SendCommand(Convert.ToByte(EProgressorCommands.ENTER_SLEEP));
        }

        public void StartMeasurement()
        {
            _BLEConnection.SendCommand(Convert.ToByte(EProgressorCommands.START_WEIGHT_MEASUREMENT));
        }

        public void StopMeasurement()
        {
            _BLEConnection.SendCommand(Convert.ToByte(EProgressorCommands.STOP_WEIGHT_MEASUREMENT));
        }

        public void TareScale()
        {
            _BLEConnection.SendCommand(Convert.ToByte(EProgressorCommands.TARE_SCALE));
        }

        #endregion

        #region Recive Commands
        void RecivedCommandDecription(string command)
        {
            EProgressorResponses responseCode = new();
            int Length = 0;
            float fValue = 0;
            uint iValue = 0;

            switch (responseCode)
            {
                case EProgressorResponses.CMD_RESPONSE:
                    batteryVoltage_mV = iValue;
                    return;

                case EProgressorResponses.WEIGHT_MEAS:
                    weightMeasurement = new (MeasurementConverter(fValue, MeasurementUnits), iValue);
                    return;

                case EProgressorResponses.LOW_PWR_WARNING:
                    throw new ProgressorException("Low Power Switching off");

                case EProgressorResponses.RFD_PEAK:
                    throw new NotImplementedException();

                case EProgressorResponses.RFD_PEAK_SERIES:
                    throw new NotImplementedException();

                default:
                    throw new ProgressorException($"Unknown Response: {responseCode}");
            }
        }

        float MeasurementConverter(float raw, EMeasurementUnits units)
        {
            switch (units)
            {
                case EMeasurementUnits.N:
                    return raw;
                case EMeasurementUnits.Kg:
                    return raw / 9.81f;
                case EMeasurementUnits.lbs:
                    return raw * 0.224809f;

                default:
                    return raw;
            }
        }
        #endregion
    }
}
