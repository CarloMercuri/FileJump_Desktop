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
    public class CustomProgressBar : Panel
    {
        private int _percent;
        public int Percentage
        {
            get { return _percent; }
            set { UpdatePercentage(value); }
        }




        public Color BackgroundBarColor { get; set; } = Color.Gray;
        public Color ProgressBarColor { get; set; } = Color.Red;


        public CustomProgressBar()
            : base()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        private void UpdatePercentage(int value)
        {
            this._percent = value;
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw the background bar
            g.FillRectangle(new SolidBrush(BackgroundBarColor), new Rectangle(0, 0, this.Width, this.Height));

            // Draw the progress bar
            g.FillRectangle(new SolidBrush(ProgressBarColor), 0, 0, (int)(((decimal)this.Width / 100) * _percent), this.Height);

            base.OnPaint(e);

        }
    }
}
