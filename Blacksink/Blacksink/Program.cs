using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blacksink
{
    static class Program
    {
        /// <summary>
        /// Helps us to ensure only one instance runs at a time.
        /// This GUID is unique to Truffle and is special for only that reason.
        /// </summary>
        static Mutex mutex = new Mutex(true, "{0fbc294c-f089-4009-9b1a-ab757739483f}");

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            if (mutex.WaitOne(TimeSpan.Zero, true)) {
                try {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    CefSharp.Cef.EnableHighDPISupport();
                    //Application.Run(new Blackboard.frmTestInternet());
                    Application.Run(new MainContext());
                    CefSharp.Cef.Shutdown();
                }
                finally {
                    mutex.ReleaseMutex();
                }
            }
        }
    }
}
