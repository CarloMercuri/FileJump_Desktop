using FileJump.GUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileJump.CustomControls
{
    public class CustomGeneralButton : Button
    {
        public bool IsPressed { get; set; }
        public Font TextFont { get; set; }
        public string ButtonText { get; set; }

        private Image CustomBackground { get; set; }

        public CustomGeneralButton()
           : base()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            CustomBackground = Properties.Resources.device_panel_normal;
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            CustomBackground = Properties.Resources.device_panel_pressed;
            this.IsPressed = true;
            base.OnMouseDown(mevent);
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            CustomBackground = Properties.Resources.device_panel_normal;
            this.IsPressed = false;
            base.OnMouseUp(mevent);
        }



        protected override void OnPaint(PaintEventArgs e)
        {
            Size textSize = TextRenderer.MeasureText(ButtonText, TextFont);

            int textX = this.Width / 2 - textSize.Width / 2;
            int textY = this.Height / 2 - textSize.Height / 2;

            if (IsPressed)
            {
                textX += 3;
                textY += 3;
                
            }


            e.Graphics.DrawImage(CustomBackground, new Rectangle(0,
                                                               0,
                                                               this.Width,
                                                               this.Height 
                                                               ));

            e.Graphics.DrawString(ButtonText, this.TextFont, new SolidBrush(this.ForeColor), new Point(textX, textY));
            //base.OnPaint(e);
        }

    }
}
