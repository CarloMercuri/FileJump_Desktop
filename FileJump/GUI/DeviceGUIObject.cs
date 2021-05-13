using FileJump.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileJump
{
    public class DeviceGUIObject
    {
        public Panel panel_Main { get; set; }

        public Button btn_Device { get; set; }

        public Label label_DeviceName { get; set; }

        public NetworkDevice Device { get; set; }

        
    }
}
