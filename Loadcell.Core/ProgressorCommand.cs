using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Loadcell.Core
{
    public class ProgressorCommand
    {
        public EProgressorOpcodes Opcode { get;}
        public byte Length { get; }
        public byte[] Value { get; }

        public ProgressorCommand(EProgressorOpcodes opcode)
        {
            Opcode = opcode;
            Length = 0;
            Value = new byte[Length];
        }
    }
    public enum EProgressorOpcodes : byte
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
}
