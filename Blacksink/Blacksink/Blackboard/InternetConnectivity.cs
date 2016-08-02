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
            "http://www.nine.com.au/",
            "http://www.dropbox.com/",
            "http://www.youtube.com/",
            "http://maps.google.com.au/",
            "http://www.wikipedia.com/",
            "http://www.stackoverflow.com/",
            "http://onedrive.live.com/",
        };

        public static Random picker = new Random();

        private static int conn_test_counter = 0;
        private static int connectivity_fail_threshold = 15;

        public static bool isInternetWorkingTestVar = true;

        /// <summary>
        /// Test the internet connection by randomly attempting to access a website of choice.
        /// Will take a maximum of 20 seconds to run.
        /// </summary>
        /// <returns></returns>
        public static bool strongInternetConnectionTest() {
#if DEBUG
            return isInternetWorkingTestVar;
#endif
            int[] the_chosen_ones = new int[] {
                    picker.Next(0, test_websites.Length),
                    picker.Next(0, test_websites.Length),
                    picker.Next(0, test_websites.Length),
                    picker.Next(0, test_websites.Length)
                };

            bool connected = false;
            foreach (int chosen_one in the_chosen_ones) {
                try {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(test_websites[chosen_one]);
                    request.Timeout = 5000;
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    if (response.StatusCode == HttpStatusCode.OK) {
                        Console.WriteLine("YES!");
                        connected = true;
                        break;
                    }
                }
                catch { }
            }
            return connected;
        }

        /// <summary>
        /// General algorithm to check internet connection.
        /// [Broken] [Level -1] The state of the system when internet has been declared unavailable.
        /// [Level 0] If the system reports no cable/wifi connection, there is no connection
        /// [Level 1] If the system reports cable/wifi, we can assume there is a connection for now
        /// [Level 2] The system reported cable/wifi, be believed it, but let's check by pinging Google
        /// [Level 3] If the system still reports cable/wifi, but a Google ping failed to work, we'll hope for the best and give it one more shot
        /// [Level 4] Failed twice or more, so there is no connection because something's broken.
        /// </summary>
        /// <returns></returns>
        public static bool checkInternet() {
            if (conn_test_counter == -1) {
                //We have a problem. Major check til it works.
                conn_test_counter = strongInternetConnectionTest() ? 0 : -1;
                return conn_test_counter == 0;
            }

            if (IsConnectionAvailable()) {
                ++conn_test_counter;
                if (conn_test_counter == connectivity_fail_threshold) {
                    conn_test_counter = strongInternetConnectionTest() ? 0 : conn_test_counter + 1;
                    Console.WriteLine("[Level 2] Working Internet Connection - Timer Check");
                    return true;
                }
                else if (conn_test_counter > connectivity_fail_threshold + 1) {
                    conn_test_counter = strongInternetConnectionTest() ? 0 : conn_test_counter + 1;
                    if (conn_test_counter > connectivity_fail_threshold + 3) {
                        conn_test_counter = -1;
                        Console.WriteLine("[Level 4] No Internet Connection - Timer Check");
                        return false;
                    }
                    else {
                        Console.WriteLine("[Level 3] Working Internet Connection - Timer Check");
                        return true;
                    }
                }
                else {
                    Console.WriteLine("[Level 1] Working Internet Connection - Timer Check");
                    return true;
                }
            }
            else {
                Console.WriteLine("[Level 0] No Connection - Timer Check");
                conn_test_counter = -1;
                return false;
            }
        }
    }
}
