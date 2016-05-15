using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blacksink.Blackboard
{
    public class Unit
    {
        public string Name { get; set; }
        public string URL { get; set; }
        public List<BlackboardFile> Files { get; set; }

        public Unit() { }
        public Unit(string name, string url) { Name = name; URL = url; }

        public static bool IsFilePreviouslyDownloaded(string url) {
            if (GlobalVariables.Units != null) {
                bool found = false;
                for (int j = 0; j < GlobalVariables.Units.Count; ++j) {
                    Unit u = GlobalVariables.Units[j];
                    if (u.Files == null)
                        u.Files = new List<BlackboardFile>();
                    for (int i = 0; i < u.Files.Count; ++i) {
                        if (u.Files[i].RawURL == url) {
                            found = true;
                            break;
                        }
                    }
                }
                return found;
            } else {
                throw new Exception("Should not call this before GlobalVariables.Units is created.");
            }
        }

        public static void EnsureExists(Unit unit) {
            if (GlobalVariables.Units != null) {
                bool found = false;
                for (int j = 0; j < GlobalVariables.Units.Count; ++j) {
                    if (GlobalVariables.Units[j].Name == unit.Name) {
                        found = true;
                        break;
                    }
                }
                if (!found) {
                    GlobalVariables.Units.Add(unit);
                }
            }
            else {
                throw new Exception("Should not call this before GlobalVariables.Units is created.");
            }
        }
    }
}
