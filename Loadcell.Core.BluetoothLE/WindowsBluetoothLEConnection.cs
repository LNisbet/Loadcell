using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Devices.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Reflection.Metadata.Ecma335;
using Windows.Storage.Streams;
using Windows.Foundation;

namespace Loadcell.Core.BluetoothLE
{
    public class WindowsBluetoothLEConnection : IBluetoothLEConnection
    {
        #region Fields
        private ObservableCollection<BluetoothLEDevice_> devices = new();

        public ObservableCollection<BluetoothLEDevice_> Devices => devices;

        public byte CommandRecived => throw new NotImplementedException();


        private DeviceWatcher deviceWatcher;


        #endregion

        #region Constructor
        public WindowsBluetoothLEConnection()
        {
            string[] requestedProperties =
            {
            "System.Devices.Aep.DeviceAddress",
            "System.Devices.Aep.IsConnected",
            "System.Devices.Aep.Bluetooth.Le.IsConnectable"
            };
            // BT_Code: Example showing paired and non-paired in a single query.
            string aqsAllBluetoothLEDevices = "(System.Devices.Aep.ProtocolId:=\"{bb7bb05e-5972-42b5-94fc-76eaa7084d49}\")";

            deviceWatcher = DeviceInformation.CreateWatcher(aqsAllBluetoothLEDevices, requestedProperties, DeviceInformationKind.AssociationEndpoint);
        }
        #endregion

        #region Implementation
        public void StartScanningForDevices()
        {
            // Register event handlers before starting the watcher.
            deviceWatcher.Added += (sender, info) =>
            {
                if (info.Name != null && info.Name != "")
                {
                    devices.Add(new BluetoothLEDevice_(info));
                }
            };
            deviceWatcher.Updated += (sender, info) => { };// updated must be not null or search won't be performed
            deviceWatcher.Removed += (sender, info) => { };
            deviceWatcher.EnumerationCompleted += (sender, info) => { };
            deviceWatcher.Stopped += (sender, info) => { };

            devices.Clear();
            // Active enumeration is limited to approximately 30 seconds.
            // This limits power usage and reduces interference with other Bluetooth activities.
            // To monitor for the presence of Bluetooth LE devices for an extended period,
            // use the BluetoothLEAdvertisementWatcher runtime class. See the BluetoothAdvertisement
            // sample for an example.
            deviceWatcher.Start();
        }

        public void StopScanningForDevices()
        {
            // Unregister the event handlers.
            deviceWatcher.Added -= (sender, info) => { };
            deviceWatcher.Updated -= (sender, info) => { };
            deviceWatcher.Removed -= (sender, info) => { };
            deviceWatcher.EnumerationCompleted -= (sender, info) => { };
            deviceWatcher.Stopped -= (sender, info) => { };

            deviceWatcher.Stop();
        }
        public async void Pair(DeviceInformation Device)
        {
            // BT_Code: Pair the currently selected device.
            DevicePairingResult result = await Device.Pairing.PairAsync();
            DevicePairingResultStatus status = result.Status;
            if (status != DevicePairingResultStatus.Paired)
            {
                throw new ConnectionFailedException(Convert.ToString(status));
            }
        }

        public async void Connect(DeviceInformation Device)
        {
            //if (!devices.Contains(Device)) { throw new ConnectionFailedException($"{Device.Name} was not found"); }

            // BT_Code: BluetoothLEDevice.FromIdAsync must be called from a UI thread because it may prompt for consent.
            var bluetoothLeDevice = await BluetoothLEDevice.FromIdAsync(Device.Id) ?? throw new ConnectionFailedException("Failed to connect to device.");

            if (bluetoothLeDevice != null)
            {
                // Note: BluetoothLEDevice.GattServices property will return an empty list for unpaired devices. For all uses we recommend using the GetGattServicesAsync method.
                // BT_Code: GetGattServicesAsync returns a list of all the supported services of the device (even if it's not paired to the system).
                // If the services supported by the device are expected to change during BT usage, subscribe to the GattServicesChanged event.
                GattDeviceServicesResult result = await bluetoothLeDevice.GetGattServicesAsync(BluetoothCacheMode.Uncached);
            }
        }

        public void Disconnect(DeviceInformation Device)
        {
            throw new NotImplementedException();
        }

        public void SendCommand(int command, GattCharacteristic characteristic)
        {
            DataWriter writer = new();
            writer.ByteOrder = ByteOrder.LittleEndian;
            writer.WriteInt32(command);

            WriteBufferToSelectedCharacteristicAsync(writer.DetachBuffer(), characteristic);
        }

        private async void WriteBufferToSelectedCharacteristicAsync(IBuffer buffer, GattCharacteristic characteristic)
        {
            // BT_Code: Writes the value from the buffer to the characteristic.
            GattWriteResult result = await characteristic.WriteValueWithResultAsync(buffer);

            if (result.Status == GattCommunicationStatus.Success)
            {
                //Successfully wrote value to device
                return;
            }
            else
            {
                //Write failed
                throw new ConnectionFailedException();
            }
            #endregion
        }

        public bool SubscrbeToService(GattServiceProvider service)
        {
            throw new NotImplementedException();
        }
    }
}
