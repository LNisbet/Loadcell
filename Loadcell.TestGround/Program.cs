// See https://aka.ms/new-console-template for more information
using InTheHand.Net.Sockets;
using Loadcell.Core;
using Loadcell.Core.BluetoothLE;
using System.Runtime.Serialization.Formatters;
using System.Security.Cryptography.X509Certificates;
using InTheHand.Net.Bluetooth;

namespace Loadcell.TestGround
{
    class Program {

        
        static void Main(string[] args)
        {
            IBluetoothLE BluetoothLE = new LoadcellBluetoothLE();
            for (int i = 0; i < BluetoothLE.BluetoothLEDevices.Count; i++)
            {
                Console.WriteLine($"Device Name: {BluetoothLE.BluetoothLEDevices[i].Name} Connected: {BluetoothLE.BluetoothLEDevices[i].IsConnected}");
            }

            Console.ReadLine();
        }
    }
}

