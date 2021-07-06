using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileJump.FormElements
{
    public class SettingsFormElement
    {
        private CheckBox checkBox_RunStartup { get; set; }
        private Panel MainPanel { get; set; }

    
        public Panel CreateSettingsPanel(Point location, int width, int height)
        {
            MainPanel = new Panel();
            MainPanel.Location = location;
            MainPanel.Size = new Size(width, height);
            MainPanel.BackColor = Color.Transparent;

            checkBox_RunStartup = new CheckBox();

            checkBox_RunStartup.Font = new Font("Arial", 12, FontStyle.Bold);
            checkBox_RunStartup.ForeColor = Color.FromArgb(255, 122, 129, 154);
            checkBox_RunStartup.Text = "Run on Windows Startup";
            checkBox_RunStartup.BackColor = Color.Transparent;
            checkBox_RunStartup.Location = new Point(30, 100);
            checkBox_RunStartup.AutoSize = true;
            //checkBox_RunStartup.Width = 350;

            MainPanel.Controls.Add(checkBox_RunStartup);

            return MainPanel;
        }


    }
}
