using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Net.NetworkInformation;
using System.Net;

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

        public static string[] test_websites = new string[] {
            "http://www.bing.com/",
            "http://www.abc.net.au/",
            "http://www.facebook.com/"
        };

        public static Random picker = new Random();

        /// <summary>
        /// Test the internet connection by randomly attempting to access a website of choice.
        /// </summary>
        /// <returns></returns>
        public static bool strongInternetConnectionTest() {
            try {
                HttpWebRequest request = (HttpWebRequest) WebRequest.Create(test_websites[picker.Next(test_websites.Length)]);
                request.Timeout = 3000;
                HttpWebResponse response = (HttpWebResponse) request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK) {
                    return true;
                } else {
                    return false;
                }
            }
            catch {
                return false;
            }
        }
    }
}
