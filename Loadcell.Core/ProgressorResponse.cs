using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Loadcell.Core
{
    public class ProgressorResponse
    {
        public EProgressorResponseCodes ResponseCode { get; }
        public byte Length { get; }
        public uint? Value1 { get; }
        public float? Value2 { get; }

        public ProgressorResponse(EProgressorResponseCodes responseCode, byte length)
        {
            ResponseCode = responseCode;
            Length = length;
            Value1 = null;
            Value2 = null;
        }
        public ProgressorResponse(EProgressorResponseCodes responseCode, byte length, uint value1)
        {
            ResponseCode = responseCode;
            Length = length;
            Value1 = value1;
            Value2 = null;
        }
        public ProgressorResponse(EProgressorResponseCodes responseCode, byte length, uint value1, float value2)
        {
            ResponseCode = responseCode;
            Length = length;
            Value1 = value1;
            Value2 = value2;
        }
    }
    public enum EProgressorResponseCodes : byte
    {
        CMD_RESPONSE = 0x00,
        WEIGHT_MEASUREMENT = 0x01,
        RFD_PEAK = 0x02,
        RFD_PEAK_SERIES = 0x03,
        LOW_PWR_WARNING = 0x04
    }
}
