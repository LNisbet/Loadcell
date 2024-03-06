using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;

namespace Loadcell.Core.BluetoothLE
{
    public class BluetoothLEDevice
    {
        public string Name { get; }
        public string ID { get; }

        #region Constructors

        public BluetoothLEDevice()
        {
            Name = "No Name";
            ID = "No ID";
        }
        public BluetoothLEDevice(string name, string id)
        {
            Name = name;
            ID = id;
        }
        public BluetoothLEDevice(DeviceInformation info)
        {
            Name = info.Name;
            ID = info.Id;
        }

        #endregion

    }
}
