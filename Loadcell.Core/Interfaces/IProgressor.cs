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

    public enum EProgressorCommands : byte
    {
        TARE_SCALE = 0x64,
        START_WEIGHT_MEASUREMENT = 0x65,
        STOP_WEIGHT_MEASUREMENT = 0x66,
        START_PEAK_RFD_MEASUREMENT = 0x67,
        START_PEAK_RFD_MEASUREMENT_SERIES = 0x68,
        ADD_CALIBRATION_POINT = 0x69,
        SAVE_CALIBRATION = 0x6A,
        GET_APP_VERSION = 0x6B,
        GET_ERROR_INFORMATION = 0x6C,
        CLR_ERROR_INFORMATION = 0x6D,
        ENTER_SLEEP = 0x6E,
        GET_BATTERY_VOLTAGE = 0x6F
    }

    public enum EProgressorResponses : byte
    {
        CMD_RESPONSE = 0x00,
        WEIGHT_MEAS = 0x01,
        RFD_PEAK = 0x02,
        RFD_PEAK_SERIES = 0x03,
        LOW_PWR_WARNING = 0x04
    }
    public static class ProgressorUUIDs
    {
        public const string ProgressorService = "7e4e1701-1ea6-40c9-9dcc-13d34ffead57";
        public const string DataCharacteristic = "7e4e1702-1ea6-40c9-9dcc-13d34ffead57";
        public const string ControlPointCharacteristic = "7e4e1703-1ea6-40c9-9dcc-13d34ffead57";
    }
}
