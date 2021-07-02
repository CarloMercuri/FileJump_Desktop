using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileJump.CustomControls
{
    public class RoundedCornersPanel : Panel
    {
        private int _borderRadius;
        public int BorderRadius
        {
            get { return _borderRadius; }
            set { _borderRadius = value; }
        }

        private Color _bgColor;

        public Color BackColorRounded
        {
            get { return _bgColor; }
            set { SetNewBackColor(value); }
        }

        private int _shadowThickness { get; set; } = 10;

        private Color _dividerColor { get; set; } = Color.FromArgb(255, 210, 210, 210);
        private bool _drawDivider { get; set; } = false;
        private int _dividerThickness { get; set; } = 6;
        private int _dividerHeight { get; set; } = 50;
        private Point _dividerStartPoint { get; set; } = new Point(0, 0);
        private Point _dividerEndPoint { get; set; } = new Point(0, 0);

        private Image ShadowImage { get; set; }

        private Rectangle DropInRectangle { get; set; }
        private bool _drawDropInHighlight { get; set; }

        public bool DrawDropInHighlight
        {
            get { return _drawDropInHighlight; }
            set { _drawDropInHighlight = value; this.Invalidate(); }
        }

        

        public RoundedCornersPanel()
            : base()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint, true);

            ShadowImage = ImageEditing.DrawPanelShadow(400, 500, _shadowThickness);
            //ShadowImage = ImageEditing.DrawPanelShadow(this.Width, this.Height);
            _bgColor = Color.White;
            _drawDropInHighlight = false;
        }
        
        private void SetNewBackColor(Color _color)
        {
            _bgColor = _color;
            this.Invalidate();
        }

        public void DrawDivider()
        {
            _dividerStartPoint = new Point(10, _dividerHeight);
            _dividerEndPoint = new Point(this.Width - 20, _dividerHeight);
            _dividerThickness = 1;
            _drawDivider = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {

            //Graphics g = e.Graphics;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;


            // Draw the shadow
            e.Graphics.DrawImage(ShadowImage, new Point(0, 0));

            ////e.Graphics.FillRectangle(new SolidBrush(Color.White), 0, 0, this.Width, this.Height);
            //// draw the round corners

            //DropInRectangle = new Rectangle(11, _dividerHeight + 1, this.Width - _shadowThickness - 20, this.Height - _shadowThickness - _dividerHeight - 1);

            //LinearGradientBrush grad_brush = new LinearGradientBrush(DropInRectangle,
            //        Color.FromArgb(100, 0, 250, 250),
            //        Color.FromArgb(0, 0, 250, 250),
            //        LinearGradientMode.Vertical);


            e.Graphics.FillRoundedRectangle(new SolidBrush(_bgColor), 0, 0, this.Width - _shadowThickness, this.Height - _shadowThickness, 15);

            //if (_drawDropInHighlight)
            //{
            //    e.Graphics.FillHalfRoundedRectangle(grad_brush, DropInRectangle.X, DropInRectangle.Y, DropInRectangle.Width, DropInRectangle.Height - 10, 15);
            //}


            if (_drawDivider)
            {
                Pen pen = new Pen(new SolidBrush(_dividerColor), 2);

                if (DrawDropInHighlight)
                {
                    pen.DashStyle = DashStyle.Dash;
                }

               

                e.Graphics.DrawLine(pen,
                    _dividerStartPoint,
                    _dividerEndPoint);


                e.Graphics.DrawRoundedRectangle(pen, 10, 10, this.Width - _shadowThickness - 20, this.Height - _shadowThickness - 20, 15);

            }

            // This allows delegates to be called
            base.OnPaint(e);
        }
    }


}
