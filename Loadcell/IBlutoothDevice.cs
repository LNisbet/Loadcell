using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace LoadCell
{
    internal interface IBlutoothDevice
    {
        void Connect();
        void Disconnect();
    }
}
