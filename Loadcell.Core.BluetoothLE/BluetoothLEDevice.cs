using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;

namespace Loadcell.Core.BluetoothLE
{
    public class BluetoothLEDevice
    {
        public string Name { get; }
        public string Address { get; }
        public bool IsConnected { get; }
        public bool Authenticated { get; }
        public bool Remembered { get; }
        public DateTime LastSeen { get; }
        public DateTime LastUsed { get; }
        public int Rssi { get; }

        #region Constructors

        public BluetoothLEDevice()
        {
            Name = "No Name";
            Address = "No Address";
        }
        public BluetoothLEDevice(BluetoothDeviceInfo deviceInfo)
        {
            Name = deviceInfo.DeviceName;
            Address = $"{deviceInfo.DeviceAddress}";
            IsConnected = deviceInfo.Connected;
            Authenticated = deviceInfo.Authenticated;
            Remembered = deviceInfo.Remembered;
            LastSeen = deviceInfo.LastSeen;
            LastUsed = deviceInfo.LastUsed;
            Rssi = deviceInfo.Rssi;
        }



        #endregion

    }
}
