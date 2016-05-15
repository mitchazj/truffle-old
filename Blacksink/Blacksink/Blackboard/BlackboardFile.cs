using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blacksink.Blackboard
{
    public class BlackboardFile
    {
        public string Name { get; set; }
        public string URL { get; set; }
        public string RawURL { get; set; }
        public string LocalPath { get; set; }
        public int TimesDownloaded { get; set; }
        public DateTime FirstDownloaded { get; set; }
        public DateTime LastDownloaded { get; set; }

        public BlackboardFile() { }
        public BlackboardFile(string name, string url) { Name = name; URL = url; }
    }
}
