using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loadcell.Core.BluetoothLE
{
    public interface IBluetoothLE
    {
        List<BluetoothLEDevice> BluetoothLEDevices { get; }
    }
}
