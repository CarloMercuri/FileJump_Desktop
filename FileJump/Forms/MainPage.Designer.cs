
namespace FileJump
{
    partial class MainPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.panel_NetworkDevices = new System.Windows.Forms.Panel();
            this.dialog_ChooseFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_RefreshNetwork = new System.Windows.Forms.Button();
            this.tray_icon = new System.Windows.Forms.NotifyIcon(this.components);
            this.startup_Checkbox = new System.Windows.Forms.CheckBox();
            this.dialog_openFiles = new System.Windows.Forms.OpenFileDialog();
            this.btn_EditName = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_EditFolder = new System.Windows.Forms.Button();
            this.btn_ShowMessages = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panel_TopBar = new System.Windows.Forms.Panel();
            this.btn_Topbar_Minimize = new System.Windows.Forms.Button();
            this.btn_Topbar_Close = new System.Windows.Forms.Button();
            this.btn_Account = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label_DeviceName = new System.Windows.Forms.Label();
            this.panel_DeviceName = new System.Windows.Forms.Panel();
            this.label_ChosenFolder = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label_LoggedInText = new System.Windows.Forms.Label();
            this.btn_Register = new System.Windows.Forms.Button();
            this.panel_RegisterLogin = new System.Windows.Forms.Panel();
            this.btn_Login = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_OnlineFiles = new System.Windows.Forms.Button();
            this.btn_OnlineUpload = new System.Windows.Forms.Button();
            this.panel_TopBar.SuspendLayout();
            this.panel_DeviceName.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel_RegisterLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_NetworkDevices
            // 
            this.panel_NetworkDevices.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(224)))), ((int)(((byte)(190)))));
            this.panel_NetworkDevices.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel_NetworkDevices.Location = new System.Drawing.Point(16, 258);
            this.panel_NetworkDevices.Margin = new System.Windows.Forms.Padding(4);
            this.panel_NetworkDevices.Name = "panel_NetworkDevices";
            this.panel_NetworkDevices.Size = new System.Drawing.Size(801, 336);
            this.panel_NetworkDevices.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label1.Location = new System.Drawing.Point(21, 59);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 22);
            this.label1.TabIndex = 4;
            this.label1.Text = "Shared Folder";
            // 
            // btn_RefreshNetwork
            // 
            this.btn_RefreshNetwork.BackColor = System.Drawing.Color.White;
            this.btn_RefreshNetwork.FlatAppearance.BorderSize = 0;
            this.btn_RefreshNetwork.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_RefreshNetwork.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_RefreshNetwork.ForeColor = System.Drawing.Color.Black;
            this.btn_RefreshNetwork.Location = new System.Drawing.Point(369, 186);
            this.btn_RefreshNetwork.Margin = new System.Windows.Forms.Padding(4);
            this.btn_RefreshNetwork.Name = "btn_RefreshNetwork";
            this.btn_RefreshNetwork.Size = new System.Drawing.Size(109, 60);
            this.btn_RefreshNetwork.TabIndex = 5;
            this.btn_RefreshNetwork.Text = "Refresh\r\nDevices\r\n";
            this.btn_RefreshNetwork.UseVisualStyleBackColor = false;
            this.btn_RefreshNetwork.Click += new System.EventHandler(this.btn_RefreshNetwork_Click);
            // 
            // tray_icon
            // 
            this.tray_icon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.tray_icon.BalloonTipTitle = "Transfer Complete";
            this.tray_icon.Icon = ((System.Drawing.Icon)(resources.GetObject("tray_icon.Icon")));
            this.tray_icon.Text = "notifyIcon1";
            this.tray_icon.Visible = true;
            this.tray_icon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tray_icon_MouseClick);
            // 
            // startup_Checkbox
            // 
            this.startup_Checkbox.AutoSize = true;
            this.startup_Checkbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startup_Checkbox.ForeColor = System.Drawing.SystemColors.GrayText;
            this.startup_Checkbox.Location = new System.Drawing.Point(21, 29);
            this.startup_Checkbox.Margin = new System.Windows.Forms.Padding(4);
            this.startup_Checkbox.Name = "startup_Checkbox";
            this.startup_Checkbox.Size = new System.Drawing.Size(153, 26);
            this.startup_Checkbox.TabIndex = 6;
            this.startup_Checkbox.Text = "Run on Startup";
            this.startup_Checkbox.UseVisualStyleBackColor = true;
            this.startup_Checkbox.CheckedChanged += new System.EventHandler(this.startup_CheckBox_Changed);
            // 
            // dialog_openFiles
            // 
            this.dialog_openFiles.FileName = "openFileDialog1";
            this.dialog_openFiles.Multiselect = true;
            // 
            // btn_EditName
            // 
            this.btn_EditName.BackColor = System.Drawing.Color.White;
            this.btn_EditName.FlatAppearance.BorderSize = 0;
            this.btn_EditName.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_EditName.Location = new System.Drawing.Point(275, 188);
            this.btn_EditName.Margin = new System.Windows.Forms.Padding(4);
            this.btn_EditName.Name = "btn_EditName";
            this.btn_EditName.Size = new System.Drawing.Size(69, 30);
            this.btn_EditName.TabIndex = 7;
            this.btn_EditName.Text = "Edit";
            this.btn_EditName.UseVisualStyleBackColor = false;
            this.btn_EditName.Click += new System.EventHandler(this.btn_EditName_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label2.Location = new System.Drawing.Point(21, 148);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 22);
            this.label2.TabIndex = 8;
            this.label2.Text = "Device Name";
            // 
            // btn_EditFolder
            // 
            this.btn_EditFolder.BackColor = System.Drawing.Color.White;
            this.btn_EditFolder.FlatAppearance.BorderSize = 0;
            this.btn_EditFolder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_EditFolder.Location = new System.Drawing.Point(275, 95);
            this.btn_EditFolder.Margin = new System.Windows.Forms.Padding(4);
            this.btn_EditFolder.Name = "btn_EditFolder";
            this.btn_EditFolder.Size = new System.Drawing.Size(64, 31);
            this.btn_EditFolder.TabIndex = 10;
            this.btn_EditFolder.Text = "Edit";
            this.btn_EditFolder.UseVisualStyleBackColor = false;
            this.btn_EditFolder.Click += new System.EventHandler(this.btn_EditFolder_Click);
            // 
            // btn_ShowMessages
            // 
            this.btn_ShowMessages.BackColor = System.Drawing.Color.Transparent;
            this.btn_ShowMessages.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_ShowMessages.BackgroundImage")));
            this.btn_ShowMessages.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_ShowMessages.FlatAppearance.BorderSize = 0;
            this.btn_ShowMessages.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_ShowMessages.Location = new System.Drawing.Point(745, 185);
            this.btn_ShowMessages.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_ShowMessages.Name = "btn_ShowMessages";
            this.btn_ShowMessages.Size = new System.Drawing.Size(72, 43);
            this.btn_ShowMessages.TabIndex = 11;
            this.btn_ShowMessages.UseVisualStyleBackColor = false;
            this.btn_ShowMessages.Click += new System.EventHandler(this.btn_ShowMessages_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(725, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 28);
            this.label4.TabIndex = 12;
            this.label4.Text = "Messages";
            // 
            // panel_TopBar
            // 
            this.panel_TopBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(198)))), ((int)(((byte)(127)))));
            this.panel_TopBar.Controls.Add(this.btn_Topbar_Minimize);
            this.panel_TopBar.Controls.Add(this.btn_Topbar_Close);
            this.panel_TopBar.Location = new System.Drawing.Point(3, 3);
            this.panel_TopBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_TopBar.Name = "panel_TopBar";
            this.panel_TopBar.Size = new System.Drawing.Size(825, 28);
            this.panel_TopBar.TabIndex = 13;
            this.panel_TopBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TopBar_MouseMove);
            // 
            // btn_Topbar_Minimize
            // 
            this.btn_Topbar_Minimize.BackColor = System.Drawing.Color.Transparent;
            this.btn_Topbar_Minimize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Topbar_Minimize.BackgroundImage")));
            this.btn_Topbar_Minimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_Topbar_Minimize.FlatAppearance.BorderSize = 0;
            this.btn_Topbar_Minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Topbar_Minimize.Location = new System.Drawing.Point(713, 0);
            this.btn_Topbar_Minimize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Topbar_Minimize.Name = "btn_Topbar_Minimize";
            this.btn_Topbar_Minimize.Size = new System.Drawing.Size(59, 27);
            this.btn_Topbar_Minimize.TabIndex = 14;
            this.btn_Topbar_Minimize.UseVisualStyleBackColor = false;
            this.btn_Topbar_Minimize.Click += new System.EventHandler(this.btn_Topbar_Minimize_Click);
            // 
            // btn_Topbar_Close
            // 
            this.btn_Topbar_Close.BackColor = System.Drawing.Color.Transparent;
            this.btn_Topbar_Close.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Topbar_Close.BackgroundImage")));
            this.btn_Topbar_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_Topbar_Close.FlatAppearance.BorderSize = 0;
            this.btn_Topbar_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Topbar_Close.Location = new System.Drawing.Point(777, 0);
            this.btn_Topbar_Close.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Topbar_Close.Name = "btn_Topbar_Close";
            this.btn_Topbar_Close.Size = new System.Drawing.Size(59, 27);
            this.btn_Topbar_Close.TabIndex = 0;
            this.btn_Topbar_Close.UseVisualStyleBackColor = false;
            this.btn_Topbar_Close.Click += new System.EventHandler(this.btn_Topbar_Close_Click);
            // 
            // btn_Account
            // 
            this.btn_Account.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Account.BackgroundImage")));
            this.btn_Account.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Account.FlatAppearance.BorderSize = 0;
            this.btn_Account.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Account.Location = new System.Drawing.Point(738, 50);
            this.btn_Account.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Account.Name = "btn_Account";
            this.btn_Account.Size = new System.Drawing.Size(79, 76);
            this.btn_Account.TabIndex = 15;
            this.btn_Account.UseVisualStyleBackColor = true;
            this.btn_Account.Click += new System.EventHandler(this.btn_Account_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 5);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 22);
            this.label3.TabIndex = 1;
            // 
            // label_DeviceName
            // 
            this.label_DeviceName.AutoSize = true;
            this.label_DeviceName.ForeColor = System.Drawing.Color.DimGray;
            this.label_DeviceName.Location = new System.Drawing.Point(3, 5);
            this.label_DeviceName.Name = "label_DeviceName";
            this.label_DeviceName.Size = new System.Drawing.Size(0, 17);
            this.label_DeviceName.TabIndex = 2;
            // 
            // panel_DeviceName
            // 
            this.panel_DeviceName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(210)))), ((int)(((byte)(197)))));
            this.panel_DeviceName.Controls.Add(this.label_DeviceName);
            this.panel_DeviceName.Controls.Add(this.label3);
            this.panel_DeviceName.ForeColor = System.Drawing.Color.White;
            this.panel_DeviceName.Location = new System.Drawing.Point(21, 181);
            this.panel_DeviceName.Margin = new System.Windows.Forms.Padding(4);
            this.panel_DeviceName.Name = "panel_DeviceName";
            this.panel_DeviceName.Size = new System.Drawing.Size(251, 37);
            this.panel_DeviceName.TabIndex = 4;
            // 
            // label_ChosenFolder
            // 
            this.label_ChosenFolder.AutoSize = true;
            this.label_ChosenFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ChosenFolder.ForeColor = System.Drawing.Color.DimGray;
            this.label_ChosenFolder.Location = new System.Drawing.Point(5, 6);
            this.label_ChosenFolder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_ChosenFolder.Name = "label_ChosenFolder";
            this.label_ChosenFolder.Size = new System.Drawing.Size(0, 22);
            this.label_ChosenFolder.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(210)))), ((int)(((byte)(197)))));
            this.panel2.Controls.Add(this.label_ChosenFolder);
            this.panel2.ForeColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(21, 89);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(251, 37);
            this.panel2.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(430, 42);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 40);
            this.button1.TabIndex = 16;
            this.button1.Text = "API TEST";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label_LoggedInText
            // 
            this.label_LoggedInText.AutoSize = true;
            this.label_LoggedInText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_LoggedInText.Location = new System.Drawing.Point(294, 41);
            this.label_LoggedInText.Name = "label_LoggedInText";
            this.label_LoggedInText.Size = new System.Drawing.Size(98, 36);
            this.label_LoggedInText.TabIndex = 17;
            this.label_LoggedInText.Text = "Logged in as:\r\nCarlo Mercuri";
            // 
            // btn_Register
            // 
            this.btn_Register.BackColor = System.Drawing.Color.Transparent;
            this.btn_Register.FlatAppearance.BorderSize = 0;
            this.btn_Register.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Register.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Register.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Register.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btn_Register.Location = new System.Drawing.Point(3, 3);
            this.btn_Register.Name = "btn_Register";
            this.btn_Register.Size = new System.Drawing.Size(74, 29);
            this.btn_Register.TabIndex = 18;
            this.btn_Register.Text = "Register";
            this.btn_Register.UseVisualStyleBackColor = false;
            // 
            // panel_RegisterLogin
            // 
            this.panel_RegisterLogin.Controls.Add(this.btn_Login);
            this.panel_RegisterLogin.Controls.Add(this.label5);
            this.panel_RegisterLogin.Controls.Add(this.btn_Register);
            this.panel_RegisterLogin.Location = new System.Drawing.Point(557, 33);
            this.panel_RegisterLogin.Name = "panel_RegisterLogin";
            this.panel_RegisterLogin.Size = new System.Drawing.Size(142, 38);
            this.panel_RegisterLogin.TabIndex = 19;
            // 
            // btn_Login
            // 
            this.btn_Login.BackColor = System.Drawing.Color.Transparent;
            this.btn_Login.FlatAppearance.BorderSize = 0;
            this.btn_Login.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_Login.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_Login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Login.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btn_Login.Location = new System.Drawing.Point(83, 3);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(58, 29);
            this.btn_Login.TabIndex = 20;
            this.btn_Login.Text = "Log in";
            this.btn_Login.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(67, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 17);
            this.label5.TabIndex = 19;
            this.label5.Text = "or";
            // 
            // btn_OnlineFiles
            // 
            this.btn_OnlineFiles.BackColor = System.Drawing.Color.White;
            this.btn_OnlineFiles.FlatAppearance.BorderSize = 0;
            this.btn_OnlineFiles.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_OnlineFiles.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_OnlineFiles.ForeColor = System.Drawing.Color.Black;
            this.btn_OnlineFiles.Location = new System.Drawing.Point(499, 186);
            this.btn_OnlineFiles.Margin = new System.Windows.Forms.Padding(4);
            this.btn_OnlineFiles.Name = "btn_OnlineFiles";
            this.btn_OnlineFiles.Size = new System.Drawing.Size(109, 60);
            this.btn_OnlineFiles.TabIndex = 20;
            this.btn_OnlineFiles.Text = "Online\r\nStorage\r\n";
            this.btn_OnlineFiles.UseVisualStyleBackColor = false;
            // 
            // btn_OnlineUpload
            // 
            this.btn_OnlineUpload.BackColor = System.Drawing.Color.White;
            this.btn_OnlineUpload.FlatAppearance.BorderSize = 0;
            this.btn_OnlineUpload.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_OnlineUpload.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_OnlineUpload.ForeColor = System.Drawing.Color.Black;
            this.btn_OnlineUpload.Location = new System.Drawing.Point(627, 186);
            this.btn_OnlineUpload.Margin = new System.Windows.Forms.Padding(4);
            this.btn_OnlineUpload.Name = "btn_OnlineUpload";
            this.btn_OnlineUpload.Size = new System.Drawing.Size(109, 60);
            this.btn_OnlineUpload.TabIndex = 22;
            this.btn_OnlineUpload.Text = "Upload Files Online";
            this.btn_OnlineUpload.UseVisualStyleBackColor = false;
            this.btn_OnlineUpload.Click += new System.EventHandler(this.btn_OnlineUpload_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(213)))), ((int)(((byte)(137)))));
            this.ClientSize = new System.Drawing.Size(835, 614);
            this.Controls.Add(this.btn_OnlineUpload);
            this.Controls.Add(this.btn_OnlineFiles);
            this.Controls.Add(this.panel_RegisterLogin);
            this.Controls.Add(this.label_LoggedInText);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_Account);
            this.Controls.Add(this.panel_TopBar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_ShowMessages);
            this.Controls.Add(this.btn_EditFolder);
            this.Controls.Add(this.panel_DeviceName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_EditName);
            this.Controls.Add(this.startup_Checkbox);
            this.Controls.Add(this.btn_RefreshNetwork);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel_NetworkDevices);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainPage";
            this.Text = "Open FileJump";
            this.LocationChanged += new System.EventHandler(this.mainForm_Location_Changed);
            this.Resize += new System.EventHandler(this.MainPage_Resize);
            this.panel_TopBar.ResumeLayout(false);
            this.panel_DeviceName.ResumeLayout(false);
            this.panel_DeviceName.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel_RegisterLogin.ResumeLayout(false);
            this.panel_RegisterLogin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_NetworkDevices;
        private System.Windows.Forms.FolderBrowserDialog dialog_ChooseFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_RefreshNetwork;
        private System.Windows.Forms.NotifyIcon tray_icon;
        private System.Windows.Forms.CheckBox startup_Checkbox;
        private System.Windows.Forms.OpenFileDialog dialog_openFiles;
        private System.Windows.Forms.Button btn_EditName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_EditFolder;
        private System.Windows.Forms.Button btn_ShowMessages;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel_TopBar;
        private System.Windows.Forms.Button btn_Topbar_Close;
        private System.Windows.Forms.Button btn_Topbar_Minimize;
        private System.Windows.Forms.Button btn_Account;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_DeviceName;
        private System.Windows.Forms.Panel panel_DeviceName;
        private System.Windows.Forms.Label label_ChosenFolder;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label_LoggedInText;
        private System.Windows.Forms.Button btn_Register;
        private System.Windows.Forms.Panel panel_RegisterLogin;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_OnlineFiles;
        private System.Windows.Forms.Button btn_OnlineUpload;
    }
}