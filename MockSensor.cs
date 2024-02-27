using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoadCell
{
    internal class MockSensor : ISensor
    {
        private Random random = new();
        private float scaleValue = 1;

        float ISensor.Value => (float)random.NextDouble() * scaleValue;

        void ISensor.SetScale(float ScaleValue)
        {
            scaleValue = ScaleValue;
        }

        void ISensor.SetZero()
        {
            ;
        }
    }
}
