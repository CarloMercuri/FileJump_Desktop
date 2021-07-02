
namespace FileJump.Forms
{
    partial class FileUploadPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileUploadPage));
            this.panel_TopBar = new System.Windows.Forms.Panel();
            this.btn_Topbar_Minimize = new System.Windows.Forms.Button();
            this.btn_Topbar_Close = new System.Windows.Forms.Button();
            this.dialog_OpenFiles = new System.Windows.Forms.OpenFileDialog();
            this.panel_TopBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_TopBar
            // 
            this.panel_TopBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(198)))), ((int)(((byte)(127)))));
            this.panel_TopBar.Controls.Add(this.btn_Topbar_Minimize);
            this.panel_TopBar.Controls.Add(this.btn_Topbar_Close);
            this.panel_TopBar.Location = new System.Drawing.Point(12, 11);
            this.panel_TopBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel_TopBar.Name = "panel_TopBar";
            this.panel_TopBar.Size = new System.Drawing.Size(368, 28);
            this.panel_TopBar.TabIndex = 14;
            // 
            // btn_Topbar_Minimize
            // 
            this.btn_Topbar_Minimize.BackColor = System.Drawing.Color.Transparent;
            this.btn_Topbar_Minimize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Topbar_Minimize.BackgroundImage")));
            this.btn_Topbar_Minimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_Topbar_Minimize.FlatAppearance.BorderSize = 0;
            this.btn_Topbar_Minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Topbar_Minimize.Location = new System.Drawing.Point(228, -1);
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
            this.btn_Topbar_Close.Location = new System.Drawing.Point(292, -1);
            this.btn_Topbar_Close.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn_Topbar_Close.Name = "btn_Topbar_Close";
            this.btn_Topbar_Close.Size = new System.Drawing.Size(59, 27);
            this.btn_Topbar_Close.TabIndex = 0;
            this.btn_Topbar_Close.UseVisualStyleBackColor = false;
            // 
            // dialog_OpenFiles
            // 
            this.dialog_OpenFiles.FileName = "openFileDialog1";
            // 
            // FileUploadPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(213)))), ((int)(((byte)(137)))));
            this.ClientSize = new System.Drawing.Size(917, 705);
            this.Controls.Add(this.panel_TopBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FileUploadPage";
            this.Text = "FileUploadPage";
            this.panel_TopBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_TopBar;
        private System.Windows.Forms.Button btn_Topbar_Minimize;
        private System.Windows.Forms.Button btn_Topbar_Close;
        private System.Windows.Forms.OpenFileDialog dialog_OpenFiles;
    }
}