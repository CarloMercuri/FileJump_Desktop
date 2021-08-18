using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileJump.FormElements
{
    public class LoadingSwirl
    {
        private Timer tickTimer { get; set; }

        private TransparentControl panel_Main { get; set; }

        public LoadingSwirl(Color swirlColor, Point location, Size size, Control parentControl)
        {
            tickTimer = new Timer();
            tickTimer.Interval = 2;
            tickTimer.Tick += TimerTick;
            tickTimer.Start();

            panel_Main = new TransparentControl();
            panel_Main.Size = size;
            panel_Main.Location = location;
            panel_Main.Paint += PaintPanel;

            parentControl.Controls.Add(panel_Main);

            
        }

        private void PaintPanel(object sender, PaintEventArgs e)
        {
           // e.Graphics.DrawArc
        }

        public void StopTimer()
        {

        }

        private void TimerTick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
