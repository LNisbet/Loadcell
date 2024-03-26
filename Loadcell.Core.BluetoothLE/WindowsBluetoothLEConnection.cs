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

namespace Loadcell.Core.BluetoothLE
{
    public class WindowsBluetoothLEConnection : IBluetoothLEConnection
    {
        #region Fields
        private ObservableCollection<BluetoothLEDevice> devices = new();

        public ObservableCollection<BluetoothLEDevice> Devices => devices;

        private DeviceWatcher deviceWatcher;
        private string[] requestedProperties =
        {
            "System.Devices.Aep.DeviceAddress",
            "System.Devices.Aep.IsConnected",
            "System.Devices.Aep.Bluetooth.Le.IsConnectable"
        };
        // BT_Code: Example showing paired and non-paired in a single query.
        private string aqsAllBluetoothLEDevices =
            "(System.Devices.Aep.ProtocolId:=\"{bb7bb05e-5972-42b5-94fc-76eaa7084d49}\")";

        #endregion

        #region Constructor
        public WindowsBluetoothLEConnection()
        {
            deviceWatcher = DeviceInformation.CreateWatcher(aqsAllBluetoothLEDevices,requestedProperties,DeviceInformationKind.AssociationEndpoint);

            // Register event handlers before starting the watcher.
            deviceWatcher.Added += (sender, info) =>
            {
                if (info.Name != null && info.Name != "")
                {
                    devices.Add(new BluetoothLEDevice(info));
                }
            };

            deviceWatcher.Updated += (sender, info) =>
            {
                // updated must be not null or search won't be performed
            };
        }
        #endregion

        #region Implementation
        public void StartScanningForDevices()
        {
            deviceWatcher.Start();
        }

        public void StopScanningForDevices()
        {
            deviceWatcher.Stop();
        }

        public void Connect(BluetoothLEDevice Device)
        {
            if (!devices.Contains(Device)) { throw new ConnectionFailedException($"{Device.Name} was not found"); }

            throw new NotImplementedException();
        }

        public void Disconnect(BluetoothLEDevice Device)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
