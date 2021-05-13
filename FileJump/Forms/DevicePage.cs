using FileJump.Network;
using FileJump.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileJump
{
    public partial class DevicePage : Form
    {
        MainPage mainPage;
        Panel DragDropPanel;
        FlowLayoutPanel PanelFlowLayout;
        Button Send_Button;
        List<FileQueueItem> CurrentSelectedFiles = new List<FileQueueItem>();
        NetworkDevice targetDevice;
        int SelectedFileVisual = -1;

        Panel panel_TextInput;

        // Logic
        private GUIState _GUIState;

        public int MaxConcurrentTransfers;

        private int ActiveTransfersCount;

        string[] imageExtensions = new string[] { ".jpg", ".jpeg", ".bmp", ".png" };


        bool IsDragging = false;

        public DevicePage(NetworkDevice device, MainPage mainPageForm)
        {
            _GUIState = GUIState.WaitingForInput;
            targetDevice = device;
            
            InitializeComponent();
            mainPage = mainPageForm;
            CreateDragAndDropVisual();

            DataProcessor.OutboundTransferFinished += Transferfinished;
            DataProcessor.OutboundTransferStarted += TransferStarted;


            MaxConcurrentTransfers = 4;
            ActiveTransfersCount = 0;

           

            

            
        }


        private void CreateDragAndDropVisual()
        {
            DragDropPanel = new Panel()
            {
                Size = new Size(500, 330),
                Location = new Point(41, 33),

                BackgroundImage = Resources.DragDropBackground,
                BackgroundImageLayout = ImageLayout.Stretch,
                AllowDrop = true,

            };

            DragDropPanel.DragEnter += new DragEventHandler(DragDrop_Enter);
            DragDropPanel.DragLeave += new EventHandler(DragDrop_Leave);
            DragDropPanel.DragDrop += new DragEventHandler(DragDrop_Drop);
            DragDropPanel.Paint += new PaintEventHandler(DragDrop_Paint);

            Button fromDeviceBtn = new Button()
            {
                Location = new Point(138, 190),
                Size = new Size(221, 32),
                BackColor = Color.FromArgb(100, 0, 190, 115),
                Text = "Or choose from your device",
            };

            fromDeviceBtn.Click += btn_ChooseFromDevice_Click;

            Label textLabel = new Label()
            {
                Location = new Point(185, 170),
                Text = "Drag file(s) here...",
                Size = new Size(140, 15),
                BackColor = Color.Transparent,
                Font = new Font("Serif", 12, FontStyle.Bold, GraphicsUnit.Pixel)
                
            };


            DragDropPanel.Controls.Add(textLabel);

            DragDropPanel.Controls.Add(fromDeviceBtn);

            this.Controls.Add(DragDropPanel);

            // Text input

            panel_TextInput = new Panel()
            {
                Location = new Point(41, DragDropPanel.Height + 40),
                BackColor = Color.DarkGray,
                Size = new Size(DragDropPanel.Width / 2 + 100, 60),
                
                
            };

            Label lbl_text = new Label()
            {
                Location = new Point(0, 20),
                Text = "Or send a text message / link!",
                Size = new Size(300, 30),
                Font = new Font("Arial", 9, FontStyle.Regular)
            };

            TextBox tBox = new TextBox()
            {
                Location = new Point(0, 40),
                Width = panel_TextInput.Width - 40,
                Height = 40,
                Font = new Font("Arial", 12, FontStyle.Regular)

            };


            Button btn_Send = new Button()
            {
                Location = new Point(tBox.Location.X + tBox.Width, 39),
                Text = "Send",
                Font = new Font("Arial", 10, FontStyle.Regular),
                Width = panel_TextInput.Width - tBox.Width
            };

            this.AcceptButton = btn_Send;

            btn_Send.Click += (sender, args) =>
            {
                if(tBox.Text == "")
                {
                    return;
                }

                SendTextMessage(tBox.Text);
                tBox.Text = "";

            };

            panel_TextInput.Controls.Add(tBox);
            panel_TextInput.Controls.Add(lbl_text);
            this.Controls.Add(panel_TextInput);

        }

        
        private void SendTextMessage(string msg)
        {
            DataProcessor.SendTextMessage(msg, targetDevice.EndPoint);
        }

        private void TextBoxKeyUp(Keys key, string msg)
        {
            if(key == Keys.Enter)
            {
                SendTextMessage(msg);
            }

        }



        private bool ThumbnailCallback()
        {
            return true;
        }

        private void CreateFileQueueVisual()
        {
            DragDropPanel.Dispose();

            PanelFlowLayout = new FlowLayoutPanel()
            {
                Size = new Size(510, 330),
                Location = new Point(41, 33),
                BackColor = Color.FloralWhite,
                AutoScroll = true,
                BorderStyle = BorderStyle.Fixed3D
            };

            this.Controls.Add(PanelFlowLayout);

            Send_Button = new Button()
            {
                Size = new Size(100, 50),
                Font = new Font("Serif", 12, FontStyle.Bold, GraphicsUnit.Pixel),
                Text = "Send File(s)",
                BackColor = Color.FromArgb(100, 202, 188, 153),
                FlatStyle = FlatStyle.Popup,
                Location = new Point(this.Width - 120, this.Height - 100)
            };

            Send_Button.Click += SendButtonClicked;

            this.Controls.Add(Send_Button);
        }

       
        private void SendButtonClicked(object sender, EventArgs e)
        {
            // Check if there are files currently queued
            if(CurrentSelectedFiles.Count <= 0)
            {
                return;
            }

            // And the transfer processe(s) are not currently running.
            // The button is supposed to gray out when this is true, but you never know
            if(_GUIState == GUIState.TransfersRunning)
            {
                return;
            }

            List<FileStructure> fList = new List<FileStructure>();

            // Sift through the files to see if there are some waiting to be sent
            for (int i = 0; i < CurrentSelectedFiles.Count; i++)
            {
                if(CurrentSelectedFiles[i].CurrentState == FileQueueState.Inactive)
                {
                    fList.Add(CurrentSelectedFiles[i].fileStruct);
                }

            }

            DataProcessor.SendFiles(fList, targetDevice.EndPoint);

        }


        private void AddNewQueuedFile(FileStructure file_struct, int id)
        {
            FileQueueItem fileVis = new FileQueueItem();
            fileVis.ID = id;
            fileVis.fileStruct = file_struct;

            if (PanelFlowLayout == null)
            {
                return;
            }

            fileVis.panel_Parent = new Panel()
            {
                Name = "Parent Panel",
                Size = new Size(90, 100),
                BackColor = Color.Transparent
            };


            fileVis.pBox_Icon = new PictureBox()
            {
                Size = new Size(50, 50),
                Location = new Point(18, 20),
                SizeMode = PictureBoxSizeMode.StretchImage,
                //Image = Icon.ExtractAssociatedIcon(fileStruct.FilePath).ToBitmap(),
            };

            fileVis.pBox_Checkmark = new PictureBox()
            {
                Size = new Size(50, 50),
                Location = new Point(0, 0),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.Transparent,
                BorderStyle = BorderStyle.None,

            };

            fileVis.pBox_Icon.Click += (sender, args) =>
            {
                ThumbnailClicked(fileVis.ID);
            };

            if (imageExtensions.Contains(file_struct.FileExtension.ToLower()))
            {
                // Create the thumbnail
                Bitmap img = new Bitmap(file_struct.FilePath);
                fileVis.pBox_Icon.Image = DrawImageScaled(fileVis.pBox_Icon.Width, fileVis.pBox_Icon.Height, ref img);

                img.Dispose();
            }
            else
            {
                fileVis.pBox_Icon.Image = Icon.ExtractAssociatedIcon(file_struct.FilePath).ToBitmap();
            }

            // The Checkmark picture box needs to be added to the controls of the Icon pb. That's so that 
            // the transparency works
            fileVis.panel_Parent.Controls.Add(fileVis.pBox_Icon);
            fileVis.pBox_Icon.Controls.Add(fileVis.pBox_Checkmark);


            fileVis.btn_Delete = new Button()
            {
                Size = new Size(15, 20),
                Text = "X",
                TextAlign = ContentAlignment.TopCenter,
                //Font = new Font("Serif", 12, FontStyle.Bold, GraphicsUnit.Pixel),
                Location = new Point(fileVis.pBox_Icon.Location.X + 15, fileVis.pBox_Icon.Location.Y - 22)
            };


            fileVis.label_FileName = new Label()
            {
                Name = "label_FileName",
                AutoSize = false,
                Size = new Size(60, 15),
                MinimumSize = new Size(40, 10),
                MaximumSize = new Size(60, 200),
                TextAlign = ContentAlignment.MiddleCenter,
                Text = file_struct.FileName + file_struct.FileExtension,
                Location = new Point(fileVis.pBox_Icon.Location.X, fileVis.pBox_Icon.Location.Y + 50)
            };

            string name = file_struct.FileName + file_struct.FileExtension;

            fileVis.label_FileName.Text = ShortenFileName(name, 6);
            

            fileVis.panel_Parent.Controls.Add(fileVis.label_FileName);

            fileVis.panel_Parent.Controls.Add(fileVis.btn_Delete);
            fileVis.CurrentState = FileQueueState.Inactive;

            PanelFlowLayout.Controls.Add(fileVis.panel_Parent);

            CurrentSelectedFiles.Add(fileVis);
        }

        private string ShortenFileName(string original, int maxLenght)
        {
            if (original.Length > 6)
            {
                return original.Substring(0, 5) + "..";
            }
            else
            {
                return original;
            }
        }


        private void TransferStarted(object sender, OutTransferEventArgs args)
        {
            for (int i = 0; i < CurrentSelectedFiles.Count; i++)
            {
                if(CurrentSelectedFiles[i].fileStruct.FilePath == args.FilePath)
                {
                    //CurrentSelectedFiles[i].panel_Parent.BackColor = Color.Yellow;
                }
            }
        }

        /// <summary>
        /// Called when a transfer has finished
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void Transferfinished(object sender, OutTransferEventArgs args)
        {

            if(args.IsSuccessful)
            {
                for (int i = 0; i < CurrentSelectedFiles.Count; i++)
                {
                    if (CurrentSelectedFiles[i].fileStruct.FilePath == args.FilePath)
                    {
                        CurrentSelectedFiles[i].panel_Parent.BackColor = Color.Transparent;
                        CurrentSelectedFiles[i].CurrentState = FileQueueState.Finished;
                        CurrentSelectedFiles[i].pBox_Checkmark.Image = Resources.TransferResult_CheckMark;

                    }
                }
            }
            else
            {
                for (int i = 0; i < CurrentSelectedFiles.Count; i++)
                {
                    if (CurrentSelectedFiles[i].fileStruct.FilePath == args.FilePath)
                    {
                        CurrentSelectedFiles[i].panel_Parent.BackColor = Color.Transparent;
                        CurrentSelectedFiles[i].CurrentState = FileQueueState.Finished;
                        CurrentSelectedFiles[i].pBox_Checkmark.Image = Resources.TransferResult_Cross;
                    }
                }
            }
        }

        private void ThumbnailClicked(int id)
        {
            if(CurrentSelectedFiles[id] == null || SelectedFileVisual == id)
            {
                return;
            }

            if(SelectedFileVisual != -1)
            {
                CurrentSelectedFiles[SelectedFileVisual].label_FileName.AutoSize = false;
                CurrentSelectedFiles[SelectedFileVisual].panel_Parent.BackColor = Color.Transparent;
                CurrentSelectedFiles[SelectedFileVisual].label_FileName.Text = ShortenFileName(CurrentSelectedFiles[SelectedFileVisual].fileStruct.FileName +
                                                         CurrentSelectedFiles[SelectedFileVisual].fileStruct.FileExtension, 6);
            }

            CurrentSelectedFiles[id].label_FileName.AutoSize = true;
            CurrentSelectedFiles[id].label_FileName.Text = CurrentSelectedFiles[id].fileStruct.FileName +
                                                         CurrentSelectedFiles[id].fileStruct.FileExtension;

            CurrentSelectedFiles[id].panel_Parent.BackColor = Color.LightBlue;
            SelectedFileVisual = id;
        }

        private void DP_Closing(object sender, FormClosingEventArgs e)
        {
            mainPage.Show();
        }

        private Bitmap DrawImageScaled(int width, int height, ref Bitmap sourceImage)
        {
            Bitmap bmp = new Bitmap(width, height);
            Graphics graphics = Graphics.FromImage(bmp);
            graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            graphics.DrawImage(sourceImage, 0, 0, bmp.Width, bmp.Height);

            return bmp;
        }

        private void DragDrop_Paint(object sender, PaintEventArgs p)
        {
            if (IsDragging)
            {
                Pen pen = new Pen(Color.FromArgb(100, 155, 155, 0));

                Rectangle rect = new Rectangle(5, 5, DragDropPanel.Width - 10, DragDropPanel.Height - 10);
                LinearGradientBrush gBrush = new LinearGradientBrush(rect,
                    Color.FromArgb(100, 0, 250, 250),
                    Color.FromArgb(0, 0, 250, 250),
                    LinearGradientMode.Vertical);

                p.Graphics.DrawRectangle(pen, rect);
                p.Graphics.FillRectangle(gBrush, rect);
            }

        }

        private void DragDrop_Enter(object sender, DragEventArgs de)
        {
            if (de.Data.GetDataPresent(DataFormats.FileDrop)) de.Effect = DragDropEffects.Copy;
            IsDragging = true;
            DragDropPanel.Invalidate();
        }

        private void DragDrop_Leave(object sender, EventArgs de)
        {
            IsDragging = false;
            DragDropPanel.Invalidate();
        }
        private void DragDrop_Drop(object sender, DragEventArgs de)
        {
            string[] files = (string[])de.Data.GetData(DataFormats.FileDrop);

            if (files == null || files.Length < 1)
            {
                return;
            }

            CreateFileQueueVisual();

            int id = 0;

            foreach (string file in files)
            {
                FileStructure fStruct = new FileStructure();
                try
                {
                    FileInfo fInfo = new FileInfo(file);
                    fStruct.FilePath = file;
                    fStruct.FileExtension = Path.GetExtension(file);
                    fStruct.FileName = Path.GetFileNameWithoutExtension(file);
                    fStruct.FileSize = fInfo.Length;
                    AddNewQueuedFile(fStruct, id);
                    id++;
                }
                catch (Exception e)
                {
                    Debugger.AddErrorMessage(e.Message);
                    throw;
                }

            }
        }



        private void btn_ChooseFromDevice_Click(object sender, EventArgs e)
        {
            dialog_OpenFiles.Multiselect = true;
            DialogResult dr = dialog_OpenFiles.ShowDialog();

            if (dr == DialogResult.OK)
            {
                CreateFileQueueVisual();

                int id = 0;

                foreach (String file in dialog_OpenFiles.FileNames)
                {

                    FileStructure fStruct = new FileStructure();
                    try
                    {
                        FileInfo fInfo = new FileInfo(file);
                        fStruct.FilePath = file;
                        fStruct.FileExtension = Path.GetExtension(file);
                        fStruct.FileName = Path.GetFileNameWithoutExtension(file);
                        fStruct.FileSize = fInfo.Length;
                        AddNewQueuedFile(fStruct, id);
                        id++;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }

        }
    }
}
