using InTheHand.Net.Bluetooth;
using InTheHand.Net.Bluetooth.Factory;
using InTheHand.Net.Sockets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Loadcell.Core.BluetoothLE
{
    public class LoadcellBluetoothLE : IBluetoothLE
    {
        private List<BluetoothLEDevice> devices = new();
        public List<BluetoothLEDevice> BluetoothLEDevices
        {
            get
            {
                return devices;
            }
        }

        public LoadcellBluetoothLE()
        {
            BluetoothClient bluetoothClient = new();
            var bluetoothDevices = bluetoothClient.DiscoverDevices();
            var bluetoothDeviceInfos = bluetoothDevices.ToList();
            for (int i = 0; i < bluetoothDeviceInfos.Count; i++)
            {
                devices.Add(new BluetoothLEDevice(bluetoothDeviceInfos[i]));
            }
        }



        public async Task<BluetoothDeviceInfo[]> SearchDevicesAsync()
        {
            var bluetoothClient = new BluetoothClient();
            var bluetoothDevices = await Task.Run(() => bluetoothClient.DiscoverDevices());
            bluetoothClient.Close();
            return bluetoothDevices;
        }
    }
}
