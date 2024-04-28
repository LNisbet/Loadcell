using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loadcell.Core.BluetoothLE;
using Windows.Security.Cryptography;
using Windows.Storage.Streams;

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
                _BLEConnection.SendCommand(Convert.ToByte(EProgressorOpcodes.GET_BATTERY_VOLTAGE));
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
            _BLEConnection.SendCommand(Convert.ToByte(EProgressorOpcodes.ENTER_SLEEP));
        }

        public void StartMeasurement()
        {
            _BLEConnection.SendCommand(Convert.ToByte(EProgressorOpcodes.START_WEIGHT_MEASUREMENT));
        }

        public void StopMeasurement()
        {
            _BLEConnection.SendCommand(Convert.ToByte(EProgressorOpcodes.STOP_WEIGHT_MEASUREMENT));
        }

        public void TareScale()
        {
            _BLEConnection.SendCommand(Convert.ToByte(EProgressorOpcodes.TARE_SCALE));
        }

        #endregion

        #region Recive Commands

        float WeightUnitConverter(float raw, EMeasurementUnits units)
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

        public ProgressorResponse ParseLoadcellResponse(IBuffer buffer)
        {
            
            byte[] bytes = new byte[buffer.Length];
            CryptographicBuffer.CopyToByteArray(buffer, out bytes);

            EProgressorResponseCodes responseCode = (EProgressorResponseCodes)bytes.ElementAt(1);
            byte length = bytes.ElementAt(1);
            byte[] value = new byte[length];

            Array.Copy(bytes, 2, value, 0, length);

            switch (responseCode)
            {
                case EProgressorResponseCodes.CMD_RESPONSE:
                    uint batteryVoltage_mV = BitConverter.ToUInt32(value, 0);

                    return new ProgressorResponse(responseCode, length, batteryVoltage_mV);

                case EProgressorResponseCodes.WEIGHT_MEASUREMENT:
                    uint timestamp = BitConverter.ToUInt32(value, 0);
                    float weightMeasurement = BitConverter.ToSingle(value, 8);

                    return new ProgressorResponse(responseCode, length, timestamp, weightMeasurement);

                case EProgressorResponseCodes.LOW_PWR_WARNING:
                    throw new ProgressorException("Low Power Switching off");

                case EProgressorResponseCodes.RFD_PEAK:
                    throw new NotImplementedException();

                case EProgressorResponseCodes.RFD_PEAK_SERIES:
                    throw new NotImplementedException();

                default:
                    throw new ProgressorException($"Unknown Response: {responseCode}");
            }
        }
        #endregion
    }
}
