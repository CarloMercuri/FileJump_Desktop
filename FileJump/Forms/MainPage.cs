using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileJump.Network;
using FileJump.Properties;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using FileJump.Forms;

namespace FileJump
{
    public partial class MainPage : Form
    {

        // Top panel hack
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        
        // Misc
        public int DevicesCount { get; set; } = 0;

        private bool IsBaloonTipActive { get; set; }
        private int BaloonToolTipDestination { get; set; } = 0; // 0 = folder, 1 = messages

        
        private RegistryKey rkApp { get; set; }

        private List<DeviceGUIObject> ActiveDeviceGUIOBjects = new List<DeviceGUIObject>();



        // Messages window
        private int MessageListWidth = 390;
        private int FormOriginalWidth = 642;
        private bool ShowingMessages { get; set; }

        private List<TextMessage> MessagesList = new List<TextMessage>();

        private FlowLayoutPanel Messages_FlowLayoutPanel;

        private Panel Messages_ParentPanel;


        public MainPage()
        {
            InitializeComponent();

            // Let's start up the udp listener
            NetComm.InitializeNetwork();

            // Get the correct registry key for startup
            rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);


            // Settings
           

#if DEBUG
            ChangeDestinationFolder("C:/FileJumpFolder");
            ChangeDeviceName("CARLO_BB");
#else

            if (Settings.Default["MachineName"].ToString() == "NULL")
            {
                ChangeDeviceName(Environment.MachineName);
            }
            else
            {
                ChangeDeviceName(Settings.Default["MachineName"].ToString());
            }

            if (!Directory.Exists(Properties.Settings.Default["DestinationFolder"].ToString()))
            {
                ChangeDestinationFolder(Path.Combine(Directory.GetCurrentDirectory(), "Incoming Files"));
            }
            else
            {
                ChangeDestinationFolder(Properties.Settings.Default["DestinationFolder"].ToString());
            }
#endif

            // Check the startup setting
            if ((bool)Settings.Default["RunOnStartup"] == true)
            {
                startup_Checkbox.CheckState = CheckState.Checked; // This also automatically runs AddToStartup which checks if it is running on startup,
            }                                                     // else it adds it.  
            else
            {
                startup_Checkbox.CheckState = CheckState.Unchecked; // This runs the remove check
            }

            // Notifications settings
            tray_icon.BalloonTipShown += Tray_icon_BalloonTipShown;
            tray_icon.BalloonTipClosed += Tray_icon_BalloonTipClosed;
            tray_icon.BalloonTipClicked += Tray_icon_BalloonTipClicked;

            // Subscribe to events
            DataProcessor.NetworkDiscoveryEvent += NetworkDiscoveryReceived;
            DataProcessor.IncomingTransferFinished += IncomingTransferFinished;
            DataProcessor.InboundTextTransferFinished += InboundTextTransferFinished;

            // Reset the devices count and run a scan
            DevicesCount = 0;
            NetComm.ScoutNetworkDevices();


           


        }

        private void InboundTextTransferFinished(object sender, InboundTextTransferEventArgs args)
        {
            // Add the message to the database
            FileHandler.AddNewMessageToXML(args.Message, DateTime.Now.ToString());
            
            // Show the baloon tooltip
            BaloonToolTipDestination = 1;
            ShowBaloonTooltip("New message received!");
        }

        
        private void IncomingTransferFinished(object sender, InboundTransferEventArgs args)
        {
            FileHandler.SaveFileToLocalStorage(args.FileBuffer, args.FileStructure);
            // Show the baloon tooltip
            BaloonToolTipDestination = 0;
            ShowBaloonTooltip("File(s) transfer complete");
        }


        /// <summary>
        /// When we receive a NetworkDiscoveryEvent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="netArgs"></param>
        private void NetworkDiscoveryReceived(object sender, NetworkDiscoveryEventArgs netArgs)
        {
            // Add it to the display list
            AddNewNetworkDevice(netArgs.device);
        }

        /// <summary>
        /// Returns the icon image associated with the specified device type
        /// </summary>
        /// <param name="dType"></param>
        /// <returns></returns>
        private Image GetCorrectDeviceIcon(NetworkDeviceType dType)
        {
            switch(dType)
            {
                case NetworkDeviceType.Desktop:
                    return Resources.icon_desktop;

                case NetworkDeviceType.MobilePhone:
                    return Resources.icon_phone;

                default:
                    return null;
            }
        }

        /// <summary>
        /// Adds a network device to the list
        /// </summary>
        /// <param name="device"></param>
        public void AddNewNetworkDevice(NetworkDevice device)
        {
            DeviceGUIObject guiObject = new DeviceGUIObject();

            guiObject.Device = device;

            // Panels
            int xStart = 0;
            int yStart = 0;
            int xSeparation = 90;
            int ySeparation = 90;

            guiObject.panel_Main = new Panel()
            {
                Location = new Point(xStart + DevicesCount * xSeparation, 
                                     yStart + (int)Math.Floor((decimal)DevicesCount / 7) * ySeparation),
                Size = new Size(100, 100)
            };

            guiObject.btn_Device = new Button()
            {
                Size = new Size(65, 65),
                Location = new Point(16, 3),
                BackgroundImage = GetCorrectDeviceIcon(device.Type),
                BackgroundImageLayout = ImageLayout.Stretch,
                Text = "",
                Name = "btn_Device_1"
            };

            guiObject.label_DeviceName = new Label()
            {
                Location = new Point(5, 71),
                Size = new Size(90, 13),
                Text = device.Name,
                TextAlign = ContentAlignment.MiddleCenter,
                AutoSize = false
                
            };



            guiObject.btn_Device.Click += (sender, args) =>
            {
                DeviceClicked(device);
            };

            guiObject.panel_Main.Controls.Add(guiObject.btn_Device);
            guiObject.panel_Main.Controls.Add(guiObject.label_DeviceName);

            
            // Cannot update from outside the thread
            if (panel_NetworkDevices.InvokeRequired)
            {
               panel_NetworkDevices.BeginInvoke((MethodInvoker)delegate ()
               {
                   panel_NetworkDevices.Controls.Add(guiObject.panel_Main);
               });
            }

            // panel_NetworkDevices.Controls.Add(panel_Main);

            ActiveDeviceGUIOBjects.Add(guiObject);

            DevicesCount++;
        }

        private void ResetGUIDevices()
        {
            for (int i = 0; i < ActiveDeviceGUIOBjects.Count; i++)
            {
                panel_NetworkDevices.Controls.Remove(ActiveDeviceGUIOBjects[i].panel_Main);
            }

            ActiveDeviceGUIOBjects = new List<DeviceGUIObject>();
        }

        private void DeviceClicked(NetworkDevice device)
        {
            DevicePage dp = new DevicePage(device, this);
            // Hide the main form
            this.Hide();
            // Show the Device Page as a dialog
            dp.ShowDialog();
        }



        private void btn_RefreshNetwork_Click(object sender, EventArgs e)
        {
            DevicesCount = 0;
            ResetGUIDevices();
            NetComm.ScoutNetworkDevices();
        }

        private void MainPage_Resize(object sender, EventArgs e)
        {
            // Send it to the tray when minimized
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                tray_icon.Visible = true;
            }
        }

       

        private void tray_icon_MouseClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            tray_icon.Visible = false;
        }

        

        private void startup_CheckBox_Changed(object sender, EventArgs e)
        {
            if(startup_Checkbox.CheckState == CheckState.Checked)
            {
                AddToWindowsStartup();
            }
            else
            {
                RemoveFromWindowsStartup();
            }
        }

        private void AddToWindowsStartup()
        {
            if (rkApp.GetValue("FileJump") == null)
            {
                rkApp.SetValue("FileJump", Application.ExecutablePath);
            }
        }

        private void RemoveFromWindowsStartup()
        {
            if(rkApp.GetValue("FileJump") != null)
            {
                // Remove the value from the registry so that the application doesn't start
                rkApp.DeleteValue("FileJump", false);
            }
        }

        private void ChangeDeviceName(string name)
        {
            ProgramSettings.DeviceName = name;
            Properties.Settings.Default["MachineName"] = name;
            label_DeviceName.Text = name;

        }

        private void ChangeDestinationFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            ProgramSettings.StorageFolderPath = path;
            Properties.Settings.Default["DestinationFolder"] = path;
            label_ChosenFolder.Text = path;
        }

        private void btn_EditName_Click(object sender, EventArgs e)
        {
            string input = Microsoft.VisualBasic.Interaction.InputBox("Prompt",
                "New Machine Name",
                ProgramSettings.DeviceName,
                200,
                200);

            ChangeDeviceName(input);
        }

        private void btn_EditFolder_Click(object sender, EventArgs e)
        {
            dialog_ChooseFolder.ShowDialog();
            string folderPath = dialog_ChooseFolder.SelectedPath;
            ProgramSettings.StorageFolderPath = folderPath;
            Properties.Settings.Default["DestinationFolder"] = folderPath;
            label_ChosenFolder.Text = folderPath;
        }

        private void btn_OpenFolder_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(ProgramSettings.StorageFolderPath);
        }

        // BALOON TIP // 

        public void ShowBaloonTooltip(string msg)
        {
            // Don't show it twice if already active
            if (IsBaloonTipActive)
            {
                return;
            }

            tray_icon.BalloonTipText = msg;
            tray_icon.ShowBalloonTip(1);
        }

        private void Tray_icon_BalloonTipClicked(object sender, EventArgs e)
        {
            if(BaloonToolTipDestination == 0)
            {
                System.Diagnostics.Process.Start(ProgramSettings.StorageFolderPath);
            }
            
        }

        private void Tray_icon_BalloonTipClosed(object sender, EventArgs e)
        {
            IsBaloonTipActive = false;
        }

        private void Tray_icon_BalloonTipShown(object sender, EventArgs e)
        {
            IsBaloonTipActive = true;
        }
        
        private void btn_ShowMessages_Click(object sender, EventArgs e)
        {
          
            int expandWidth = 290;

            if (!ShowingMessages)
            {
                ShowingMessages = true;
                this.Width += expandWidth;
                btn_ShowMessages.BackgroundImage = Resources.icon_expand_gray_left;

                ShowMessagesList();

            } else
            {
                ShowingMessages = false;
                this.Width -= expandWidth;
                btn_ShowMessages.BackgroundImage = Resources.icon_expand_gray_right;
            }
            
            
        }

        private void ShowMessagesList()
        {
            this.Controls.Remove(Messages_ParentPanel);

            Messages_ParentPanel = new Panel()
            {
                Size = new Size(280, this.Height - 20),
                BackColor = Color.Transparent,
                Location = new Point(FormOriginalWidth - 10, 5),
            };



            Messages_FlowLayoutPanel = new FlowLayoutPanel()
            {
                Width = Messages_ParentPanel.Width + SystemInformation.VerticalScrollBarWidth,
                Height = Messages_ParentPanel.Height - 5,
                BackColor = this.BackColor,
                Location = new Point(0, 0),
                BorderStyle = BorderStyle.Fixed3D,
                AutoScroll = true,
                AutoSize = false,
            };

            Messages_ParentPanel.Controls.Add(Messages_FlowLayoutPanel);

            this.Controls.Add(Messages_ParentPanel);

            // Load the messages from the xml database
            MessagesList = LoadMessages();

            foreach (TextMessage tm in MessagesList)
            {
                AddTextMessage(tm, Messages_FlowLayoutPanel);
            }
        }


        /// <summary>
        /// Adds a text message GUI object to the selected control
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="_control"></param>
        private void AddTextMessage(TextMessage msg, Control _control)
        {
            Panel mainPanel = new Panel()
            {
                BackColor = Color.Gray,
                Size = new Size(_control.Width - 5, 50)
            };

            Button btn_Delete = new Button()
            {
                Location = new Point(3, 8),
                BackgroundImage = Resources.delete,
                BackgroundImageLayout = ImageLayout.Stretch,
                Size = new Size(35, 35),
                FlatStyle = FlatStyle.Flat,
            };
            
            btn_Delete.Click += (sender, args) =>
            {
                FileHandler.RemoveXmlDatabaseElement(msg.ID);
                // Refresh the visual
                this.Controls.Remove(Messages_ParentPanel);
                ShowMessagesList();
            };
            
            
            mainPanel.Controls.Add(btn_Delete);


            Label lbl_date = new Label()
            {
                Location = new Point(40, 0),
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Black,
                BackColor = Color.Gray,
                Text = msg.DateSent,
                Height = 14,
            };

            mainPanel.Controls.Add(lbl_date);

            TextBox tBox = new TextBox()
            {
                BorderStyle = BorderStyle.Fixed3D,
                Location = new Point(btn_Delete.Location.X + btn_Delete.Width + 4, 20),
                TextAlign = HorizontalAlignment.Center,
                Size = new Size(150, 25),
                ReadOnly = true,
                BackColor = Color.DarkGray,
                Text = msg.Message
            };

            mainPanel.Controls.Add(tBox);


            Button btn_CopyClipboard = new Button()
            {
                Location = new Point(tBox.Location.X + tBox.Size.Width + 3, 8),
                Size = new Size(35, 35),
                BackgroundImage = Resources.icon_copy_clipboard_empty,
                BackgroundImageLayout = ImageLayout.Stretch,
                Text = ""
            };

            btn_CopyClipboard.Click += (sender, args) => {

                CopyToClipboard(msg);
            };

            mainPanel.Controls.Add(btn_CopyClipboard);
            
            Button btn_Expand = new Button()
            {
                Location = new Point(btn_CopyClipboard.Location.X + btn_CopyClipboard.Size.Width + 5, 8),
                Size = new Size(35, 35),
                BackgroundImage = Resources.icon_expand_gray_right,
                BackgroundImageLayout = ImageLayout.Stretch,
                Text = ""
            };

            btn_Expand.Click += (sender, args) =>
            {
                ExpandText(msg.Message);
            };
            
            mainPanel.Controls.Add(btn_Expand);
            
            _control.Controls.Add(mainPanel);
        }

        private List<TextMessage> LoadMessages()
        {
            return FileHandler.ReadXmlDatabase();
        }

        private void ExpandText(string txt)
        {
            MessageExpandForm msgForm = new MessageExpandForm(txt);

            msgForm.ShowDialog();


        }

        private void CopyToClipboard(TextMessage t)
        {
            Clipboard.SetText(t.Message);
        }


        private void mainForm_Location_Changed(object sender, EventArgs e)
        {

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Green, ButtonBorderStyle.Solid);
        }


        private void TopBar_MouseMove(object sender, MouseEventArgs e)
        {
            // Top panel hack
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void btn_Topbar_Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btn_Topbar_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            Hide();
            tray_icon.Visible = true;
        }

        private void btn_Account_Click(object sender, EventArgs e)
        {
            LoginPage login = new LoginPage();
            login.ShowDialog();
        }
    }
}
