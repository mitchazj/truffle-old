using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Blacksink.Blackboard
{
    /// <summary>
    /// Allows Truffle to test the internet connection
    /// </summary>
    public static class InternetConnectivity
    {
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int connDescription, int ReservedValue);
        public static bool IsConnectionAvailable() { int dummy; return InternetGetConnectedState(out dummy, 0); }
    }
}
