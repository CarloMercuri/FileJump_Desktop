
namespace FileJump.Forms
{
    partial class LoginPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginPage));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel_MainLogin = new System.Windows.Forms.Panel();
            this.label_InvalidLogin = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_ForgotPassword = new System.Windows.Forms.Button();
            this.label_Password = new System.Windows.Forms.Label();
            this.Input_Password = new System.Windows.Forms.TextBox();
            this.label_Email = new System.Windows.Forms.Label();
            this.Input_Email = new System.Windows.Forms.TextBox();
            this.check_Rememberme = new System.Windows.Forms.CheckBox();
            this.btn_Login = new System.Windows.Forms.Button();
            this.panel_ForgotPassword = new System.Windows.Forms.Panel();
            this.label_EmailRecoverySuccess = new System.Windows.Forms.Label();
            this.label_InvalidEmail = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.input_ForgotPW_Email = new System.Windows.Forms.TextBox();
            this.btn_SendForgotPW = new System.Windows.Forms.Button();
            this.btn_BackToLogin = new System.Windows.Forms.Button();
            this.panel_Success = new System.Windows.Forms.Panel();
            this.btn_CloseForm = new System.Windows.Forms.Button();
            this.mainTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel_MainLogin.SuspendLayout();
            this.panel_ForgotPassword.SuspendLayout();
            this.panel_Success.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(148, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(143, 136);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // panel_MainLogin
            // 
            this.panel_MainLogin.Controls.Add(this.label_InvalidLogin);
            this.panel_MainLogin.Controls.Add(this.label1);
            this.panel_MainLogin.Controls.Add(this.btn_ForgotPassword);
            this.panel_MainLogin.Controls.Add(this.label_Password);
            this.panel_MainLogin.Controls.Add(this.Input_Password);
            this.panel_MainLogin.Controls.Add(this.label_Email);
            this.panel_MainLogin.Controls.Add(this.Input_Email);
            this.panel_MainLogin.Controls.Add(this.check_Rememberme);
            this.panel_MainLogin.Controls.Add(this.btn_Login);
            this.panel_MainLogin.Location = new System.Drawing.Point(38, 154);
            this.panel_MainLogin.Name = "panel_MainLogin";
            this.panel_MainLogin.Size = new System.Drawing.Size(414, 394);
            this.panel_MainLogin.TabIndex = 10;
            // 
            // label_InvalidLogin
            // 
            this.label_InvalidLogin.BackColor = System.Drawing.Color.Transparent;
            this.label_InvalidLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_InvalidLogin.ForeColor = System.Drawing.Color.Red;
            this.label_InvalidLogin.Location = new System.Drawing.Point(12, 31);
            this.label_InvalidLogin.Name = "label_InvalidLogin";
            this.label_InvalidLogin.Size = new System.Drawing.Size(381, 55);
            this.label_InvalidLogin.TabIndex = 17;
            this.label_InvalidLogin.Text = "Account has not been activated. Check your email for an activation message.";
            this.label_InvalidLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label1.Location = new System.Drawing.Point(59, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 31);
            this.label1.TabIndex = 16;
            this.label1.Text = "Login to your account";
            // 
            // btn_ForgotPassword
            // 
            this.btn_ForgotPassword.BackColor = System.Drawing.Color.White;
            this.btn_ForgotPassword.FlatAppearance.BorderSize = 0;
            this.btn_ForgotPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ForgotPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ForgotPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(157)))), ((int)(((byte)(88)))));
            this.btn_ForgotPassword.Location = new System.Drawing.Point(204, 231);
            this.btn_ForgotPassword.Name = "btn_ForgotPassword";
            this.btn_ForgotPassword.Size = new System.Drawing.Size(189, 35);
            this.btn_ForgotPassword.TabIndex = 15;
            this.btn_ForgotPassword.Text = "Forgot password?";
            this.btn_ForgotPassword.UseVisualStyleBackColor = false;
            this.btn_ForgotPassword.Click += new System.EventHandler(this.btn_ForgotPassword_Click);
            // 
            // label_Password
            // 
            this.label_Password.AutoSize = true;
            this.label_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Password.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label_Password.Location = new System.Drawing.Point(22, 166);
            this.label_Password.Name = "label_Password";
            this.label_Password.Size = new System.Drawing.Size(83, 20);
            this.label_Password.TabIndex = 14;
            this.label_Password.Text = "Password";
            // 
            // Input_Password
            // 
            this.Input_Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Input_Password.Location = new System.Drawing.Point(26, 189);
            this.Input_Password.Name = "Input_Password";
            this.Input_Password.PasswordChar = '*';
            this.Input_Password.Size = new System.Drawing.Size(367, 32);
            this.Input_Password.TabIndex = 13;
            // 
            // label_Email
            // 
            this.label_Email.AutoSize = true;
            this.label_Email.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Email.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label_Email.Location = new System.Drawing.Point(22, 91);
            this.label_Email.Name = "label_Email";
            this.label_Email.Size = new System.Drawing.Size(57, 20);
            this.label_Email.TabIndex = 12;
            this.label_Email.Text = "E-Mail";
            // 
            // Input_Email
            // 
            this.Input_Email.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Input_Email.Location = new System.Drawing.Point(26, 114);
            this.Input_Email.Name = "Input_Email";
            this.Input_Email.Size = new System.Drawing.Size(367, 32);
            this.Input_Email.TabIndex = 11;
            // 
            // check_Rememberme
            // 
            this.check_Rememberme.AutoSize = true;
            this.check_Rememberme.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.check_Rememberme.ForeColor = System.Drawing.SystemColors.GrayText;
            this.check_Rememberme.Location = new System.Drawing.Point(26, 237);
            this.check_Rememberme.Name = "check_Rememberme";
            this.check_Rememberme.Size = new System.Drawing.Size(141, 24);
            this.check_Rememberme.TabIndex = 10;
            this.check_Rememberme.Text = "Remember me";
            this.check_Rememberme.UseVisualStyleBackColor = true;
            // 
            // btn_Login
            // 
            this.btn_Login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(157)))), ((int)(((byte)(88)))));
            this.btn_Login.FlatAppearance.BorderSize = 0;
            this.btn_Login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Login.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Login.ForeColor = System.Drawing.Color.White;
            this.btn_Login.Location = new System.Drawing.Point(26, 302);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(367, 56);
            this.btn_Login.TabIndex = 9;
            this.btn_Login.Text = "Login";
            this.btn_Login.UseVisualStyleBackColor = false;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // panel_ForgotPassword
            // 
            this.panel_ForgotPassword.Controls.Add(this.label_EmailRecoverySuccess);
            this.panel_ForgotPassword.Controls.Add(this.label_InvalidEmail);
            this.panel_ForgotPassword.Controls.Add(this.label3);
            this.panel_ForgotPassword.Controls.Add(this.label5);
            this.panel_ForgotPassword.Controls.Add(this.input_ForgotPW_Email);
            this.panel_ForgotPassword.Controls.Add(this.btn_SendForgotPW);
            this.panel_ForgotPassword.Location = new System.Drawing.Point(35, 117);
            this.panel_ForgotPassword.Name = "panel_ForgotPassword";
            this.panel_ForgotPassword.Size = new System.Drawing.Size(414, 428);
            this.panel_ForgotPassword.TabIndex = 18;
            // 
            // label_EmailRecoverySuccess
            // 
            this.label_EmailRecoverySuccess.AutoSize = true;
            this.label_EmailRecoverySuccess.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_EmailRecoverySuccess.ForeColor = System.Drawing.Color.Black;
            this.label_EmailRecoverySuccess.Location = new System.Drawing.Point(28, 227);
            this.label_EmailRecoverySuccess.MaximumSize = new System.Drawing.Size(370, 0);
            this.label_EmailRecoverySuccess.Name = "label_EmailRecoverySuccess";
            this.label_EmailRecoverySuccess.Size = new System.Drawing.Size(460, 50);
            this.label_EmailRecoverySuccess.TabIndex = 19;
            this.label_EmailRecoverySuccess.Text = "                       Thank you!\r\nPlease check your email inbox for all the deta" +
    "ils.";
            // 
            // label_InvalidEmail
            // 
            this.label_InvalidEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_InvalidEmail.ForeColor = System.Drawing.Color.Red;
            this.label_InvalidEmail.Location = new System.Drawing.Point(22, 156);
            this.label_InvalidEmail.Name = "label_InvalidEmail";
            this.label_InvalidEmail.Size = new System.Drawing.Size(383, 30);
            this.label_InvalidEmail.TabIndex = 18;
            this.label_InvalidEmail.Text = "Invalid Email address!";
            this.label_InvalidEmail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label3.Location = new System.Drawing.Point(80, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(235, 31);
            this.label3.TabIndex = 16;
            this.label3.Text = "Forgot Password";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label5.Location = new System.Drawing.Point(35, 61);
            this.label5.MaximumSize = new System.Drawing.Size(350, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(346, 80);
            this.label5.TabIndex = 12;
            this.label5.Text = "Enter your e-mail address. If an account is found associated with it, you will re" +
    "ceive an email with the details on how to retreive your password";
            // 
            // input_ForgotPW_Email
            // 
            this.input_ForgotPW_Email.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.input_ForgotPW_Email.Location = new System.Drawing.Point(26, 189);
            this.input_ForgotPW_Email.Name = "input_ForgotPW_Email";
            this.input_ForgotPW_Email.Size = new System.Drawing.Size(367, 32);
            this.input_ForgotPW_Email.TabIndex = 11;
            this.input_ForgotPW_Email.TextChanged += new System.EventHandler(this.input_ForgotPW_EmailChanged);
            // 
            // btn_SendForgotPW
            // 
            this.btn_SendForgotPW.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(157)))), ((int)(((byte)(88)))));
            this.btn_SendForgotPW.FlatAppearance.BorderSize = 0;
            this.btn_SendForgotPW.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SendForgotPW.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SendForgotPW.ForeColor = System.Drawing.Color.White;
            this.btn_SendForgotPW.Location = new System.Drawing.Point(29, 310);
            this.btn_SendForgotPW.Name = "btn_SendForgotPW";
            this.btn_SendForgotPW.Size = new System.Drawing.Size(367, 56);
            this.btn_SendForgotPW.TabIndex = 9;
            this.btn_SendForgotPW.Text = "Send";
            this.btn_SendForgotPW.UseVisualStyleBackColor = false;
            this.btn_SendForgotPW.Click += new System.EventHandler(this.btn_SendForgotPW_Click);
            // 
            // btn_BackToLogin
            // 
            this.btn_BackToLogin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_BackToLogin.BackgroundImage")));
            this.btn_BackToLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_BackToLogin.Location = new System.Drawing.Point(38, 52);
            this.btn_BackToLogin.Name = "btn_BackToLogin";
            this.btn_BackToLogin.Size = new System.Drawing.Size(78, 40);
            this.btn_BackToLogin.TabIndex = 29;
            this.btn_BackToLogin.UseVisualStyleBackColor = true;
            this.btn_BackToLogin.Click += new System.EventHandler(this.btn_BackToLogin_Click);
            // 
            // panel_Success
            // 
            this.panel_Success.Controls.Add(this.btn_CloseForm);
            this.panel_Success.Controls.Add(this.mainTextBox);
            this.panel_Success.Location = new System.Drawing.Point(148, 530);
            this.panel_Success.Name = "panel_Success";
            this.panel_Success.Size = new System.Drawing.Size(381, 532);
            this.panel_Success.TabIndex = 34;
            // 
            // btn_CloseForm
            // 
            this.btn_CloseForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(157)))), ((int)(((byte)(88)))));
            this.btn_CloseForm.FlatAppearance.BorderSize = 0;
            this.btn_CloseForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_CloseForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_CloseForm.ForeColor = System.Drawing.Color.White;
            this.btn_CloseForm.Location = new System.Drawing.Point(125, 339);
            this.btn_CloseForm.Name = "btn_CloseForm";
            this.btn_CloseForm.Size = new System.Drawing.Size(128, 53);
            this.btn_CloseForm.TabIndex = 11;
            this.btn_CloseForm.Text = "Close";
            this.btn_CloseForm.UseVisualStyleBackColor = false;
            this.btn_CloseForm.Click += new System.EventHandler(this.btn_CloseForm_Click);
            // 
            // mainTextBox
            // 
            this.mainTextBox.BackColor = System.Drawing.Color.White;
            this.mainTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mainTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.mainTextBox.Location = new System.Drawing.Point(29, 177);
            this.mainTextBox.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.mainTextBox.Multiline = true;
            this.mainTextBox.Name = "mainTextBox";
            this.mainTextBox.ReadOnly = true;
            this.mainTextBox.Size = new System.Drawing.Size(349, 233);
            this.mainTextBox.TabIndex = 1;
            this.mainTextBox.Text = "Your account still needs to be activated.\r\n\r\nPlease check your email for an activ" +
    "ation link.\r\n";
            // 
            // LoginPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(482, 560);
            this.Controls.Add(this.panel_Success);
            this.Controls.Add(this.btn_BackToLogin);
            this.Controls.Add(this.panel_ForgotPassword);
            this.Controls.Add(this.panel_MainLogin);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel_MainLogin.ResumeLayout(false);
            this.panel_MainLogin.PerformLayout();
            this.panel_ForgotPassword.ResumeLayout(false);
            this.panel_ForgotPassword.PerformLayout();
            this.panel_Success.ResumeLayout(false);
            this.panel_Success.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel_MainLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_ForgotPassword;
        private System.Windows.Forms.Label label_Password;
        private System.Windows.Forms.TextBox Input_Password;
        private System.Windows.Forms.Label label_Email;
        private System.Windows.Forms.TextBox Input_Email;
        private System.Windows.Forms.CheckBox check_Rememberme;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.Label label_InvalidLogin;
        private System.Windows.Forms.Panel panel_ForgotPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox input_ForgotPW_Email;
        private System.Windows.Forms.Button btn_SendForgotPW;
        private System.Windows.Forms.Button btn_BackToLogin;
        private System.Windows.Forms.Label label_InvalidEmail;
        private System.Windows.Forms.Label label_EmailRecoverySuccess;
        private System.Windows.Forms.Panel panel_Success;
        private System.Windows.Forms.Button btn_CloseForm;
        private System.Windows.Forms.TextBox mainTextBox;
    }
}