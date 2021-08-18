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
        // For waiting state
        private Timer timer { get; set; }
        private int dotsCount { get; set; }
        private string WaitText { get; set; }

        private string _buttonText { get; set; }
        private bool WaitingStatus { get; set; }
        private string OriginalText { get; set; }

        public string ButtonText
        {
            get { return this._buttonText; }
            set { UpdateButtonText(value); }
        }
        private Color _textColor { get; set; }
        public Color TextColor
        {
            get { return this.ForeColor; }
            set { UpdateForeColor(value); }
        }

        

        private Image CustomBackground { get; set; }

        private void UpdateButtonText(string text)
        {
            this._buttonText = text;
            this.Invalidate();
        }
        private void UpdateForeColor(Color color)
        {
            this.ForeColor = color;
            this.Invalidate();
        }

        /// <summary>
        /// Sets the waiting animated text if true, resets it if false.
        /// </summary>
        /// <param name="isWaiting"></param>
        /// <param name="text"></param>
        public void SetWaitingState(bool isWaiting, string text = "")
        {
            WaitingStatus = isWaiting;

            if (isWaiting)
            {
                OriginalText = _buttonText;

                if(text == "")
                {
                    WaitText = "Waiting"; // standard
                } else
                {
                    WaitText = text;
                }

                dotsCount = 1;
                WaitText = text;
                timer.Interval = 400;
                timer.Start();
            } else
            {
                timer.Stop();

                if(text == "")
                {
                    ButtonText = OriginalText;
                } else
                {
                    ButtonText = text;
                }
            }
           
            
        }

        public CustomGeneralButton()
           : base()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            CustomBackground = Properties.Resources.device_panel_normal;
            WaitingStatus = false;
            timer = new Timer();
            timer.Tick += TickTock;
            
        }

        private void TickTock(object sender, EventArgs e)
        {
            string temp = $"{WaitText} ";

            for (int i = 0; i < dotsCount; i++)
            {
                temp += ".";
            }
            ButtonText = temp;

            dotsCount++;
            if (dotsCount > 4) dotsCount = 1;
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
            Size textSize;
            Color textColor = this.ForeColor;

            if (WaitingStatus)
            {
                textColor = Color.Gray;
                textSize = TextRenderer.MeasureText(WaitText, TextFont);
            } else
            {
                textSize = TextRenderer.MeasureText(_buttonText, TextFont);
            }


          

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

            if (this.Enabled)
            {
                e.Graphics.DrawString(_buttonText, this.TextFont, new SolidBrush(textColor), new Point(textX, textY));
            } else
            {
                e.Graphics.DrawString(_buttonText, this.TextFont, new SolidBrush(Color.Gray), new Point(textX, textY));
            }
            

           
            //base.OnPaint(e);
        }

    }
}
