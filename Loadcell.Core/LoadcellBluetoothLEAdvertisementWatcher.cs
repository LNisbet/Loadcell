using Windows.Devices.Bluetooth.Advertisement;

namespace Loadcell.Core
{
    public class LoadcellBluetoothLEAdvertisementWatcher
    {

        public event Action StoppedListening = () => {};
        public event Action StartedListening = () => { };

        public bool lisning => watcher.Status == BluetoothLEAdvertisementWatcherStatus.Started;

        private readonly BluetoothLEAdvertisementWatcher watcher;
        public LoadcellBluetoothLEAdvertisementWatcher ()
        {
            watcher = new BluetoothLEAdvertisementWatcher
            {
                ScanningMode = BluetoothLEScanningMode.Active,
            };
            watcher.Received += WatcherAdvertismentRecived;

            watcher.Stopped += (watcher, e) =>
            {
                StoppedListening();
            };
        }

        private void WatcherAdvertismentRecived(BluetoothLEAdvertisementWatcher sender, BluetoothLEAdvertisementReceivedEventArgs args)
        {
            throw new NotImplementedException();
        }

        public void StartListning()
        {
            if (lisning)
            {
                return;
            }
            watcher.Start();
            StartedListening();
        }

        public void StopListning()
        {
            if (!lisning)
            {
                return;
            }
            watcher.Stop();
            StoppedListening();
        }
    }
}