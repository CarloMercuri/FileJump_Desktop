﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileJump.CustomControls;
using FileJump.GUI;
using FileJump.Network;
using FileJump.Network.EventSystem;

namespace FileJump.FormElements
{
    public class LocalDevicesFormElement
    {
        public Panel MainPanel { get; set; }
        private Panel FileAreaPanel { get; set; }


        private CustomFlowLayoutPanel panel_FlowLayoutDevices { get; set; }
        private CustomFlowLayoutPanel panel_FlowLayoutFiles { get; set; }

        private List<DarkFileDisplay> FileDisplayList { get; set; }

        private List<LocalFileStructure> UploadList = new List<LocalFileStructure>();

        /// <summary>
        /// The current status (transferring or not)
        /// </summary>
        private GUIState _GUIState { get; set; }

        private Panel panel_ButtonsMain { get; set; }

        private Panel panel_SendFiles { get; set; }

        private CustomGeneralButton btn_TerminateTransfers { get; set; }

        private CustomGeneralButton SendFilesButton { get; set; }

        private Panel panel_DragDropFiles { get; set; }

        // Network
        private NetworkDevice SelectedNetworkDevice { get; set; }

        private NetworkDevicePanel LastMouseDownDevice { get; set; }

        private int FileDisplayMinX { get; set; }

        private bool IsDragging { get; set; }

        string[] imageExtensions = new string[] { ".jpg", ".jpeg", ".bmp", ".png" };

    
        private Form mainForm { get; set; }

        public Panel CreateLocalDevicesElement(Point location, int width, int height, Form _form)
        {
            mainForm = _form;
            FileDisplayList = new List<DarkFileDisplay>();
            MainPanel = new Panel();
            MainPanel.Location = location;
            MainPanel.Size = new Size(width, height);
            MainPanel.BackColor = Color.Transparent;

            Panel DeviceScoutPanel = CreateDeviceScoutPanel();

            MainPanel.Controls.Add(DeviceScoutPanel);

            FileDisplayMinX = DeviceScoutPanel.Location.X + DeviceScoutPanel.Width;

            CreateFileAreaPanel(FileDisplayMinX);
            CreateFileUploadVisualPanel();
            panel_FlowLayoutFiles.Visible = false;

            panel_DragDropFiles = CreateFileDropSendPanel(FileDisplayMinX);
            FileAreaPanel.Controls.Add(panel_DragDropFiles);


            // Create the various state panels



            FileAreaPanel.Visible = false;

            panel_ButtonsMain = new Panel();

            panel_ButtonsMain.Location = new Point(FileAreaPanel.Location.X, FileAreaPanel.Location.Y + FileAreaPanel.Height + 10);
            panel_ButtonsMain.Size = new Size(FileAreaPanel.Width, 200);
            MainPanel.Controls.Add(panel_ButtonsMain);

            panel_SendFiles = CreateSendButtons();
            panel_SendFiles.Visible = false; ;
            panel_ButtonsMain.Controls.Add(panel_SendFiles);
            panel_ButtonsMain.Controls.Add(btn_TerminateTransfers);
 

            ChangeGuiState(GUIState.NoDeviceSelected);

            
            DataProcessor.NetworkDiscoveryEvent += NetworkDiscoveryEvent;

            NetComm.ScoutNetworkDevices();

            // Subscribe to events
            DataProcessor.OutboundTransferFinished += Transferfinished;
            DataProcessor.OutboundTransferStarted += TransferStarted;
            DataProcessor.OutboundTransferProgress += TransferProgress;


            return MainPanel;
        }



        private void TransferProgress(object sender, FileTransferProgressEventArgs e)
        {
            DarkFileDisplay dfd = FileDisplayList.Find(x => x.FileStructure.FileID == e.ID);

            if(dfd == null)
            {
                return;
            }


            if (mainForm.InvokeRequired)
            {
                mainForm.Invoke((MethodInvoker)delegate { dfd.UpdateProgress(e.PercentProgress); });
            }
            

                
        }

        private void ResetFilesArea()
        {
            FileDisplayList = new List<DarkFileDisplay>();
            panel_FlowLayoutFiles.Controls.Clear();
            panel_FlowLayoutFiles.Visible = false;
            //Panel p = CreateFileDropSendPanel(FileDisplayMinX);
            //FileAreaPanel.Controls.Clear();
            //FileAreaPanel.Controls.Add(panel_DragDropFiles);
            panel_DragDropFiles.Visible = true;
            panel_DragDropFiles.Invalidate();
        }

        private void ChangeGuiState(GUIState state)
        {
            //panel_ButtonsMain.Controls.Clear();

            switch (state)
            {
                case GUIState.NoFilesSelected:
                    // Buttons
                    panel_SendFiles.Visible = false;

                    FileAreaPanel.Visible = true;

                    panel_DragDropFiles.Visible = true;
                    ResetFilesArea();
                    break;

                case GUIState.FilesSelected:
                    panel_FlowLayoutFiles.Invoke((MethodInvoker)(() => panel_FlowLayoutFiles.Visible = true));
                    panel_FlowLayoutFiles.Visible = true;
                    //panel_ButtonsMain.Controls.Add(panel_SendFiles);
                    panel_SendFiles.Visible = true;
                    panel_DragDropFiles.Visible = false;
                    btn_TerminateTransfers.Visible = false;


                    break;

                case GUIState.NoDeviceSelected:
                    break;

                case GUIState.TransfersRunning:
                    panel_SendFiles.Visible = false;
                    btn_TerminateTransfers.Visible = true;
                    break;

                default:
                    break;
            }
        }

        private Panel CreateSendButtons()
        {
            Panel panel_Main = new Panel();

            panel_Main.Location = new Point(0, 0);
            panel_Main.Size = new Size(panel_ButtonsMain.Width, panel_ButtonsMain.Height);

            CustomGeneralButton btn_SendAll = new CustomGeneralButton();

            int btnWidth = (int)((decimal)FileAreaPanel.Width / 3M);

            //
            // Send All
            //

            btn_SendAll = new CustomGeneralButton();

            btn_SendAll.Size = new Size(btnWidth, 50);


            btn_SendAll.Text = "";

            btn_SendAll.TextFont = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Pixel);

            btn_SendAll.Location = new Point(0, 0);

            btn_SendAll.ButtonText = "Send Files";
            btn_SendAll.ForeColor = GUITools.COLOR_DarkMode_Text_Bright;
            btn_SendAll.Click += SendAllFilesButtonClick;

            panel_Main.Controls.Add(btn_SendAll);

            //
            // Send Selected
            //

            CustomGeneralButton btn_SendSelected = new CustomGeneralButton();

            btn_SendSelected.Size = new Size(btnWidth, 50);


            btn_SendSelected.Text = "";

            btn_SendSelected.TextFont = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Pixel);

            btn_SendSelected.Location = new Point(btnWidth, 0);

            btn_SendSelected.ButtonText = "Send Selected Files";
            btn_SendSelected.ForeColor = GUITools.COLOR_DarkMode_Text_Bright;
            btn_SendSelected.Click += SendSelectedFilesButtonClick;


            panel_Main.Controls.Add(btn_SendSelected);

            //
            // Reset
            //

            CustomGeneralButton btn_Reset = new CustomGeneralButton();

            btn_Reset.Size = new Size(btnWidth, 50);


            btn_Reset.Text = "";

            btn_Reset.TextFont = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Pixel);

            btn_Reset.Location = new Point(btnWidth * 2, 0);

            btn_Reset.ButtonText = "Reset Files";
            btn_Reset.ForeColor = GUITools.COLOR_DarkMode_Text_Bright;
            btn_Reset.Click += ResetFilesButtonClick;


            panel_Main.Controls.Add(btn_Reset);

            btn_TerminateTransfers = new CustomGeneralButton();
            btn_TerminateTransfers.Size = new Size(btnWidth, 50);


            btn_TerminateTransfers.Text = "";

            btn_TerminateTransfers.TextFont = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Pixel);

            btn_TerminateTransfers.Location = new Point(btnWidth, 0);

            btn_TerminateTransfers.ButtonText = "Terminate Transfers";
            btn_TerminateTransfers.ForeColor = GUITools.COLOR_RedText;

            btn_TerminateTransfers.Click += (sender, args) =>
            {
                TerminateTransfers();
            };


            MainPanel.Controls.Add(btn_TerminateTransfers);
            btn_TerminateTransfers.Visible = false;

            return panel_Main;
        }

        /// <summary>
        /// SendFiles, Terminate, Reset
        /// </summary>
        /// <param name="type"></param>
        private void CreateSendButton(string type)
        {

            if (MainPanel.InvokeRequired)
            {
                MainPanel.Invoke(
                    new MethodInvoker(
                    delegate () { MainPanel.Controls.Remove(SendFilesButton); }));
            }
            else
            {
                MainPanel.Controls.Remove(SendFilesButton);
            }

            SendFilesButton = new CustomGeneralButton();

            SendFilesButton.Size = new Size((int)((decimal)FileAreaPanel.Width / 2M), 50);


            SendFilesButton.Text = "";

            SendFilesButton.TextFont = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Pixel);

            SendFilesButton.Location = new Point(FileAreaPanel.Location.X + FileAreaPanel.Width / 2 - SendFilesButton.Width / 2,
    FileAreaPanel.Location.Y + FileAreaPanel.Height + 15);

            switch (type)
            {
                case "SendFiles":
                    SendFilesButton.ButtonText = "Send Files";
                    SendFilesButton.ForeColor = GUITools.COLOR_DarkMode_Text_Bright;
                    SendFilesButton.Click += SendAllFilesButtonClick;
                    break;
                case "Terminate":
                    SendFilesButton.ButtonText = "Terminate Transfers";
                    SendFilesButton.ForeColor = Color.FromArgb(255, 255, 0, 0);

                    SendFilesButton.Click += (obj, args) =>
                    {
                        TerminateTransfers();

                    };

                    break;
                case "Reset":
                    SendFilesButton.ButtonText = "Choose more files";
                    SendFilesButton.ForeColor = GUITools.COLOR_DarkMode_Text_Bright;

                    SendFilesButton.Click += (obj, args) =>
                    {
                        ResetFilesArea();
                        SendFilesButton.Visible = false;
                    };

                    break;

            }

            if (MainPanel.InvokeRequired)
            {
                MainPanel.Invoke(
                    new MethodInvoker(
                    delegate () { MainPanel.Controls.Add(SendFilesButton); }));
            }
            else
            {
                MainPanel.Controls.Add(SendFilesButton);
            }


        }

        private void TransferStarted(object sender, OutTransferEventArgs e)
        {
           
        }

        private void Transferfinished(object sender, OutTransferEventArgs e)
        {
            DarkFileDisplay dfd = FileDisplayList.Find(x => x.FileStructure.FileID == e.FileID);

            if(dfd == null)
            {
                return;
            }

            if (mainForm.InvokeRequired)
            {
                mainForm.Invoke((MethodInvoker)delegate { dfd.TransferFinished(e); });
            }
            

            if(FileDisplayList.Where(x => x.FileStructure.FileStatus == FileStatus.QueuedForDownload).Count() <= 0)
            {
                if (mainForm.InvokeRequired)
                {
                    mainForm.Invoke((MethodInvoker)delegate { ChangeGuiState(GUIState.FilesSelected); } );
                }

            }

        }

        private void CreateFileAreaPanel(int minX)
        {
            FileAreaPanel = new Panel();

            FileAreaPanel.Size = new Size((int)((decimal)MainPanel.Width / 2M + 20),
                                                     (int)((decimal)MainPanel.Height / 2M));

            FileAreaPanel.Location = new Point(
                                  minX + 50,
                                  (int)((decimal)MainPanel.Height / 2 - ((decimal)FileAreaPanel.Height / 2.5M))
                                  );

            FileAreaPanel.BackColor = Color.Transparent;
            FileAreaPanel.Paint += BorderPaint;

            MainPanel.Controls.Add(FileAreaPanel);

            Label label_Text = new Label();
            label_Text.AutoSize = true;
            label_Text.Font = new Font("Arial", 16, FontStyle.Bold, GraphicsUnit.Pixel);
            label_Text.Text = "Files to Send";
            label_Text.Location = new Point((FileAreaPanel.Location.X + FileAreaPanel.Width / 2) - TextRenderer.MeasureText(label_Text.Text, label_Text.Font).Width / 2, FileAreaPanel.Location.Y - 30);
            label_Text.ForeColor = GUITools.COLOR_DarkMode_Text_Light;
    

  

            MainPanel.Controls.Add(label_Text);
        }

        /// <summary>
        /// When we receive a NetworkDiscoveryEvent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="netArgs"></param>
        private void NetworkDiscoveryEvent(object sender, NetworkDiscoveryEventArgs netArgs)
        {
            // Add it to the display list
            AddNewNetworkDevice(netArgs.device);
        }

        public void AddNewNetworkDevice(NetworkDevice device)
        {
            NetworkDevicePanel devicePanel = new NetworkDevicePanel();
            devicePanel.Size = new Size(panel_FlowLayoutDevices.Width - 10, 60);
            devicePanel.BackgroundImage = Properties.Resources.device_panel_normal;
            devicePanel.BackgroundImageLayout = ImageLayout.Stretch;

            devicePanel.DeviceIconSize = 40;
            devicePanel.DeviceIcon = GetCorrentDeviceIcon(device.Type);


            devicePanel.Font = new Font("Arial", 14, FontStyle.Bold, GraphicsUnit.Pixel);
            devicePanel.DeviceNameTextOffset = devicePanel.DeviceIconSize + 10;

            string newT = GUITools.FitTextLenghtToWidth(device.Name, devicePanel.Font,
                                           devicePanel.Width - devicePanel.DeviceIconSize - devicePanel.DeviceNameTextOffset);

            


            devicePanel.DeviceName = newT;


            devicePanel.MouseClick += (sender, args) =>
            {
                DeviceIconClicked(devicePanel, device);
            };

            // Cannot update from outside the thread
            if (panel_FlowLayoutDevices.InvokeRequired)
            {
                panel_FlowLayoutDevices.Invoke(
                    new MethodInvoker(
                    delegate () { panel_FlowLayoutDevices.Controls.Add(devicePanel); }));
            }



        }

        private void AddNewQueuedFile(LocalFileStructure file_struct)
        {
            int width = (int)((decimal)FileAreaPanel.Width / 4.30M);
            int height = (int)((decimal)FileAreaPanel.Width / 4M);
                        
            Bitmap icon;

            if (imageExtensions.Contains(file_struct.FileExtension.ToLower()))
            {
                // Create the thumbnail
                icon = new Bitmap(file_struct.FilePath);
            }
            else
            {
                icon = Icon.ExtractAssociatedIcon(file_struct.FilePath).ToBitmap();
            }

            DarkFileDisplay dfd = new DarkFileDisplay(width, height, icon, false, file_struct.FullName, panel_FlowLayoutFiles);

            dfd.FileStructure = file_struct;

            dfd.ActionOnClick(() =>
            {
                FileIconClick(dfd);
            });

            if (mainForm.InvokeRequired)
            {
                mainForm.Invoke((MethodInvoker)delegate { dfd.AddToControl(panel_FlowLayoutFiles); });
            }

            //dfd.AddToControl(panel_FlowLayoutFiles);

            FileDisplayList.Add(dfd);

            icon.Dispose();
        }

        private void FileIconClick(DarkFileDisplay dfd)
        {
            if (Control.ModifierKeys == Keys.Control)
            {
                dfd.IsSelected = !dfd.IsSelected;

                return;
            }

            if (Control.ModifierKeys == Keys.Shift)
            {
                return;
            }

            // if none is pressed

            foreach(DarkFileDisplay df in FileDisplayList)
            {
                df.IsSelected = false;
            }

            dfd.IsSelected = true;



        }

       

        private void CreateFileUploadVisualPanel()
        {
            panel_FlowLayoutFiles = new CustomFlowLayoutPanel();
            panel_FlowLayoutFiles.Size = new Size(FileAreaPanel.Width + 35, FileAreaPanel.Height - 5); // Dunno, it works
            panel_FlowLayoutFiles.Location = new Point(3, 3);
            FileAreaPanel.Controls.Add(panel_FlowLayoutFiles);
            //panel_FlowLayoutFiles.Padding = new Padding(1);

            panel_FlowLayoutFiles.BackColor = Color.Transparent;
            panel_FlowLayoutFiles.AutoScroll = true;
            panel_FlowLayoutFiles.BorderStyle = BorderStyle.None;

            //panel_FlowLayoutFiles.AutoScrollMargin = new Size(100, 20);
            panel_FlowLayoutFiles.VerticalScroll.Enabled = true;

            FileAreaPanel.Controls.Add(panel_FlowLayoutFiles);

        }


        private Image GetCorrentDeviceIcon(NetworkDeviceType type)
        {
            switch (type)
            {
                case NetworkDeviceType.Desktop:
                    return Properties.Resources.icon_desktop_dark;

                case NetworkDeviceType.MobilePhone:
                    return Properties.Resources.icon_phone_dark;

                default:
                    return null;
            }
        }

        private void DeviceIconClicked(NetworkDevicePanel devicePanel, NetworkDevice device)
        {
            if(SelectedNetworkDevice == null)
            {
                //CreateFileAreaPanel(FileDisplayMinX);

                ChangeGuiState(GUIState.NoFilesSelected);
            }

            SelectedNetworkDevice = device;

            devicePanel.IsPressed = true;
            devicePanel.BackgroundImage = Properties.Resources.device_panel_pressed;

            // reset the status of the others
            foreach(NetworkDevicePanel c in panel_FlowLayoutDevices.Controls)
            {
                if(devicePanel != c)
                {
                    c.IsPressed = false;
                    c.BackgroundImage = Properties.Resources.device_panel_normal;
                }
            }
        }


        private Panel CreateDeviceScoutPanel()
        {
            Panel panel_Main = new Panel();

            panel_Main.Size = new Size( (int)((decimal)MainPanel.Width / 3M),
                                        (int)((decimal)MainPanel.Height / 2M));
            panel_Main.Location = new Point(
                                  30,
                                  (int)((decimal)MainPanel.Height / 2 - ((decimal)panel_Main.Height / 2.5M))
                                  );

            panel_Main.Paint += BorderPaint;

            // Flow layout

            panel_FlowLayoutDevices = new CustomFlowLayoutPanel();
            panel_FlowLayoutDevices.Location = new Point(5, 5);
            panel_FlowLayoutDevices.Height = panel_Main.Height;
            panel_FlowLayoutDevices.Width = panel_Main.Width - 5;
            panel_FlowLayoutDevices.BackColor = Color.Transparent;
            panel_FlowLayoutDevices.AutoScroll = true;
            panel_FlowLayoutDevices.BorderStyle = BorderStyle.None;

            panel_FlowLayoutDevices.AutoScrollMargin = new Size(100, 20);
            panel_FlowLayoutDevices.VerticalScroll.Enabled = true;


            panel_Main.Controls.Add(panel_FlowLayoutDevices);

            Label label_Text = new Label();

            label_Text.Font = GUITools.FONT_WallText;
            label_Text.AutoSize = true;
            label_Text.ForeColor = GUITools.COLOR_DarkMode_Text_Light;
            label_Text.Text = "Local Accessible Devices";
            label_Text.Location = new Point((panel_Main.Location.X + panel_Main.Width / 2) - TextRenderer.MeasureText(label_Text.Text, label_Text.Font).Width / 2, panel_Main.Location.Y - 30);



            MainPanel.Controls.Add(label_Text);


            CustomGeneralButton btn_Refresh = new CustomGeneralButton();

            btn_Refresh.Size = new Size((int)((decimal)panel_Main.Width / 2M), 50);

            btn_Refresh.BackgroundImage = Properties.Resources.device_panel_normal;

            btn_Refresh.BackgroundImageLayout = ImageLayout.Stretch;
            btn_Refresh.FlatStyle = FlatStyle.Flat;
            btn_Refresh.FlatAppearance.BorderSize = 0;
            btn_Refresh.ButtonText = "REFRESH";
            btn_Refresh.Text = "";
            btn_Refresh.ForeColor = GUITools.COLOR_DarkMode_Text_Bright;
            btn_Refresh.TextFont = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Pixel);
            
            btn_Refresh.Location = new Point(panel_Main.Location.X + panel_Main.Width / 2 - btn_Refresh.Width / 2,
    panel_Main.Location.Y + panel_Main.Height + 10);


            btn_Refresh.Click += (sender, args) =>
            {
                RefreshLocalDevices();
            };


            MainPanel.Controls.Add(btn_Refresh);
            return panel_Main;
        }

        private void RefreshLocalDevices()
        {
            panel_FlowLayoutDevices.Controls.Clear();
            

            NetComm.ScoutNetworkDevices();
        }

        private Panel CreateFileDropSendPanel(int minX)
        {
            Panel DragDropBackgroundPanel = new Panel();
            DragDropBackgroundPanel.Enabled = true;
            DragDropBackgroundPanel.Visible = true;
            DragDropBackgroundPanel.Size = FileAreaPanel.Size;

            DragDropBackgroundPanel.Location = new Point(0, 0);

            DragDropBackgroundPanel.BackColor = Color.Transparent;
            DragDropBackgroundPanel.Paint += DragDropPaint;


            Panel panel_Files = new Panel();
            panel_Files.Size = DragDropBackgroundPanel.Size;
            panel_Files.Location = new Point(0, 0);
            panel_Files.BackgroundImage = Properties.Resources.drag_drop_BG_new2;
            panel_Files.BackgroundImageLayout = ImageLayout.Stretch;



            DragDropBackgroundPanel.Controls.Add(panel_Files);

            TransparentControl panel_MouseInteract = new TransparentControl();
            panel_MouseInteract.Size = DragDropBackgroundPanel.Size;
            panel_MouseInteract.Location = new Point(0, 0);
            panel_MouseInteract.AllowDrop = true;
            panel_MouseInteract.DragEnter += DragDrop_Enter;
            panel_MouseInteract.DragLeave += DragDrop_Leave;
            panel_MouseInteract.DragDrop += DragDrop_Drop;

            DragDropBackgroundPanel.Controls.Add(panel_MouseInteract);
            panel_MouseInteract.BringToFront();

            CustomGeneralButton btn_FromComputer = new CustomGeneralButton();

            btn_FromComputer.Size = new Size((int)((decimal)panel_Files.Width / 1.3M), 50);
            btn_FromComputer.Location = new Point(panel_Files.Width / 2 - btn_FromComputer.Width / 2, 260);
            btn_FromComputer.ButtonText = "..or load file(s) from your Computer!";
            btn_FromComputer.TextFont = new Font("Arial", 14, FontStyle.Bold, GraphicsUnit.Pixel);
            btn_FromComputer.ForeColor = Color.FromArgb(255, 112, 119, 144);


            DragDropBackgroundPanel.Controls.Add(btn_FromComputer);

            btn_FromComputer.Click += btn_ChooseFromDevice_Click;

            btn_FromComputer.BringToFront();



            return DragDropBackgroundPanel;
        }

        //private void ProcessFileArrayThread(string[] paths)
        //{
        //    var t = new Thread(() => ProcessFileArray(paths));
        //    t.Start();

        //}

        private void ProcessFileArray(string[] paths)
        {
            if (mainForm.InvokeRequired)
            {
                mainForm.Invoke((MethodInvoker)delegate { ChangeGuiState(GUIState.FilesSelected); });
            }

            //mainForm.Invoke((MethodInvoker)delegate { panel_SendFiles.Visible = false; });


            //ChangeGuiState(GUIState.FilesSelected);

            CustomProgressBar progressBar = new CustomProgressBar()
            {
                Size = new Size(FileAreaPanel.Width, 20),
                Location = new Point(0, 0),
            };

            progressBar.BackgroundBarColor = GUITools.COLOR_DarkMode_Light;
            progressBar.ProgressBarColor = Color.Green;
            progressBar.Percentage = 0;

            mainForm.Invoke((MethodInvoker)delegate { panel_ButtonsMain.Controls.Add(progressBar); panel_SendFiles.Visible = false; });
            

            for (int i = 0; i < paths.Length; i++)
            {
                decimal pp = (decimal)i / (decimal)paths.Length;

                progressBar.Percentage = (int)Math.Round(pp * 100);

                LocalFileStructure fStruct = new LocalFileStructure();
                fStruct.FileStatus = FileStatus.Inactive;
                FileInfo fInfo = new FileInfo(paths[i]);
                fStruct.FilePath = paths[i];
                fStruct.FileExtension = Path.GetExtension(paths[i]);
                fStruct.FileName = Path.GetFileNameWithoutExtension(paths[i]);
                fStruct.FileSize = fInfo.Length;
                fStruct.FullName = fInfo.Name;
                fStruct.FileID = i;
                fStruct.FileSize = fInfo.Length;
                AddNewQueuedFile(fStruct);
            }


            mainForm.Invoke((MethodInvoker)delegate { panel_SendFiles.Visible = true; progressBar.Visible = false; });

            //mainForm.Invoke((MethodInvoker)delegate { progressBar.Visible = false; });


            //foreach (string file in paths)
            //{
            //    LocalFileStructure fStruct = new LocalFileStructure();
            //    fStruct.FileStatus = FileStatus.Inactive;
            //    FileInfo fInfo = new FileInfo(file);
            //    fStruct.FilePath = file;
            //    fStruct.FileExtension = Path.GetExtension(file);
            //    fStruct.FileName = Path.GetFileNameWithoutExtension(file);
            //    fStruct.FileSize = fInfo.Length;
            //    fStruct.FullName = fInfo.Name;
            //    fStruct.FileID = id;
            //    fStruct.FileSize = fInfo.Length;
            //    AddNewQueuedFile(fStruct);
            //    id++;
            //}


        }

        private void btn_ChooseFromDevice_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog_OpenFiles = new OpenFileDialog();

            dialog_OpenFiles.Multiselect = true;
            DialogResult dr = dialog_OpenFiles.ShowDialog();

            if (dr != DialogResult.OK)
            {
                // TODO: Some error
                return;   
            }

            // Start this in a new thread, much smoother
            Thread ProcessThread = new Thread(() => ProcessFileArray(dialog_OpenFiles.FileNames));
            ProcessThread.Start();

            //ProcessFileArray(dialog_OpenFiles.FileNames);
            
        }

        private void DragDropPaint(object sender, PaintEventArgs p)
        {
            if (IsDragging)
            {
                Pen pen = new Pen(Color.FromArgb(100, 155, 155, 0));

                GraphicsPath path = new GraphicsPath();
                path.AddRectangle(new Rectangle(0, 0, panel_DragDropFiles.Width, panel_DragDropFiles.Height));

                PathGradientBrush pathBrush = new PathGradientBrush(path);
                pathBrush.CenterColor = Color.FromArgb(170, 153, 217, 234);
                Color[] colors = { Color.FromArgb(100, 103, 167, 184), Color.FromArgb(0, 0, 255, 0) };
                pathBrush.SurroundColors = colors;
                p.Graphics.FillRectangle(pathBrush, new Rectangle(0, 0, panel_DragDropFiles.Width, panel_DragDropFiles.Height));
            }

        }

        // 

        private void DragDrop_Enter(object sender, DragEventArgs de) // DragEventArgs
        {
            if (de.Data.GetDataPresent(DataFormats.FileDrop)) de.Effect = DragDropEffects.Copy;
            IsDragging = true;
            panel_DragDropFiles.Invalidate();
        }

        private void DragDrop_Leave(object sender, EventArgs de)
        {
            IsDragging = false;
            panel_DragDropFiles.Invalidate();
        }

        private void DragDrop_Drop(object sender, DragEventArgs de)
        {
            string[] files = (string[])de.Data.GetData(DataFormats.FileDrop);

            if (files == null || files.Length < 1)
            {
                return;
            }

            ProcessFileArray(files);
            IsDragging = false;
            panel_DragDropFiles.Invalidate();
            
        }

        private void SendAllFilesButtonClick(object sender, EventArgs e)
        {
            // Check if there are files currently queued
            if (FileDisplayList.Count <= 0)
            {
                return;
            }

            // And the transfer processe(s) are not currently running.
            // The button is supposed to gray out when this is true, but you never know
            if (_GUIState == GUIState.TransfersRunning)
            {
                return;
            }

            


            UploadList = new List<LocalFileStructure>();

            //Sift through the files to see if there are some waiting to be sent
            for (int i = 0; i < FileDisplayList.Count; i++)
            {
                if (FileDisplayList[i].FileStructure.FileStatus == FileStatus.Inactive ||
                    FileDisplayList[i].FileStructure.FileStatus == FileStatus.QueuedForDownload)
                {
                    FileDisplayList[i].FileStructure.FileStatus = FileStatus.QueuedForDownload;
                    UploadList.Add(FileDisplayList[i].FileStructure);
                }

            }

            if(UploadList.Count > 0)
            {
                ChangeGuiState(GUIState.TransfersRunning);

                DataProcessor.SendFiles(UploadList, SelectedNetworkDevice.EndPoint);
            }


        }

        private void ResetFilesButtonClick(object sender, EventArgs e)
        {
            ChangeGuiState(GUIState.NoFilesSelected);
        }

        private void SendSelectedFilesButtonClick(object sender, EventArgs e)
        {
            // Check if there are files currently queued
            if (FileDisplayList.Count <= 0)
            {
                return;
            }

            // And the transfer processe(s) are not currently running.
            // The button is supposed to gray out when this is true, but you never know
            if (_GUIState == GUIState.TransfersRunning)
            {
                return;
            }




            UploadList = new List<LocalFileStructure>();

            //Sift through the files to see if there are some waiting to be sent
            for (int i = 0; i < FileDisplayList.Count; i++)
            {
                if (FileDisplayList[i].IsSelected)
                {
                    FileDisplayList[i].FileStructure.FileStatus = FileStatus.QueuedForDownload;
                    UploadList.Add(FileDisplayList[i].FileStructure);
                }
            }

            if(UploadList.Count > 0)
            {
                ChangeGuiState(GUIState.TransfersRunning);

                DataProcessor.SendFiles(UploadList, SelectedNetworkDevice.EndPoint);
            }
        }

        private void TerminateTransfers()
        {
            DataProcessor.TerminateTransfers();

            for (int i = 0; i < FileDisplayList.Count; i++)
            {
                if(FileDisplayList[i].FileStructure.FileStatus != FileStatus.Finished)
                {
                    if(FileDisplayList[i].FileStructure.FileStatus == FileStatus.QueuedForDownload)
                    {
                        FileDisplayList[i].TransferFinished(new OutTransferEventArgs(FileDisplayList[i].FileStructure.FilePath,
                                                             false,
                                                             "Terminated"));
                    }

                }
            }


            ChangeGuiState(GUIState.FilesSelected);
        }


        private void BorderPaint(object sender, PaintEventArgs e)
        {
            Control target = (Control)sender;

            // Draw the border
            int thickness = 2;
            int halfThickness = thickness / 2;

            using (Pen p = new Pen(GUITools.COLOR_Controls_Border, thickness))
            {
                e.Graphics.DrawRectangle(p, new Rectangle(halfThickness,
                                                          halfThickness,
                                                          target.ClientSize.Width - thickness,
                                                          target.ClientSize.Height - thickness));
            }
        }
    }
}
