using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileJump.CustomControls;
using FileJump.GUI;
using FileJump.Network;

namespace FileJump.FormElements
{
    public class LocalDevicesFormElement
    {
        public Panel MainPanel { get; set; }
        private Panel FileAreaPanel { get; set; }
        private Panel DragDropBackgroundPanel { get; set; }

        private CustomFlowLayoutPanel panel_FlowLayoutDevices { get; set; }
        private CustomFlowLayoutPanel panel_FlowLayoutFiles { get; set; }

        // Network
        private NetworkDevice SelectedNetworkDevice { get; set; }

        private NetworkDevicePanel LastMouseDownDevice { get; set; }

        private bool IsDragging { get; set; }

        string[] imageExtensions = new string[] { ".jpg", ".jpeg", ".bmp", ".png" };

        public Panel CreateLocalDevicesElement(Point location, int width, int height)
        {
            MainPanel = new Panel();
            MainPanel.Location = location;
            MainPanel.Size = new Size(width, height);
            MainPanel.BackColor = Color.Transparent;

            Panel DeviceScoutPanel = CreateDeviceScoutPanel();
            CreateFileAreaPanel(DeviceScoutPanel.Location.X + DeviceScoutPanel.Width);
            MainPanel.Controls.Add(DeviceScoutPanel);

            Panel FilesPanel = CreateFileDropSendPanel(DeviceScoutPanel.Location.X + DeviceScoutPanel.Width);
            FileAreaPanel.Controls.Add(FilesPanel);

            DataProcessor.NetworkDiscoveryEvent += NetworkDiscoveryEvent;

            NetComm.ScoutNetworkDevices();

            return MainPanel;
        }

        private void CreateFileAreaPanel(int minX)
        {
            FileAreaPanel = new Panel();

            FileAreaPanel.Size = new Size((int)((decimal)MainPanel.Width / 2M + 20),
                                                     (int)((decimal)MainPanel.Height / 2M));

            FileAreaPanel.Location = new Point(
                                  minX + 50,
                                  (int)((decimal)MainPanel.Height / 2 - ((decimal)FileAreaPanel.Height / 2))
                                  );

            FileAreaPanel.BackColor = Color.Transparent;
            FileAreaPanel.Paint += BorderPaint;

            MainPanel.Controls.Add(FileAreaPanel);
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
            AddNewNetworkDevice(netArgs.device);
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


            //devicePanel.MouseDown += (sender, args) =>
            //{
            //    LastMouseDownDevice = devicePanel;
            //    devicePanel.IsPressed = true;
            //    devicePanel.BackgroundImage = Properties.Resources.device_panel_pressed;
            //};

            //devicePanel.MouseUp += (sender, args) =>
            //{
            //    if(LastMouseDownDevice == devicePanel)
            //    {
            //        Console.WriteLine("same!");
            //        DeviceIconClicked(devicePanel, device);
            //    } else
            //    {
            //        //LastMouseDownDevice.IsPressed = false;
            //        //LastMouseDownDevice.BackgroundImage = Properties.Resources.device_panel_normal;
            //    }

                
            //};

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

        private void AddNewQueuedFile(LocalFileStructure file_struct, int id)
        {
            int width = (int)((decimal)FileAreaPanel.Width / 4.30M);
            int height = (int)((decimal)FileAreaPanel.Width / 4M);

            //Panel panel_Cornice = new Panel();

            //panel_Cornice.Size = new Size(size, size);
            ////panel_Cornice.Location = new Point(xPos, yPos);

            //panel_Cornice.BackgroundImage = Properties.Resources.file_cornice;
            //panel_Cornice.BackgroundImageLayout = ImageLayout.Stretch;


            //PictureBox pBox = new PictureBox();

            Bitmap icon;

            if (imageExtensions.Contains(file_struct.FileExtension.ToLower()))
            {
                // Create the thumbnail
                icon = new Bitmap(file_struct.FilePath);

            }
            else
            {
                icon= Icon.ExtractAssociatedIcon(file_struct.FilePath).ToBitmap();
            }


            DarkFileDisplay dfd = new DarkFileDisplay(width, height, icon, false, file_struct.FullName);

            //ImageEditing.DrawImageScaled(fileVis.pBox_Icon.Width, fileVis.pBox_Icon.Height, img);


            dfd.AddToControl(panel_FlowLayoutFiles);



        }

        private void CreateFileUploadVisual()
        {
            DragDropBackgroundPanel.Visible = false;
            DragDropBackgroundPanel = null;

            panel_FlowLayoutFiles = new CustomFlowLayoutPanel();
            panel_FlowLayoutFiles.Size = new Size(FileAreaPanel.Width + 35, FileAreaPanel.Height - 5); // Dunno, it works
            panel_FlowLayoutFiles.Location = new Point(3, 3);
            FileAreaPanel.Controls.Add(panel_FlowLayoutFiles);
            //panel_FlowLayoutFiles.Padding = new Padding(1);
            Console.WriteLine(panel_FlowLayoutFiles.Padding);

            panel_FlowLayoutFiles.BackColor = Color.Transparent;
            panel_FlowLayoutFiles.AutoScroll = true;
            panel_FlowLayoutFiles.BorderStyle = BorderStyle.None;

            //panel_FlowLayoutFiles.AutoScrollMargin = new Size(100, 20);
            panel_FlowLayoutFiles.VerticalScroll.Enabled = true;
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
                                  (int)((decimal)MainPanel.Height / 2 - ((decimal)panel_Main.Height / 2))
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

            return panel_Main;
        }

        private Panel CreateFileDropSendPanel(int minX)
        {

            DragDropBackgroundPanel = new Panel();
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

            Button btn_FromComputer = new Button();

            btn_FromComputer.Size = new Size((int)((decimal)panel_Files.Width / 1.3M), 50);
            btn_FromComputer.Location = new Point(panel_Files.Width / 2 - btn_FromComputer.Width / 2, 260);
            btn_FromComputer.BackgroundImage = Properties.Resources.device_panel_normal;
            btn_FromComputer.BackgroundImageLayout = ImageLayout.Stretch;
            btn_FromComputer.FlatStyle = FlatStyle.Flat;
            btn_FromComputer.FlatAppearance.BorderSize = 0;
            btn_FromComputer.Text = "..or load file(s) from your Computer!";
            btn_FromComputer.Font = new Font("Arial", 14, FontStyle.Bold, GraphicsUnit.Pixel);
            btn_FromComputer.ForeColor = Color.FromArgb(255, 112, 119, 144);

            panel_Files.Controls.Add(btn_FromComputer);

            return DragDropBackgroundPanel;
        }

        private void DragDropPaint(object sender, PaintEventArgs p)
        {
            if (IsDragging)
            {
                Pen pen = new Pen(Color.FromArgb(100, 155, 155, 0));

                GraphicsPath path = new GraphicsPath();
                path.AddRectangle(new Rectangle(0, 0, DragDropBackgroundPanel.Width, DragDropBackgroundPanel.Height));

                PathGradientBrush pathBrush = new PathGradientBrush(path);
                pathBrush.CenterColor = Color.FromArgb(170, 153, 217, 234);
                Color[] colors = { Color.FromArgb(100, 103, 167, 184), Color.FromArgb(0, 0, 255, 0) };
                pathBrush.SurroundColors = colors;
                p.Graphics.FillRectangle(pathBrush, new Rectangle(0, 0, DragDropBackgroundPanel.Width, DragDropBackgroundPanel.Height));
            }

        }

        // 

        private void DragDrop_Enter(object sender, DragEventArgs de) // DragEventArgs
        {
            if (de.Data.GetDataPresent(DataFormats.FileDrop)) de.Effect = DragDropEffects.Copy;
            IsDragging = true;
            DragDropBackgroundPanel.Invalidate();
        }

        private void DragDrop_Leave(object sender, EventArgs de)
        {
            IsDragging = false;
            DragDropBackgroundPanel.Invalidate();
        }

        private void DragDrop_Drop(object sender, DragEventArgs de)
        {
            string[] files = (string[])de.Data.GetData(DataFormats.FileDrop);

            if (files == null || files.Length < 1)
            {
                return;
            }

            CreateFileUploadVisual();
            int id = 0;

            foreach (string file in files)
            {
                LocalFileStructure fStruct = new LocalFileStructure();
                try
                {
                    FileInfo fInfo = new FileInfo(file);
                    fStruct.FilePath = file;
                    fStruct.FileExtension = Path.GetExtension(file);
                    fStruct.FileName = Path.GetFileNameWithoutExtension(file);
                    fStruct.FileSize = fInfo.Length;
                    fStruct.FullName = fInfo.Name;
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



        //private void btn_ChooseFromDevice_Click(object sender, EventArgs e)
        //{
        //    dialog_OpenFiles.Multiselect = true;
        //    DialogResult dr = dialog_OpenFiles.ShowDialog();

        //    if (dr == DialogResult.OK)
        //    {
        //        CreateFileQueueVisual();

        //        int id = 0;

        //        foreach (String file in dialog_OpenFiles.FileNames)
        //        {

        //            LocalFileStructure fStruct = new LocalFileStructure();
        //            try
        //            {
        //                FileInfo fInfo = new FileInfo(file);
        //                fStruct.FilePath = file;
        //                fStruct.FileExtension = Path.GetExtension(file);
        //                fStruct.FileName = Path.GetFileNameWithoutExtension(file);
        //                fStruct.FileSize = fInfo.Length;
        //                AddNewQueuedFile(fStruct, id);
        //                id++;
        //            }
        //            catch (Exception)
        //            {
        //                throw;
        //            }
        //        }
        //    }

        //}

        private void BorderPaint(object sender, PaintEventArgs e)
        {
            Control target = (Control)sender;

            // Draw the border
            int thickness = 2;
            int halfThickness = thickness / 2;

            using (Pen p = new Pen(Color.FromArgb(255, 102, 109, 138), thickness))
            {
                e.Graphics.DrawRectangle(p, new Rectangle(halfThickness,
                                                          halfThickness,
                                                          target.ClientSize.Width - thickness,
                                                          target.ClientSize.Height - thickness));
            }
        }
    }
}
