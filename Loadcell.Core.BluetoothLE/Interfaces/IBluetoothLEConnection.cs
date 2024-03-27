using System.Collections.ObjectModel;

namespace Loadcell.Core.BluetoothLE
{
    public interface IBluetoothLEConnection
    {
        ObservableCollection<BluetoothLEDevice_> Devices { get; }
        void StartScanningForDevices();
        void StopScanningForDevices();
        void Connect(BluetoothLEDevice_ Device);
        void Disconnect(BluetoothLEDevice_ Device);
        void SendCommand(byte command);
        byte CommandRecived { get; }
    }
}
