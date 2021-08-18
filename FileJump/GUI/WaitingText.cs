using FileJump.CustomControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileJump.GUI
{
    public class WaitingText
    {
        private CustomGeneralButton targetControl { get; set; }
        private string WaitText { get; set; }
        private Timer tickTimer { get; set; }
        private int dotsCount { get; set; }

        public WaitingText(string text, CustomGeneralButton controlWithText)
        {
            targetControl = controlWithText;
            WaitText = text;
            tickTimer = new Timer();
            tickTimer.Interval = 150;
            tickTimer.Tick += TickTock;
            tickTimer.Start();
            dotsCount = 1;

        }

        private void TickTock(object sender, EventArgs e)
        {
            string temp = $"{WaitText} ";

            for (int i = 0; i < dotsCount; i++)
            {
                temp += ".";
            }
            if (targetControl.InvokeRequired)
            {
                targetControl.Invoke(
                         new MethodInvoker(
                         delegate () { targetControl.ButtonText = temp; }));
            }else
            {
                targetControl.ButtonText = temp;
            }
           

            dotsCount++;
            if (dotsCount > 4) dotsCount = 1;
        }
    }
}
