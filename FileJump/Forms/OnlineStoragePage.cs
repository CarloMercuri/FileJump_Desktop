using FileJump.GUI;
using FileJump.Network;
using FileJump.Settings;
using FileJump_Network;
using FileJump_Network.EventSystem;
using FileJump_Network.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileJump.Forms
{
    public partial class OnlineStoragePage : Form
    {

        List<FileVisualDisplay> CurrentShownFiles = new List<FileVisualDisplay>();

        List<OnlineFileStructure> FileDataList;

        FlowLayoutPanel panel_FlowLayout;

        Color IconSelectedColor = Color.CadetBlue;

        int LastSelectedIcon { get; set; }

        bool DownloadAllowed { get; set; }

        bool IsDownloading { get; set; }

        Bitmap shadow_base;


        public OnlineStoragePage()
        {
            InitializeComponent();

            shadow_base = (Bitmap)Image.FromFile("C:/back/shadow_base_full.png");

            check_DeleteAfterDownload.Checked = true;

            CreateFileVisual();

            GetOnlineFiles();

            panel_MainFileVisual.Paint += MainFilePanelPaint;

            panel_MainFileVisual.Invalidate();

            ApiCommunication.FileDownloadProgress += FileDownloadProgressUpdate;

            ApiCommunication.FileDownloadSuccessful += FileDownloadSuccessful;
            ApiCommunication.FileDeletedResponse += FileDeletedResponse;

            

        }


        private void FileDeletedResponse(object sender, FileDeleteRequestEventArgs e)
        {
            Console.WriteLine("delete event id " + e.ID);
            if (!e.Successful)
            {
                return;
            }

            if(CurrentShownFiles[e.ID] == null)
            {
                return;
            }

            CurrentShownFiles[e.ID].panel_Parent.Visible = false;
            CurrentShownFiles[e.ID].CurrentState = FileStatus.Deleted;
        }

        private void ReloadFilesList()
        {
            ResetFilesList();
            GetOnlineFiles();
        }

        private void ResetFilesList()
        {
            panel_FlowLayout.Controls.Clear();

            CurrentShownFiles = new List<FileVisualDisplay>();
        }

        private async void FileDownloadSuccessful(object sender, FileDownloadResultEventArgs e)
        {
            CurrentShownFiles[e.ID].progress_Download.Visible = false;
            CurrentShownFiles[e.ID].panel_CheckMark.Visible = true;
            CurrentShownFiles[e.ID].panel_CheckMark.Invalidate();
            CurrentShownFiles[e.ID].CurrentState = FileStatus.Finished;

            if (check_DeleteAfterDownload.Checked)
            {
                if(CurrentShownFiles[e.ID].CurrentState != FileStatus.Deleted)
                {
                    bool success = await ApiCommunication.DeleteFileRequest(CurrentShownFiles[e.ID].FileStructOnline.FullName, UserSettings.UserAccessToken, e.ID);
                }

            }

            DownloadNextFile();
        }

        private void FileDownloadProgressUpdate(object sender, FileTransferProgressEventArgs e)
        {
            CurrentShownFiles[e.ID].UpdateProgress(e.PercentProgress);
        }

        private void ChangeSelectedStatus(FileVisualDisplay vis)
        {
            if (vis.IsSelected)
            {
                vis.panel_Parent.BackColor = IconSelectedColor;
            }
            else
            {
                vis.panel_Parent.BackColor = Color.Transparent;
            }
        }

        private void InvertSelectedStatus(int id)
        {
            CurrentShownFiles[id].IsSelected = !CurrentShownFiles[id].IsSelected;

            ChangeSelectedStatus(CurrentShownFiles[id]);
        }

        private void IconPressed(FileVisualDisplay vis)
        {
            if(Control.ModifierKeys == Keys.Shift)
            {
                for (int i = LastSelectedIcon + 1; i <= vis.ID; i++)
                {
                    InvertSelectedStatus(i);
                }

                return;
            }

            if(Control.ModifierKeys == Keys.Control)
            {
                if (vis.IsSelected)
                {
                    vis.IsSelected = false;
                    ChangeSelectedStatus(vis);
                }
                else
                {
                    vis.IsSelected = true;
                    ChangeSelectedStatus(vis);
                }

                return;
            }

            // if no keys

            vis.IsSelected = true;
            ChangeSelectedStatus(vis);

            for (int i = 0; i < CurrentShownFiles.Count; i++)
            {
                if(CurrentShownFiles[i] == null || CurrentShownFiles[i].CurrentState == FileStatus.Deleted)
                {
                    continue;
                }

                if(vis.ID != i)
                {
                    CurrentShownFiles[i].IsSelected = false;
                    ChangeSelectedStatus(CurrentShownFiles[i]);
                }


            }

           

            LastSelectedIcon = vis.ID;

        }

        private void DownloadNextFile()
        {
            if (!DownloadAllowed)
            {
                return;
            }

            for (int i = 0; i < CurrentShownFiles.Count; i++)
            {
                if(CurrentShownFiles[i] == null || CurrentShownFiles[i].CurrentState == FileStatus.Deleted)
                {
                    continue;
                }

                FileVisualDisplay vis = CurrentShownFiles[i];

                if (vis.IsSelected)
                {
                    if(vis.CurrentState == FileStatus.Finished)
                    {
                        return;
                    }

                    vis.CurrentState = FileStatus.QueuedForDownload;
                    StartFileDownload(i);
                    vis.IsSelected = false;
                    ChangeSelectedStatus(vis);
                    return;
                }
            }

            btn_DownloadSelected.Text = "Download Selected";
            btn_DownloadSelected.ForeColor = Color.Black;
        }

        private async void StartFileDownload(int id)
        {
            CurrentShownFiles[id].progress_Download.Visible = true;
            bool success = await ApiCommunication.DownloadFile(CurrentShownFiles[id].FileStructOnline.FullName, id, UserSettings.UserAccessToken);
        }


        private async void GetOnlineFiles()
        {
            FileDataList = await ApiCommunication.RequestHostedFilesList(UserSettings.UserAccessToken);

            if (FileDataList == null)
            {
                return;
            }

            foreach (OnlineFileStructure f in FileDataList)
            {
                AddFileVisual(f);
            }

            GetThumbnails();

        }

        private async void GetThumbnails()
        {
            if(FileDataList == null)
            {
                return;
            }

            for (int i = 0; i < CurrentShownFiles.Count; i++)
            {
                if(CurrentShownFiles[i] == null || CurrentShownFiles[i].CurrentState == FileStatus.Deleted)
                {
                    continue;
                }

                FileVisualDisplay fVis = CurrentShownFiles[i];

                if (fVis.FileStructOnline.Thumbnail.Length > 0)
                {
                    byte[] thumbnailBytes = await ApiCommunication.GetThumbnail(fVis.FileStructOnline.Thumbnail, UserSettings.UserAccessToken);

                    if (thumbnailBytes == null)
                    {
                        Image thumb = CreateThumbnailForFile(fVis.FileStructOnline.FileExtension);
                        fVis.panel_Thumbnail.BackgroundImage = thumb;
                        continue;
                    }

                    Image thumbnail = Image.FromStream(new MemoryStream(thumbnailBytes));

                    if(fVis != null)
                    {
                        fVis.panel_Thumbnail.BackgroundImage = ImageEditing.AddThumbnailShadow((Bitmap)thumbnail, shadow_base);
                    }
 
                }
                else
                {
                    Image thumb = CreateThumbnailForFile(fVis.FileStructOnline.FileExtension);
                    fVis.panel_Thumbnail.BackgroundImage = thumb;
                }
            }

            //foreach(FileVisualDisplay fVis in CurrentShownFiles)
            //{
            //    if(fVis.FileStructOnline.Thumbnail.Length > 0)
            //    {
            //        byte[] thumbnailBytes = await ApiCommunication.GetThumbnail(fVis.FileStructOnline.Thumbnail, UserSettings.UserAccessToken);

            //        if (thumbnailBytes == null)
            //        {
            //            Image thumb = CreateThumbnailForFile(fVis.FileStructOnline.FileExtension);
            //            fVis.panel_Thumbnail.BackgroundImage = thumb;
            //            continue;
            //        }

            //        Image thumbnail = Image.FromStream(new MemoryStream(thumbnailBytes));

            //        fVis.panel_Thumbnail.BackgroundImage = thumbnail;
            //    }
            //    else
            //    {
            //        Image thumb = CreateThumbnailForFile(fVis.FileStructOnline.FileExtension);
            //        fVis.panel_Thumbnail.BackgroundImage = thumb;
            //    }
            //}

        
        }

        private Image CreateThumbnailForFile(string fileExtension)
        {
            return null;
        }

        private void MainFilePanelPaint(object sender, PaintEventArgs e)
        {
            int width = 3;

            ControlPaint.DrawBorder(e.Graphics, this.panel_MainFileVisual.ClientRectangle,
                  Color.FromArgb(255, 58, 175, 118), width, ButtonBorderStyle.Solid,   // left
                  Color.FromArgb(255, 58, 175, 118), width, ButtonBorderStyle.Solid,               // top
                  Color.FromArgb(255, 58, 175, 118), width, ButtonBorderStyle.Solid,    // right
                  Color.FromArgb(255, 58, 175, 118), width, ButtonBorderStyle.Solid);  // bottom
        }



        private void CreateFileVisual()
        {
            //panel_FlowLayout = new FlowLayoutPanel()
            //{
            //    Size = panel_MainFileVisual.Size,
            //    Location = new Point(0, 0),
            //    BackColor = Color.FloralWhite,
            //    AutoScroll = true,
            //    BorderStyle = BorderStyle.Fixed3D
            //};

            panel_FlowLayout = new FlowLayoutPanel()
            {
                Size = new Size(panel_MainFileVisual.Width - 10, panel_MainFileVisual.Height - 10),
                Location = new Point(5, 5),
                BackColor = Color.White,
                //BackColor = Color.FromArgb(255, 183, 210, 197),
                AutoScroll = true,
                BorderStyle = BorderStyle.None
            };


            panel_MainFileVisual.Controls.Add(panel_FlowLayout);
        }

        //private void testPaint(object sender, PaintEventArgs e)
        //{
        //    ControlPaint.DrawBorder(e.Graphics, this.panel_Test.ClientRectangle,
        //        Color.Red, ButtonBorderStyle.Solid);
        //}

        private void file_mouseLeave(FileVisualDisplay vis)
        {

            if (!vis.IsSelected)
            {
                vis.panel_Parent.BackColor = Color.Transparent;
            }

        }

        private void file_mouseEnter(FileVisualDisplay vis)
        {
            if (!vis.IsSelected)
            {
                vis.panel_Parent.BackColor = IconSelectedColor;
            }

        }

        private void AddFileVisual(OnlineFileStructure _fileStruct)
        {
            FileVisualDisplay fileVis = new FileVisualDisplay();

            fileVis.FileStructOnline = _fileStruct;

            fileVis.panel_Parent = new Panel()
            {
                Size = new Size(75, 75),
                TabIndex = 1,
                Location = new Point(400, 245)
            };

            //this.Controls.Add(fileVis.panel_Parent);
            panel_FlowLayout.Controls.Add(fileVis.panel_Parent);

            fileVis.panel_MouseEvents = new TransparentControl()
            {
                Size = new Size(fileVis.panel_Parent.Width, fileVis.panel_Parent.Height),

            };

           

            // At the end need to push it to the top with BringToFront();
            fileVis.panel_Parent.Controls.Add(fileVis.panel_MouseEvents);

            fileVis.panel_MouseEvents.MouseEnter += (sender, args) =>
            {
                file_mouseEnter(fileVis);
            };

            fileVis.panel_MouseEvents.MouseLeave += (sender, args) =>
            {
                file_mouseLeave(fileVis);
            };

            fileVis.ID = CurrentShownFiles.Count;

            fileVis.panel_MouseEvents.Click += (sender, args) =>
            {
                IconPressed(fileVis);
            };


            fileVis.panel_Thumbnail = new Panel()
            {
                BackgroundImageLayout = ImageLayout.Zoom,
                Size = new Size(Convert.ToInt32(fileVis.panel_Parent.Width / 1.8f), Convert.ToInt32(fileVis.panel_Parent.Height / 1.5f)),
                //BackColor = Color.FromArgb(255, 240, 240, 240)
                BackColor = Color.Transparent,
            };

            fileVis.panel_Thumbnail.Location = new Point((fileVis.panel_Parent.Width / 2) - (fileVis.panel_Thumbnail.Width / 2),
                3);

            fileVis.panel_Parent.Controls.Add(fileVis.panel_Thumbnail);


            fileVis.label_FileName = new Label()
            {
                Name = "label_FileName",
                AutoSize = true,
                Size = new Size(60, 15),
                MaximumSize = new Size(60, 200),
                TextAlign = ContentAlignment.MiddleCenter,
                Text = _fileStruct.FullName,
                Location = new Point(15, fileVis.panel_Thumbnail.Height + 3)
            };


            fileVis.label_FileName.Text = GUITools.ShortenFileName(_fileStruct.FullName, 9);

            fileVis.panel_Parent.Controls.Add(fileVis.label_FileName);

            fileVis.progress_Download = new ProgressBar()
            {
                BackColor = Color.Red,
                ForeColor = Color.Green,
                Minimum = 0,
                Maximum = 100,
                Size = new Size(fileVis.panel_Thumbnail.Width, 8),
                Value = 0
            };

            fileVis.progress_Download.Style = ProgressBarStyle.Blocks;
            fileVis.progress_Download.Visible = false;

            fileVis.progress_Download.Location = new Point(fileVis.panel_Thumbnail.Location.X, fileVis.panel_Parent.Height - fileVis.progress_Download.Height);

            fileVis.panel_Parent.Controls.Add(fileVis.progress_Download);

            fileVis.panel_CheckMark = new TransparentControl()
            {
                Size = fileVis.panel_Parent.Size,
            };

            fileVis.panel_CheckMark.Paint += (sender, args) =>
            {
                Pen pen = new Pen(new SolidBrush(Color.FromArgb(255, 0, 255, 0)), 5);
                pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

                int startx = 23;

                args.Graphics.DrawLine(pen, startx, 20, startx + 10, 35);
                args.Graphics.DrawLine(pen, startx + 10, 35, startx + 30, 10);

            };

            fileVis.panel_Parent.Controls.Add(fileVis.panel_CheckMark);
            fileVis.panel_CheckMark.BringToFront();
            fileVis.panel_CheckMark.Visible = false;

            fileVis.panel_MouseEvents.BringToFront();

            CurrentShownFiles.Add(fileVis);


        }

        private void test_mouseEnter(object sender, EventArgs e)
        {
            //panel_Test.BackColor = Color.AliceBlue;
            
        }

        private void test_mouseLeave(object sender, EventArgs e)
        {
            //panel_Test.BackColor = Color.White;
        }

        private void btn_DownloadSelected_Click(object sender, EventArgs e)
        {
            if (IsDownloading)
            {
                DownloadAllowed = false;
                IsDownloading = false;
                btn_DownloadSelected.Text = "Download Selected";
                btn_DownloadSelected.ForeColor = Color.Black;
            }
            else
            {
                DownloadAllowed = true;
                IsDownloading = true;
                btn_DownloadSelected.Text = "X Cancel download";
                btn_DownloadSelected.ForeColor = Color.Red;
                DownloadNextFile();
            }

        }

        private void btn_SelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < CurrentShownFiles.Count; i++)
            {
                if(CurrentShownFiles[i] == null || CurrentShownFiles[i].CurrentState == FileStatus.Deleted)
                {
                    continue;
                }

                CurrentShownFiles[i].IsSelected = true;
                ChangeSelectedStatus(CurrentShownFiles[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReloadFilesList();   
        }

        private async void btn_DeleteFiles_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < CurrentShownFiles.Count; i++)
            {
                if(CurrentShownFiles[i] == null || CurrentShownFiles[i].CurrentState == FileStatus.Deleted)
                {
                    continue;
                }

                if (CurrentShownFiles[i].IsSelected)
                {
                    bool success = await ApiCommunication.DeleteFileRequest(CurrentShownFiles[i].FileStructOnline.FullName, UserSettings.UserAccessToken, i);
                }


            }
        }

        private void Event_FormClosing(object sender, FormClosingEventArgs e)
        {
            ApiCommunication.FileDownloadProgress -= FileDownloadProgressUpdate;

            ApiCommunication.FileDownloadSuccessful -= FileDownloadSuccessful;

            ApiCommunication.FileDeletedResponse -= FileDeletedResponse;
        }
    }
}
