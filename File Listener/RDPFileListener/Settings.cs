using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDPFileListener
{
    internal class Settings
    {
        public string PathToListenOn { get; set; }
        public string FilesToLookFor { get; set; }
        public string SettingsToAdd { get; set; }
    }
}
