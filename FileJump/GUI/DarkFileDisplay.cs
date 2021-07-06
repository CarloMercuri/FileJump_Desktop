using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileJump.GUI
{
    public class DarkFileDisplay
    {
        private Size MainSize { get; set; }
        private Bitmap Thumbnail { get; set; }
        private bool Framed { get; set; }

        public Panel panel_Background { get; set; }

        private PictureBox pBox_Thumbnail { get; set; }
        private string FileName { get; set; }

        public DarkFileDisplay(int width, int height, Bitmap thumbnail, bool framed, string fileName)
        {
            MainSize = new Size(width, height);
            Thumbnail = thumbnail;
            Framed = framed;
            FileName = fileName;

            int thumbBottomY = height - (int)((decimal)height / 3.4M);

            panel_Background = new Panel();
            panel_Background.Size = MainSize;

            if (framed)
            {
                panel_Background.BackgroundImage = Properties.Resources.file_cornice;
                panel_Background.BackgroundImageLayout = ImageLayout.Stretch;
            }

            TransparentControl panel_MouseEvents = new TransparentControl();
            panel_MouseEvents.Size = panel_Background.Size;
            panel_MouseEvents.BackColor = Color.Transparent;

            panel_MouseEvents.MouseEnter += (sender, args) =>
            {
                panel_Background.BackColor = Color.FromArgb(100, 188, 212, 218);
            };

            panel_MouseEvents.MouseLeave += (sender, args) =>
            {
                panel_Background.BackColor = Color.Transparent;
            };

            panel_Background.Controls.Add(panel_MouseEvents);


            //
            // Picturebox Thumbnail
            //

            pBox_Thumbnail = new PictureBox();

            int p_width;
            int p_height;

            if(thumbnail.Width >= thumbnail.Height)
            {
                p_width = (int)(((decimal)MainSize.Width / 100M) * 75);
                p_height = (int)(((decimal)MainSize.Height / 100M) * 40);
            }
            else
            {
                decimal newHeight = MainSize.Height - (MainSize.Height - thumbBottomY);
                //p_width = (int)(((decimal)MainSize.Width / 100M) * 40);
                //p_height = (int)(((decimal)MainSize.Height / 100M) * 60);  
                p_width = (int)(((decimal)MainSize.Width / 100M) * 50);
                p_height = (int)((newHeight / 100M) * 85);
            }

            pBox_Thumbnail.Size = new Size(p_width, p_height);
            pBox_Thumbnail.SizeMode = PictureBoxSizeMode.StretchImage;
            pBox_Thumbnail.Location = new Point((panel_Background.Width / 2) - p_width / 2 , thumbBottomY - p_height);

            // Goal: The bottom of the image is always at the same Y coordinate.



            pBox_Thumbnail.Image = ImageEditing.DrawImageScaled(pBox_Thumbnail.Width, pBox_Thumbnail.Height, thumbnail);

            panel_Background.Controls.Add(pBox_Thumbnail);

            //
            // File name label
            //

            Label label_FileName = new Label();
            label_FileName.Font = new Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Pixel);
            label_FileName.ForeColor = Color.FromArgb(255, 142, 149, 174);
            label_FileName.MaximumSize = new Size((int)(((decimal)MainSize.Width / 100M) * 80), MainSize.Height - thumbBottomY - 5);
            label_FileName.AutoSize = false;
            label_FileName.Text = fileName;
            label_FileName.BackColor = Color.Transparent;

            label_FileName.Location = new Point(MainSize.Width / 2 - label_FileName.Width / 2, thumbBottomY + 5);

            panel_Background.Controls.Add(label_FileName);

            // Always as last thing
            panel_MouseEvents.BringToFront();
        }

        public void AddToControl(Control control)
        {
            control.Controls.Add(panel_Background);
        }




    }
}
