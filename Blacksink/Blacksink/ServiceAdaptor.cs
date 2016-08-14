using Blacksink.Blackboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blacksink
{
    public class ServiceAdaptor {
        public delegate void SendMessage(object sender, ServiceAdaptorEventArgs e);
        public event SendMessage MessageReceived;

        public void sendMessage(string message) {
            if (MessageReceived != null)
                MessageReceived(this, new ServiceAdaptorEventArgs(message));
        }

        public int getUnitCount{
            get { return GlobalVariables.Units.Count; }
        }
    }

    public class ServiceAdaptorEventArgs : EventArgs {
        public string Message { get; set; }
        public ServiceAdaptorEventArgs(string message) {
            Message = message;
        }
    }
}
