
namespace FileJump.Forms
{
    partial class OnlineStoragePage
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
            this.panel_MainFileVisual = new System.Windows.Forms.Panel();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btn_DownloadSelected = new System.Windows.Forms.Button();
            this.btn_SelectAll = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_DeleteFiles = new System.Windows.Forms.Button();
            this.check_DeleteAfterDownload = new System.Windows.Forms.CheckBox();
            this.btn_UnSelectAll = new System.Windows.Forms.Button();
            this.btn_DownloadAll = new System.Windows.Forms.Button();
            this.btn_DeleteAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel_MainFileVisual
            // 
            this.panel_MainFileVisual.BackColor = System.Drawing.Color.Transparent;
            this.panel_MainFileVisual.Location = new System.Drawing.Point(25, 24);
            this.panel_MainFileVisual.Name = "panel_MainFileVisual";
            this.panel_MainFileVisual.Size = new System.Drawing.Size(460, 484);
            this.panel_MainFileVisual.TabIndex = 0;
            // 
            // btn_DownloadSelected
            // 
            this.btn_DownloadSelected.BackColor = System.Drawing.Color.White;
            this.btn_DownloadSelected.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_DownloadSelected.Location = new System.Drawing.Point(507, 65);
            this.btn_DownloadSelected.Name = "btn_DownloadSelected";
            this.btn_DownloadSelected.Size = new System.Drawing.Size(113, 65);
            this.btn_DownloadSelected.TabIndex = 1;
            this.btn_DownloadSelected.Text = "Download Selected File(s)";
            this.btn_DownloadSelected.UseVisualStyleBackColor = false;
            this.btn_DownloadSelected.Click += new System.EventHandler(this.btn_DownloadSelected_Click);
            // 
            // btn_SelectAll
            // 
            this.btn_SelectAll.BackColor = System.Drawing.Color.White;
            this.btn_SelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_SelectAll.Location = new System.Drawing.Point(507, 24);
            this.btn_SelectAll.Name = "btn_SelectAll";
            this.btn_SelectAll.Size = new System.Drawing.Size(113, 35);
            this.btn_SelectAll.TabIndex = 2;
            this.btn_SelectAll.Text = "Select All";
            this.btn_SelectAll.UseVisualStyleBackColor = false;
            this.btn_SelectAll.Click += new System.EventHandler(this.btn_SelectAll_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(569, 252);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 60);
            this.button1.TabIndex = 4;
            this.button1.Text = "Reload";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_DeleteFiles
            // 
            this.btn_DeleteFiles.BackColor = System.Drawing.Color.White;
            this.btn_DeleteFiles.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(198)))), ((int)(((byte)(127)))));
            this.btn_DeleteFiles.FlatAppearance.BorderSize = 8;
            this.btn_DeleteFiles.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_DeleteFiles.Location = new System.Drawing.Point(507, 163);
            this.btn_DeleteFiles.Name = "btn_DeleteFiles";
            this.btn_DeleteFiles.Size = new System.Drawing.Size(113, 64);
            this.btn_DeleteFiles.TabIndex = 5;
            this.btn_DeleteFiles.Text = "Delete selected file(s)";
            this.btn_DeleteFiles.UseVisualStyleBackColor = false;
            this.btn_DeleteFiles.Click += new System.EventHandler(this.btn_DeleteFiles_Click);
            // 
            // check_DeleteAfterDownload
            // 
            this.check_DeleteAfterDownload.AutoSize = true;
            this.check_DeleteAfterDownload.Location = new System.Drawing.Point(542, 136);
            this.check_DeleteAfterDownload.Name = "check_DeleteAfterDownload";
            this.check_DeleteAfterDownload.Size = new System.Drawing.Size(168, 21);
            this.check_DeleteAfterDownload.TabIndex = 6;
            this.check_DeleteAfterDownload.Text = "Delete after download";
            this.check_DeleteAfterDownload.UseVisualStyleBackColor = true;
            // 
            // btn_UnSelectAll
            // 
            this.btn_UnSelectAll.BackColor = System.Drawing.Color.White;
            this.btn_UnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_UnSelectAll.Location = new System.Drawing.Point(626, 24);
            this.btn_UnSelectAll.Name = "btn_UnSelectAll";
            this.btn_UnSelectAll.Size = new System.Drawing.Size(113, 35);
            this.btn_UnSelectAll.TabIndex = 7;
            this.btn_UnSelectAll.Text = "Unselect All";
            this.btn_UnSelectAll.UseVisualStyleBackColor = false;
            // 
            // btn_DownloadAll
            // 
            this.btn_DownloadAll.BackColor = System.Drawing.Color.White;
            this.btn_DownloadAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_DownloadAll.Location = new System.Drawing.Point(626, 65);
            this.btn_DownloadAll.Name = "btn_DownloadAll";
            this.btn_DownloadAll.Size = new System.Drawing.Size(113, 65);
            this.btn_DownloadAll.TabIndex = 8;
            this.btn_DownloadAll.Text = "Download All Files";
            this.btn_DownloadAll.UseVisualStyleBackColor = false;
            // 
            // btn_DeleteAll
            // 
            this.btn_DeleteAll.BackColor = System.Drawing.Color.White;
            this.btn_DeleteAll.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(198)))), ((int)(((byte)(127)))));
            this.btn_DeleteAll.FlatAppearance.BorderSize = 8;
            this.btn_DeleteAll.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_DeleteAll.Location = new System.Drawing.Point(626, 163);
            this.btn_DeleteAll.Name = "btn_DeleteAll";
            this.btn_DeleteAll.Size = new System.Drawing.Size(113, 64);
            this.btn_DeleteAll.TabIndex = 9;
            this.btn_DeleteAll.Text = "Delete all files";
            this.btn_DeleteAll.UseVisualStyleBackColor = false;
            // 
            // OnlineStoragePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(213)))), ((int)(((byte)(137)))));
            this.ClientSize = new System.Drawing.Size(771, 532);
            this.Controls.Add(this.btn_DeleteAll);
            this.Controls.Add(this.btn_DownloadAll);
            this.Controls.Add(this.btn_UnSelectAll);
            this.Controls.Add(this.check_DeleteAfterDownload);
            this.Controls.Add(this.btn_DeleteFiles);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_SelectAll);
            this.Controls.Add(this.btn_DownloadSelected);
            this.Controls.Add(this.panel_MainFileVisual);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OnlineStoragePage";
            this.Text = "Online Vault";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Event_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel_MainFileVisual;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btn_DownloadSelected;
        private System.Windows.Forms.Button btn_SelectAll;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_DeleteFiles;
        private System.Windows.Forms.CheckBox check_DeleteAfterDownload;
        private System.Windows.Forms.Button btn_UnSelectAll;
        private System.Windows.Forms.Button btn_DownloadAll;
        private System.Windows.Forms.Button btn_DeleteAll;
    }
}