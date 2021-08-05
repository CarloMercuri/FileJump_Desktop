using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileJump.GUI
{
    public class HighlightPanel
    {
        public Panel MainPanel { get; set; }
        public Label TextLabel { get; set; }
        public Panel PopupPanel { get; set; }
        public bool IsHighlighted { get; set; }
        public bool IsSelected { get; set; }
    }
}
