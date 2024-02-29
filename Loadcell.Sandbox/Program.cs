// See https://aka.ms/new-console-template for more information
using Loadcell.Core;

Console.WriteLine("Hello, World!");

var watcher = new LoadcellBluetoothLEAdvertisementWatcher();
watcher.StartedListening += () =>
{
    Console.WriteLine("Started Lisning");
};
watcher.StoppedListening += () =>
{
    Console.WriteLine("Stoped Lisning");
};

watcher.StartListning();

Console.ReadLine();