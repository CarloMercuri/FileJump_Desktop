
namespace FileJump.Forms
{
    partial class MainAppForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainAppForm));
            this.panel_MainLeft = new System.Windows.Forms.Panel();
            this.panel_TopBar = new System.Windows.Forms.Panel();
            this.btn_Topbar_Minimize = new System.Windows.Forms.Button();
            this.btn_Topbar_Close = new System.Windows.Forms.Button();
            this.TickTimer = new System.Windows.Forms.Timer(this.components);
            this.tray_Icon = new System.Windows.Forms.NotifyIcon(this.components);
            this.panel_TopBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_MainLeft
            // 
            this.panel_MainLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(41)))), ((int)(((byte)(54)))));
            this.panel_MainLeft.Location = new System.Drawing.Point(0, 0);
            this.panel_MainLeft.Name = "panel_MainLeft";
            this.panel_MainLeft.Size = new System.Drawing.Size(248, 821);
            this.panel_MainLeft.TabIndex = 0;
            // 
            // panel_TopBar
            // 
            this.panel_TopBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(61)))), ((int)(((byte)(79)))));
            this.panel_TopBar.Controls.Add(this.btn_Topbar_Minimize);
            this.panel_TopBar.Controls.Add(this.btn_Topbar_Close);
            this.panel_TopBar.Location = new System.Drawing.Point(258, 32);
            this.panel_TopBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_TopBar.Name = "panel_TopBar";
            this.panel_TopBar.Size = new System.Drawing.Size(981, 28);
            this.panel_TopBar.TabIndex = 15;
            // 
            // btn_Topbar_Minimize
            // 
            this.btn_Topbar_Minimize.BackColor = System.Drawing.Color.Transparent;
            this.btn_Topbar_Minimize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Topbar_Minimize.BackgroundImage")));
            this.btn_Topbar_Minimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_Topbar_Minimize.FlatAppearance.BorderSize = 0;
            this.btn_Topbar_Minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Topbar_Minimize.Location = new System.Drawing.Point(879, 1);
            this.btn_Topbar_Minimize.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Topbar_Minimize.Name = "btn_Topbar_Minimize";
            this.btn_Topbar_Minimize.Size = new System.Drawing.Size(59, 27);
            this.btn_Topbar_Minimize.TabIndex = 14;
            this.btn_Topbar_Minimize.UseVisualStyleBackColor = false;
            // 
            // btn_Topbar_Close
            // 
            this.btn_Topbar_Close.BackColor = System.Drawing.Color.Transparent;
            this.btn_Topbar_Close.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Topbar_Close.BackgroundImage")));
            this.btn_Topbar_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_Topbar_Close.FlatAppearance.BorderSize = 0;
            this.btn_Topbar_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Topbar_Close.Location = new System.Drawing.Point(934, 1);
            this.btn_Topbar_Close.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Topbar_Close.Name = "btn_Topbar_Close";
            this.btn_Topbar_Close.Size = new System.Drawing.Size(51, 27);
            this.btn_Topbar_Close.TabIndex = 0;
            this.btn_Topbar_Close.UseVisualStyleBackColor = false;
            // 
            // TickTimer
            // 
            this.TickTimer.Interval = 3;
            // 
            // tray_Icon
            // 
            this.tray_Icon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.tray_Icon.BalloonTipTitle = "Transfer Complete";
            this.tray_Icon.Icon = ((System.Drawing.Icon)(resources.GetObject("tray_Icon.Icon")));
            this.tray_Icon.Text = "notifyIcon1";
            this.tray_Icon.Visible = true;
            // 
            // MainAppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(52)))), ((int)(((byte)(67)))));
            this.ClientSize = new System.Drawing.Size(1288, 838);
            this.ControlBox = false;
            this.Controls.Add(this.panel_TopBar);
            this.Controls.Add(this.panel_MainLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainAppForm";
            this.Text = "MainAppForm";
            this.panel_TopBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_MainLeft;
        private System.Windows.Forms.Panel panel_TopBar;
        private System.Windows.Forms.Button btn_Topbar_Minimize;
        private System.Windows.Forms.Button btn_Topbar_Close;
        private System.Windows.Forms.Timer TickTimer;
        private System.Windows.Forms.NotifyIcon tray_Icon;
    }
}