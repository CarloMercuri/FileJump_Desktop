using FileJump.CustomControls;
using FileJump.Network;
using FileJump_Network.Interfaces;
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
        public LocalFileStructure FileStructure { get; set; }
        private Size MainSize { get; set; }
        private Bitmap Thumbnail { get; set; }
        private bool Framed { get; set; }

        private Panel panel_Background { get; set; }

        private CustomProgressBar progress_Download { get; set; }

        private PictureBox pBox_Thumbnail { get; set; }
        private string FileName { get; set; }

        private bool PaintBorder { get; set; }

        private Color MouseOverColor = Color.FromArgb(100, 229, 243, 255);
        private Color SelectedColor = Color.FromArgb(100, 204, 232, 255);
        private Color BorderColor = Color.FromArgb(255, 153, 209, 255);



        private bool _Selected;
        public bool IsSelected
        {
            get { return _Selected; }
            set { ChangeSelectedStatus(value); }
        }

        private List<Action> ClickActionsList = new List<Action>();

        public DarkFileDisplay(int width, int height, Bitmap thumbnail, bool framed, string fileName, Control target)
        {
            MainSize = new Size(width, height);
            Thumbnail = thumbnail;
            Framed = framed;
            FileName = fileName;



            int thumbBottomY = height - (int)((decimal)height / 3.4M);

            panel_Background = new Panel();
            panel_Background.Size = MainSize;
            panel_Background.Paint += PaintBackgroundPanel;

            target.Controls.Add(panel_Background);

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
                if (!IsSelected)
                {
                    panel_Background.BackColor = MouseOverColor;
                }
                else
                {
                    PaintBorder = true;
                    panel_Background.Invalidate();
                }

            };

            panel_MouseEvents.MouseLeave += (sender, args) =>
            {
                if (!IsSelected)
                    panel_Background.BackColor = Color.Transparent;

                PaintBorder = false;
                panel_Background.Invalidate();
            };

            panel_MouseEvents.MouseClick += (sender, args) =>
            {
                foreach (Action a in ClickActionsList)
                {
                    a.Invoke();
                }
            };

            panel_Background.Controls.Add(panel_MouseEvents);


            //
            // Picturebox Thumbnail
            //

            pBox_Thumbnail = new PictureBox();

            int p_width;
            int p_height;

            if (thumbnail.Width > thumbnail.Height)
            {
                p_width = (int)(((decimal)MainSize.Width / 100M) * 75);
                p_height = (int)(((decimal)MainSize.Height / 100M) * 40);
            }
            else if (thumbnail.Width < thumbnail.Height)
            {
                decimal newHeight = MainSize.Height - (MainSize.Height - thumbBottomY);
                //p_width = (int)(((decimal)MainSize.Width / 100M) * 40);
                //p_height = (int)(((decimal)MainSize.Height / 100M) * 60);  
                p_width = (int)(((decimal)MainSize.Width / 100M) * 50);
                p_height = (int)((newHeight / 100M) * 85);
            }
            else
            {
                p_width = (int)(((decimal)MainSize.Width / 100M) * 60);
                p_height = (int)(((decimal)MainSize.Height / 100M) * 60);
            }

            pBox_Thumbnail.Size = new Size(p_width, p_height);
            pBox_Thumbnail.SizeMode = PictureBoxSizeMode.StretchImage;
            pBox_Thumbnail.Location = new Point((panel_Background.Width / 2) - p_width / 2, thumbBottomY - p_height);

            // Goal: The bottom of the image is always at the same Y coordinate.

            pBox_Thumbnail.Image = ImageEditing.DrawImageScaled(pBox_Thumbnail.Width, pBox_Thumbnail.Height, thumbnail);

            //pBox_Thumbnail.Image = ImageEditing.DrawImageScaled(pBox_Thumbnail.Width, pBox_Thumbnail.Height, thumbnail);
            // pBox_Thumbnail.Image = thumbnail;

            panel_Background.Controls.Add(pBox_Thumbnail);

            //
            // File name label
            //

            Label label_FileName = new Label();
            label_FileName.Font = new Font("Arial", 11, FontStyle.Regular, GraphicsUnit.Pixel);
            label_FileName.ForeColor = GUITools.COLOR_DarkMode_Text_Bright;
            label_FileName.MaximumSize = new Size((int)(((decimal)MainSize.Width / 100M) * 80), MainSize.Height - thumbBottomY - 5);
            label_FileName.AutoSize = false;
            label_FileName.Text = GUITools.FitTextLenghtToLabelSize(fileName, label_FileName);
            label_FileName.BackColor = Color.Transparent;

            label_FileName.Location = new Point(MainSize.Width / 2 - label_FileName.Width / 2, thumbBottomY + 5);

            panel_Background.Controls.Add(label_FileName);

            progress_Download = new CustomProgressBar()
            {
                Size = new Size(width, 8),
                Location = new Point(0, 0),
            };

            progress_Download.BackgroundBarColor = GUITools.COLOR_DarkMode_Light;
            progress_Download.ProgressBarColor = Color.Green;
            progress_Download.Percentage = 0;


            progress_Download.Visible = true;

            panel_Background.Controls.Add(progress_Download);



            // Always as last thing
            panel_MouseEvents.BringToFront();
        }

        public void CreateThumbnails()
        {

        }


        private void PaintBackgroundPanel(object sender, PaintEventArgs e)
        {
            if (PaintBorder)
            {
                e.Graphics.DrawRectangle(new Pen(BorderColor, 2), new Rectangle(0, 0, panel_Background.Width, panel_Background.Height));
            }
        }

        public void UpdateProgress(int progress)
        {
            progress_Download.Percentage = progress;
        }

        public void TransferFinished(OutTransferEventArgs e)
        {
            FileStructure.FileStatus = FileStatus.Finished;

            if (progress_Download.InvokeRequired)
            {
                progress_Download.Invoke(
                    new MethodInvoker(
                    delegate () { progress_Download.Visible = false; }));
            } else
            {
                progress_Download.Visible = false;
            }



            Panel check = new Panel();
            check.Size = new Size(10, 10);
            check.Location = new Point(panel_Background.Width / 2 - check.Width / 2, 0);

            if (e.IsSuccessful)
            {
                check.BackgroundImage = Properties.Resources.TransferResult_CheckMark;
            }
            else
            {
                check.BackgroundImage = Properties.Resources.TransferResult_Cross;
            }

            check.BackgroundImageLayout = ImageLayout.Stretch;

            if (panel_Background.InvokeRequired)
            {
                panel_Background.Invoke(
                    new MethodInvoker(
                    delegate () { panel_Background.Controls.Add(check); }));
            } else
            {
                panel_Background.Controls.Add(check);
            }

           
        }

        public void ActionOnClick(System.Action action)
        {
            ClickActionsList.Add(action);
        }

        private void ChangeSelectedStatus(bool value)
        {
            _Selected = value;

            if (_Selected)
            {
                panel_Background.BackColor = SelectedColor;
            }
            else
            {
                panel_Background.BackColor = Color.Transparent;
            }
        }



        public void AddToControl(Control control)
        {
            control.Controls.Add(panel_Background);
        }




    }
}
