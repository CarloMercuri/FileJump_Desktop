using FileJump.CustomControls;
using FileJump.Network;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileJump.GUI
{
    public class FileUploadVisual
    {
        public RoundedProgressBar bar_Progress { get; set; }

        public Image FileThumbnail { get; set; }
        public Button btn_CheckCross { get; set; }
        public Panel panel_Thumbnail { get; set; }
        public PictureBox pBox_Thumbnail { get; set; }
        public Label label_FileName { get; set; }
        public Panel panel_MouseEvents { get; set; }
        public Panel panel_Background { get; set; }

        private string[] imageExtensions = new string[] { ".jpg", ".jpeg", ".bmp", ".png" };

        public void AddToControl(Control control)
        {
            panel_Background.Controls.Add(bar_Progress);
            panel_Background.Controls.Add(btn_CheckCross);
            panel_Background.Controls.Add(label_FileName);
           // panel_Background.Controls.Add(panel_Thumbnail);
            panel_Background.Controls.Add(pBox_Thumbnail);
           // panel_Background.Controls.Add(panel_MouseEvents);

            //panel_MouseEvents.BringToFront();

            control.Controls.Add(panel_Background);
        }

        public FileUploadVisual(int x, int y, int width, int height, LocalFileStructure fStruct)
        {
            // TEMP
            Size thumbSize = new Size(50, height - 15);

            panel_Background = new Panel()
            {
                BackColor = Color.Transparent,
                Size = new Size(width, height),
                Location = new Point(x, y)
            };

            //
            // bar_Progress
            //

            bar_Progress = new RoundedProgressBar()
            {
                Location = new Point(thumbSize.Width + 20, (int)((decimal)thumbSize.Height / 1.3M)),
                //Size = new Size((int)((decimal)width / 1.5M), 10),
                BorderStyle = BorderStyle.None,
                //BackColor = Color.White,
                BackgroundBarColor = Color.FromArgb(255, 220, 220, 220),
                ProgressBarColor = Color.Green,
                Percentage = 0
            };

            bar_Progress.Size = new Size(width - bar_Progress.Location.X - 20, 10);
            bar_Progress.Percentage = 70;
            

            //bar_Progress = new ProgressBar()
            //{
            //    Location = new Point(thumbSize.Width + 20, (int)((decimal)thumbSize.Height / 1.3M)),
            //    //Size = new Size((int)((decimal)width / 1.5M), 10),
            //    BackColor = Color.White,

            //};
            //bar_Progress.Maximum = 100;
            //bar_Progress.Value = 50;
            //bar_Progress.Size = new Size(width - bar_Progress.Location.X - 20, 10);

            //
            // Thumbnail
            //

            if (imageExtensions.Contains(fStruct.FileExtension.ToLower()))
            {
                // Create the thumbnail
                Bitmap img = new Bitmap(fStruct.FilePath);
                FileThumbnail = ImageEditing.DrawImageScaled(thumbSize.Width, thumbSize.Height, img);

                img.Dispose();
            }
            else
            {
                FileThumbnail = Icon.ExtractAssociatedIcon(fStruct.FilePath).ToBitmap();
            }

            pBox_Thumbnail = new PictureBox()
            {
                Size = thumbSize,
                Location = new Point(5, 7),
                Image = ImageEditing.AddThumbnailShadow((Bitmap)FileThumbnail, Properties.Resources.shadow_base_full),
                SizeMode = PictureBoxSizeMode.Zoom
            };

            //
            // btn_CheckCross
            //

            btn_CheckCross = new Button()
            {
                BackgroundImage = Properties.Resources.TransferResult_CrossThick,
                BackgroundImageLayout = ImageLayout.Zoom,
                Size = new Size(25, 25),
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
            };



            //
            // label_FileName
            //

            label_FileName = new Label()
            {
                Font = new Font("Bahnschrift", 12),
                Location = new Point(bar_Progress.Location.X - 3, bar_Progress.Location.Y - 25),
                ForeColor = Color.FromArgb(200, 80, 80, 80),
                Size = new Size(bar_Progress.Width - btn_CheckCross.Width - 10, 50)
            };

            // Automatically adjust the text lenght in relation to the label width. Dynamic
            label_FileName.Text = GUITools.FitTextLenghtToLabelSize(fStruct.FullName, label_FileName);

            //Console.WriteLine($"Width of: {label_FileName.Text}: {size.Width}");
            

            btn_CheckCross.Location = new Point(bar_Progress.Location.X + bar_Progress.Size.Width - btn_CheckCross.Size.Width,
                     label_FileName.Location.Y - 5);

            btn_CheckCross.FlatAppearance.BorderSize = 0;


        }
    }
}
