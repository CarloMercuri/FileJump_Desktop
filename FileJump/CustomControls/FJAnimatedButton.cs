using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileJump.CustomControls
{
    public class FJAnimatedButton : Control
    {
        public FJAnimatedButton(int width, int height)
            : base()
        {
            this.Width = width;
            this.Height = height;
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            using (Font font = new Font("Arial", 16, FontStyle.Bold, GraphicsUnit.Pixel))
            {
                TextRenderer.DrawText(e.Graphics, "Online Storage", font, new Point(20, 5), Color.FromArgb(255, 112, 119, 144));
            }

            using (Font font = new Font("Arial", 16, FontStyle.Bold, GraphicsUnit.Pixel))
            {
                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                e.Graphics.DrawString("Online Storage", font, new SolidBrush(Color.FromArgb(255, 112, 119, 144)), new Point(20, 30));
            }

            int thickness = 2;
            int halfThickness = thickness / 2;

            using (Pen p = new Pen(Color.FromArgb(255, 102, 109, 138), thickness))
            {
                e.Graphics.DrawRectangle(p, new Rectangle(halfThickness,
                                                          halfThickness,
                                                          this.ClientSize.Width - thickness,
                                                          this.ClientSize.Height - thickness));
            }


            base.OnPaint(e);
        }
    }
}
