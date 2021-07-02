using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileJump.Forms
{
    public partial class TestForm : Form
    {
        int start_angle = 90;
        int sweep_angle = 0;
        int percent = 0;

        Color color = Color.Black;


        public TestForm()
        {
            InitializeComponent();

            //Image thumb = Image.FromFile("C:/back/shadow1.png");
            //Bitmap shadow_base = (Bitmap)Bitmap.FromFile("C:/back/shadow_base_full.png");


            //Bitmap bmp = ImageEditing.AddThumbnailShadow((Bitmap)thumb, shadow_base, panel_TestShadow.Width, panel_TestShadow.Height);
            //panel_TestShadow.BackgroundImage = bmp;
            //panel_TestShadow.BackgroundImageLayout = ImageLayout.Zoom;
        }

        private void TestPaint(object sender, PaintEventArgs e)
        {
            // Create pen.
            Pen blackPen = new Pen(color, 3);

            // Create rectangle to bound ellipse.
            Rectangle rect = new Rectangle(20, 10, 30, 30);

            // Create start and sweep angles on ellipse.
            float startAngle = 90;
            float sweepAngle = 360;

            // Draw arc to screen.
            e.Graphics.DrawArc(blackPen, rect, startAngle, sweepAngle);
        }

        private void StartAngle_ValueChange(object sender, EventArgs e)
        {
            start_angle = (int)StartAngleInput.Value;
            panel_Paint.Invalidate();
        }

        private void SweepAngle_ValueChange(object sender, EventArgs e)
        {
            sweep_angle = (int)SweepAngleInput.Value;
            panel_Paint.Invalidate();
        }

        private void percentchange(object sender, EventArgs e)
        {
            sweep_angle = (int)(numericUpDown1.Value * 3.6M);
            panel_Paint.Invalidate();
        }

        private void btn_ColorPicker_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                btn_ColorPicker.BackColor = colorDialog1.Color;
                color = colorDialog1.Color;
                panel_Paint.Invalidate();
            }
        }
    }
}
