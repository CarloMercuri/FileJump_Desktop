using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileJump.CustomControls
{
    public class NetworkDevicePanel : Panel
    {
        public Image DeviceIcon { get; set; }
        public bool IsPressed { get; set; }

        public string DeviceName { get; set; }
        public int DeviceIconSize { get; set; }

        public int DeviceNameTextOffset { get; set; }

        public NetworkDevicePanel()
            : base()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if(DeviceIcon != null)
            {
                int iconX = 5;
                int iconY = (this.Height / 2) - DeviceIconSize / 2;

                int textX = DeviceNameTextOffset;
                int textY = 21;

                if (IsPressed)
                {
                    iconX += 5;
                    iconY += 5;

                    textX += 5;
                    textY += 5;
                }

                e.Graphics.DrawImage(DeviceIcon, new Rectangle(iconX,
                                                               iconY,
                                                               DeviceIconSize,
                                                               DeviceIconSize - 3 // TODO: Fix (the icon is not square)
                                                               ));



                e.Graphics.DrawString(DeviceName, this.Font, new SolidBrush(Color.FromArgb(255, 112, 119, 144)), new Point(DeviceNameTextOffset, textY));
            }

            base.OnPaint(e);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // WS_CLIPCHILDREN
                return cp;
            }
        }
    }
}
