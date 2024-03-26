using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loadcell.Core.BluetoothLE
{
    public class ConnectionFailedException : Exception
    {
        public ConnectionFailedException() { }

        public ConnectionFailedException(string message) : base(message) { }
    }
}
