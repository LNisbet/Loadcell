using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;

namespace Loadcell.Core.BluetoothLE
{
    public class BluetoothLEDevice_
    {
        public string Name { get; }
        public string ID { get; }

        #region Constructors

        public BluetoothLEDevice_()
        {
            Name = "No Name";
            ID = "No ID";
        }
        public BluetoothLEDevice_(string name, string id)
        {
            Name = name;
            ID = id;
        }
        public BluetoothLEDevice_(DeviceInformation info)
        {
            Name = info.Name;
            ID = info.Id;
        }

        #endregion

    }
}
