// See https://aka.ms/new-console-template for more information
//using Loadcell.Core.BluetoothLE;
using Loadcell.Core.BluetoothLE;
using System.Runtime.Serialization.Formatters;
using System.Security.Cryptography.X509Certificates;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Devices.Enumeration;

namespace Loadcell.TestGround
{
    class Program {

        
        static void Main()
        {
            IBluetoothLEConnection bluetoothLEConnection = new WindowsBluetoothLEConnection();
            bluetoothLEConnection.Devices.Clear();
            bluetoothLEConnection.StartScanningForDevices();

            bluetoothLEConnection.Devices.CollectionChanged += (sender, info) =>
            {
                Console.WriteLine($"Name: {bluetoothLEConnection.Devices.Last().Name}, ID: {bluetoothLEConnection.Devices.Last().ID}");
            };

            Console.ReadLine();
        }
    }
}

