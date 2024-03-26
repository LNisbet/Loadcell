using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loadcell.Core.BluetoothLE
{
    public interface IBluetoothLEConnection
    {
        ObservableCollection<BluetoothLEDevice> Devices { get; }
        void StartScanningForDevices();
        void StopScanningForDevices();
        void Connect(BluetoothLEDevice Device);
        void Disconnect(BluetoothLEDevice Device);
    }
}
