using System.Collections.ObjectModel;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Devices.Enumeration;

namespace Loadcell.Core.BluetoothLE
{
    public interface IBluetoothLEConnection
    {
        ObservableCollection<BluetoothLEDevice_> Devices { get; }
        void StartScanningForDevices();
        void StopScanningForDevices();
        void Connect(DeviceInformation Device);
        void Disconnect(DeviceInformation Device);
        void SendCommand(int command, GattCharacteristic characteristic);
        bool SubscrbeToService (GattServiceProvider service);
        byte CommandRecived { get; }
    }
}
