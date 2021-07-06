using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileJump.CustomControls
{
    public class RoundedButton : Control
    {
        private Image ShadowImage { get; set; }
        private Color _bgColor { get; set; } = Color.White;

        private int _shadowThickness { get; set; }

        public RoundedButton(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            _shadowThickness = 15;
            ShadowImage = ImageEditing.DrawPanelShadow(width, height, _shadowThickness);

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //Graphics g = e.Graphics;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;


            // Draw the shadow
            e.Graphics.DrawImage(ShadowImage, new Point(0, 0));

            e.Graphics.FillRoundedRectangle(new SolidBrush(_bgColor), 0, 0, this.Width - _shadowThickness, this.Height - _shadowThickness, 5);
        }
    }
}
