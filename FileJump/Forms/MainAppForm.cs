﻿using FileJump.CustomControls;
using FileJump.FormElements;
using FileJump.GUI;
using FileJump.Network;
using FileJump.Settings;
using FileJump_Network.EventSystem;
using FileJump_Network.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileJump.Forms
{
    public partial class MainAppForm : Form
    {
        // top bar hack
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]

        public static extern bool ReleaseCapture();

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        // end top bar hack

        // Network functionality

        private RegistryKey rkApp { get; set; }

        // end

        // Left menu
        private HighlightPanel[] LeftButtonPanels;

        // Main 
        private Panel DynamicPagePanel { get; set; }
        private Panel CurrentActivePagePanel { get; set; }

        private int CurrentSelectedPage { get; set; }

        private bool IsBaloonTipActive { get; set; }

        private int BaloonToolTipType { get; set; } = 0; // 0 = folder, 1 = messages


        public MainAppForm()
        {
            InitializeComponent();
            





            InitializeNetwork();

            // Events


            DataProcessor.IncomingTransferFinished += IncomingTransferFinished;
            //DataProcessor.InboundTextTransferFinished += InboundTextTransferFinished;

            //ApiCommunication.LoginActionResult += LoginResultEvent;
            //ApiCommunication.LogoutActionResult += LogoutResultEvent;

            // Default starting with Device panel
           


            // UI 

            InitializeMainUI(); // Left panel, topbar, etc

            CreateDynamicPanel(); // The panel that holds the main pages
            ChangePage(0); // Local device


            TickTimer.Tick += TickTock;
            TickTimer.Start();

            // Notifications settings
            tray_Icon.BalloonTipShown += Tray_icon_BalloonTipShown;
            tray_Icon.BalloonTipClosed += Tray_icon_BalloonTipClosed;
            tray_Icon.BalloonTipClicked += Tray_icon_BalloonTipClicked;

            ApiCommunication.LoginActionResult += LoginResultEvent;
            ApiCommunication.LogoutActionResult += LogoutResultEvent;

            UserSettings.LoggedOn = false;
            CheckIfShouldPerformLogin();
        }



        private void InitializeNetwork()
        {
            // Get the correct registry key for startup
            rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);


            // Settings
#if DEBUG
            ChangeDestinationFolder("C:/FileJumpFolder");
            ChangeDeviceName("CARLO_BB");
            UserSettings.DeviceType = 1; // HARDCODED. Desktop application
#else


            UserSettings.DeviceType = 1; // HARDCODED. Desktop application

            if (UserSettings.MachineName == "NULL")
            {
                ChangeDeviceName(Environment.MachineName);
            }

            // If the destination folder has not been specified, use the default one (main folder / Incoming Files)

            if (!Directory.Exists(UserSettings.DestinationFolder))
            {
                ChangeDestinationFolder(Path.Combine(Directory.GetCurrentDirectory(), "Incoming Files"));
            }

            // // Check the startup setting
            //if (UserSettings.RunOnStartUp == true)
            //{
            //    startup_Checkbox.CheckState = CheckState.Checked; // This also automatically runs AddToStartup which checks if it is running on startup,
            //}                                                     // else it adds it.  
            //else
            //{
            //    startup_Checkbox.CheckState = CheckState.Unchecked; // This runs the remove check
            //}

#endif

            NetComm.InitializeNetwork(UserSettings.MachineName, UserSettings.DeviceType, UserSettings.DestinationFolder, new FileHandler());



        }

        private void IncomingTransferFinished(object sender, InboundTransferEventArgs args)
        {
            // Show the baloon tooltip
            BaloonToolTipType = 0;
            ShowBaloonTooltip("File(s) received");
        }



        private void InitializeMainUI()
        {
            // Set the overall background color of the program
            this.BackColor = GUITools.COLOR_DarkMode_Light;

            //
            // The Left menu panel
            //

            panel_MainLeft.Location = new Point(0, 0);
            panel_MainLeft.Size = new Size((int)((decimal)this.Width / 4M), this.Height);
            panel_MainLeft.BackColor = GUITools.COLOR_DarkMode_Dark;

            Panel panel_Logo = new Panel();
            panel_Logo.Size = new Size((int)((decimal)panel_MainLeft.Width / 2), (int)((decimal)panel_MainLeft.Width / 2));
            panel_Logo.Location = new Point(panel_MainLeft.Width / 2 - panel_Logo.Width / 2, 20);
            panel_Logo.BackgroundImage = Properties.Resources.dark_logo_main;
            panel_Logo.BackgroundImageLayout = ImageLayout.Stretch;

            panel_MainLeft.Controls.Add(panel_Logo);

            panel_MainLeft.Paint += PaintLeftPanel;

            int LeftButtonSpacing = 50;
            int LeftButtonsStartY = 200;
            int curY = LeftButtonsStartY;


            LeftButtonPanels = new HighlightPanel[5];

            HighlightPanel hp1 =  CreateLeftButton("Local Devices", new Point(0, curY), 0);

            panel_MainLeft.Controls.Add(hp1.MainPanel);
            LeftButtonPanels[0] = hp1;

            curY += LeftButtonSpacing;

            //
            //
            //

            HighlightPanel hp2 = CreateLeftButton("Online Storage", new Point(0, curY), 1);

            panel_MainLeft.Controls.Add(hp2.MainPanel);
            LeftButtonPanels[1] = hp2;

            curY += LeftButtonSpacing;

            //
            //
            //

            HighlightPanel hp3 = CreateLeftButton("Upload Files", new Point(0, curY), 2);

            panel_MainLeft.Controls.Add(hp3.MainPanel);
            LeftButtonPanels[2] = hp3;

            curY += LeftButtonSpacing;

            //
            // Lower section
            //

            curY += 150;

            HighlightPanel hp4 = CreateLeftButton("Account", new Point(0, curY), 3);

            panel_MainLeft.Controls.Add(hp4.MainPanel);
            LeftButtonPanels[3] = hp4;

            curY += LeftButtonSpacing;

            HighlightPanel hp5 = CreateLeftButton("Settings", new Point(0, curY), 4);

            panel_MainLeft.Controls.Add(hp5.MainPanel);
            LeftButtonPanels[4] = hp5;



            // This needs to be AFTER the left panel initialization
            InitializeTopBar();





        }

        private void CreateTitlePanel(string text, Panel MainPanel)
        {
            Panel panel_Main = new Panel();
            panel_Main.Size = new Size((int)((decimal)MainPanel.Width / 2M), 70);
            panel_Main.Location = new Point(MainPanel.Width / 2 - panel_Main.Width / 2, 28); // 23 is the height of the TopBar, have to hard code it here for now
            panel_Main.BackColor = Color.Transparent;

            panel_Main.Paint += (sender, args) =>
            {
                args.Graphics.DrawRectangle(new Pen(GUITools.COLOR_Controls_Border, 1), new Rectangle(0, 0, panel_Main.Width - 1, panel_Main.Height - 1));
                args.Graphics.DrawRectangle(new Pen(GUITools.COLOR_Dividers_Dark, 5), new Rectangle(1, 1, panel_Main.Width - 6, panel_Main.Height - 6));
            };

            Label label_Text = new Label();
            label_Text.AutoSize = true;
            label_Text.Font = new Font("Arial", 22, FontStyle.Bold, GraphicsUnit.Pixel);
            label_Text.Text = "Local File Transfer";

            Size textSize = TextRenderer.MeasureText(label_Text.Text, label_Text.Font);

            label_Text.Location = new Point((panel_Main.Width / 2) - textSize.Width / 2,
                (panel_Main.Height / 2) - textSize.Height / 2);

            label_Text.ForeColor = GUITools.COLOR_DarkMode_Text_Light;
            panel_Main.Controls.Add(label_Text);

            MainPanel.Controls.Add(panel_Main);
        }

        private void PaintLeftPanel(object sender, PaintEventArgs e)
        {
            int div_Horizontal_Height = 170;
            int thickness = 1;
            //Pen lightPen = new Pen(GUITools.COLOR_Dividers_Light, thickness);
            Pen lightPen = new Pen(GUITools.COLOR_Dividers_Light, thickness);
            Pen darkPen = new Pen(GUITools.COLOR_Dividers_Dark, thickness);
            Pen fillPen = new Pen(Color.FromArgb(255, 25, 27, 38), thickness);

            // Bottom light
            e.Graphics.DrawRectangle(lightPen, new Rectangle(-2,
                                                             div_Horizontal_Height,
                                                             panel_MainLeft.Width - thickness,
                                                             panel_MainLeft.Height - div_Horizontal_Height + 10));


            // Top light
            e.Graphics.DrawRectangle(lightPen, new Rectangle(-2,
                                                             -2,
                                                             panel_MainLeft.Width - thickness, 
                                                             div_Horizontal_Height + 2 - thickness * 2));

            // Vertical right light line
            e.Graphics.DrawLine(lightPen, new Point(panel_MainLeft.Width - thickness, 0), new Point(panel_MainLeft.Width - thickness, panel_MainLeft.Height));

            // Fillings
            e.Graphics.DrawLine(fillPen, new Point(0, div_Horizontal_Height - thickness ), new Point(panel_MainLeft.Width - thickness * 2, div_Horizontal_Height - thickness ));
            e.Graphics.DrawLine(fillPen, new Point(panel_MainLeft.Width - thickness * 2, 0), new Point(panel_MainLeft.Width - thickness * 2, panel_MainLeft.Height));



        }

        private HighlightPanel CreateLeftButton(string text, Point location, int id)
        {
            HighlightPanel hPanel = new HighlightPanel();

            Panel panel1 = new Panel();
            panel1.BackColor = Color.Transparent;
            panel1.Width = panel_MainLeft.Width;
            panel1.Location = location; // Start at Y 160
            panel1.Height = 40;

            hPanel.MainPanel = panel1;

            Panel panel_Highlight1 = new Panel();
            panel_Highlight1.Width = 0;
            panel_Highlight1.Height = panel1.Height;
            panel_Highlight1.BackColor = Color.FromArgb(255, 3, 173, 196);

            hPanel.PopupPanel = panel_Highlight1;

            Label label1 = new Label();
            label1.Font = new Font("Arial", 16, FontStyle.Bold, GraphicsUnit.Pixel);
            label1.Location = new Point(50, panel1.Height / 3); // 21 is the max size of the highlight panel, so little more than that
            label1.ForeColor = GUITools.COLOR_DarkMode_Text_Light;
            label1.Width = panel1.Width - label1.Location.X;
            label1.Text = text;

            hPanel.TextLabel = label1;

            panel1.Controls.Add(panel_Highlight1);
            panel1.Controls.Add(label1);

            TransparentControl panel_MouseInteraction = new TransparentControl();

            panel_MouseInteraction.Size = panel1.Size;
            panel_MouseInteraction.Location = new Point(0, 0);
            panel_MouseInteraction.BackColor = Color.Transparent;


            panel_MouseInteraction.MouseEnter += (sender, args) =>
            {
                panel_MouseInteraction.Cursor = Cursors.Hand;
                hPanel.IsHighlighted = true;
            };

            panel_MouseInteraction.MouseLeave += (sender, args) =>
            {
                panel_MouseInteraction.Cursor = Cursors.Arrow;
                hPanel.IsHighlighted = false;
            };

            panel_MouseInteraction.MouseClick += (sender, args) =>
            {
                LeftButtonClickEvent(id);
            };

            panel1.Controls.Add(panel_MouseInteraction);

            panel_MouseInteraction.BringToFront();

            return hPanel;

        }

        public void LoadAccountPage(string subpage)
        {
            for (int i = 0; i < LeftButtonPanels.Length; i++)
            {
                LeftButtonPanels[i].IsHighlighted = false;
                LeftButtonPanels[i].IsSelected = false;
            }

            LeftButtonPanels[3].IsHighlighted = true;
            LeftButtonPanels[3].IsSelected = true;

            CurrentSelectedPage = 3;

            DynamicPagePanel.Controls.Clear();

            AccountFormElement sfe = new AccountFormElement();

            int id = -1;

            // Failsafe. if id stays -1, it loads the main page anyway
            if (subpage.Equals("Registration")) id = 0;

            if (subpage.Equals("Login")) id = 1;

            CurrentActivePagePanel =  sfe.CreateAccountPanel(new Point(0, 0),
                                           DynamicPagePanel.Width,
                                           DynamicPagePanel.Height,
                                           this, id);

            DynamicPagePanel.Controls.Add(CurrentActivePagePanel);




        }

        private void ChangePage(int pageID)
        {
            if (pageID >= LeftButtonPanels.Length) return;

            for (int i = 0; i < LeftButtonPanels.Length; i++)
            {
                LeftButtonPanels[i].IsHighlighted = false;
                LeftButtonPanels[i].IsSelected = false;
            }

            LeftButtonPanels[pageID].IsHighlighted = true;
            LeftButtonPanels[pageID].IsSelected = true;

            CurrentSelectedPage = pageID;

            DynamicPagePanel.Controls.Clear();

            switch (pageID)
            {
                case 0: // LOCAL DEVICES
                   CurrentActivePagePanel = CreateLocalDevicePanel();
                    break;

                case 1: // ONLINE STORAGE
                    CurrentActivePagePanel = CreateOnlineStoragePage();
                    break;
                case 3: // ACCOUNT PAGE
                    CurrentActivePagePanel = CreateAccountPanel(); 
                    break;

                case 4: // SETTINGS
                    CurrentActivePagePanel = CreateSettingsPanel();
                    break;
                default:
                    CurrentActivePagePanel = null;
                    break;

            }

            DynamicPagePanel.Controls.Add(CurrentActivePagePanel);
        }

        private void LeftButtonClickEvent(int id)
        {
            if (CurrentSelectedPage == id) return;

            ChangePage(id);
        }

        private void CreateDynamicPanel()
        {
            DynamicPagePanel = new Panel();
            DynamicPagePanel.Location = new Point(panel_MainLeft.Width, panel_TopBar.Height);
            DynamicPagePanel.Size = new Size(this.Width - panel_MainLeft.Width,
                                           this.Height - panel_TopBar.Height);
            this.Controls.Add(DynamicPagePanel);
        }

        private Panel CreateOnlineStoragePage()
        {

            OnlineStorageFormElement sfe = new OnlineStorageFormElement();

            return sfe.CreateOnlineStoragePage(new Point(0, 0),
                                           DynamicPagePanel.Width,
                                           DynamicPagePanel.Height,
                                           this);

        }

        private Panel CreateAccountPanel()
        {
            AccountFormElement sfe = new AccountFormElement();

            return sfe.CreateAccountPanel(new Point(0, 0),
                                           DynamicPagePanel.Width,
                                           DynamicPagePanel.Height,
                                           this);
        }

        private Panel CreateSettingsPanel()
        {
            SettingsFormElement sfe = new SettingsFormElement();

            return sfe.CreateSettingsPanel(new Point(0, 0),
                                           DynamicPagePanel.Width,
                                           DynamicPagePanel.Height,
                                           this);
        }

        private Panel CreateLocalDevicePanel()
        {


            LocalDevicesFormElement lde = new LocalDevicesFormElement();


            return lde.CreateLocalDevicesElement(new Point(0, 0),
                                           DynamicPagePanel.Width,
                                           DynamicPagePanel.Height,
                                           this);

            CreateTitlePanel("Local File Transfer", CurrentActivePagePanel);
        }

        private void TickTock(object sender, EventArgs e)
        {
            for (int i = 0; i < LeftButtonPanels.Length; i++)
            {
                if(LeftButtonPanels[i].IsHighlighted || LeftButtonPanels[i].IsSelected)
                {
                    // increase
                    int newWidth = LeftButtonPanels[i].PopupPanel.Width + 2;
                    if (newWidth > 21) newWidth = 21;

                    LeftButtonPanels[i].PopupPanel.Width = newWidth;
                }
                else
                {
                    // decrease
                    if (LeftButtonPanels[i].PopupPanel.Width > 0)
                    {
                        int newWidth2 = LeftButtonPanels[i].PopupPanel.Width - 2;
                        if (newWidth2 < 0) newWidth2 = 0;
                        LeftButtonPanels[i].PopupPanel.Width = newWidth2;
                    }
                }


               
            }
        }

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

        // 
        // TOP BAR
        //

        private void InitializeTopBar()
        {
            panel_TopBar.Location = new Point(panel_MainLeft.Location.X + panel_MainLeft.Width, 0);
            panel_TopBar.Size = new Size(this.Width - panel_MainLeft.Width, 23);
            panel_TopBar.BackColor = GUITools.COLOR_Dividers_Light;
            panel_TopBar.MouseMove += TopBarMouseMove;
            btn_Topbar_Close.Location = new Point(btn_Topbar_Close.Parent.Width - btn_Topbar_Close.Size.Width, 0);
            btn_Topbar_Minimize.Location = new Point(btn_Topbar_Close.Location.X - btn_Topbar_Minimize.Size.Width, 0);

            btn_Topbar_Close.Click += btn_Topbar_Close_Click;
            btn_Topbar_Minimize.Click += btn_Topbar_Minimize_Click;

            btn_Topbar_Close.MouseEnter += OnTopBarButtonEnter;
            btn_Topbar_Close.MouseLeave += OnTopBarButtonLeave;

            btn_Topbar_Minimize.MouseEnter += OnTopBarButtonEnter;
            btn_Topbar_Minimize.MouseLeave += OnTopBarButtonLeave;

        }

        private void TopBarMouseMove(object sender, MouseEventArgs e)
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
            this.Close();

        }

        private void btn_Topbar_Minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void OnTopBarButtonEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (btn == null)
            {
                return;
            }

            btn.BackColor = Color.FromArgb(255, 96, 100, 120);
        }

        private void OnTopBarButtonLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (btn == null)
            {
                return;
            }

            btn.BackColor = Color.Transparent;
        }

        /////////////////////////// EVENTS ////////////////////////////////
        ///
        private void LogoutResultEvent(object sender, LogoutResultEventArgs args)
        {
            if (args.Successful)
            {
                LogOutAction();
            }
        }

        private void LoginResultEvent(object sender, LoginResultEventArgs args)
        {
            if (args.Successful)
            {
                PerformSuccessfulLogin(args.AccountData);
            }
        }

        private void CheckIfShouldPerformLogin()
        {
            // Self explanatory
            if (!UserSettings.RememberLogin)
            {
                return;
            }

            // Check if the email and pw are saved (should be at this point) and perform login
            if (UserSettings.UserEmail.Length > 0 && UserSettings.UserPassword.Length > 0)
            {
                ApiCommunication.SendLoginRequest(UserSettings.UserEmail, UserSettings.UserPassword);
            }
        }

        public void PerformSuccessfulLogin(AccountInfoModel accountModel)
        {
            UserSettings.UserEmail = accountModel.Email;
            UserSettings.UserFirstName = accountModel.FirstName;
            UserSettings.UserLastName = accountModel.LastName;
            UserSettings.UserAccessToken = accountModel.Accesstoken;
            UserSettings.LoggedOn = true;
        }

        public void LogOutAction()
        {
            UserSettings.ClearUserSettings();
        }

        private void InboundTextTransferFinished(object sender, InboundTextTransferEventArgs args)
        {
            // Add the message to the database
            FileHandler _fHandler = new FileHandler();
            _fHandler.AddNewMessageToXML(args.Message, DateTime.Now.ToString());

            // Show the baloon tooltip
            BaloonToolTipType = 1;
            ShowBaloonTooltip("New message received!");
        }




        // SETTINGS

        private void ChangeDestinationFolder(string path)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            UserSettings.DestinationFolder = path;
        }

        private void ChangeDeviceName(string name)
        {
            UserSettings.MachineName = name;
        }

        // BALOON TIP // 

        public void ShowBaloonTooltip(string msg)
        {
            // Don't show it twice if already active
            if (IsBaloonTipActive)
            {
                return;
            }

            tray_Icon.BalloonTipText = msg;
            tray_Icon.ShowBalloonTip(1);
        }

        private void Tray_icon_BalloonTipClicked(object sender, EventArgs e)
        {
            if (BaloonToolTipType == 0)
            {
                System.Diagnostics.Process.Start(ProgramSettings.StorageFolderPath);
            }

            IsBaloonTipActive = false;

        }

        private void Tray_icon_BalloonTipClosed(object sender, EventArgs e)
        {
            IsBaloonTipActive = false;
        }

        private void Tray_icon_BalloonTipShown(object sender, EventArgs e)
        {
            IsBaloonTipActive = true;
        }
    }
}
