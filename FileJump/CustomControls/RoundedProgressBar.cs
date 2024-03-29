﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileJump.CustomControls
{
    public class RoundedProgressBar : Panel
    {
        private int _percent;
        public int Percentage
        {
            get { return _percent; }
            set { UpdatePercentage(value); }
        }




        public Color BackgroundBarColor { get; set; } = Color.Gray;
        public Color ProgressBarColor { get; set; } = Color.Red;


        public RoundedProgressBar()
            : base()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }

        private void UpdatePercentage(int value)
        {
            this._percent = value;
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Draw the background bar
            e.Graphics.FillRoundedRectangle(new SolidBrush(BackgroundBarColor), 0, 0, this.Width, this.Height, 15);

            // Draw the progress bar
            e.Graphics.FillRoundedRectangle(new SolidBrush(ProgressBarColor), 0, 0, (int)(((decimal)this.Width / 100) * _percent), this.Height, 15);



        }
    }
}
