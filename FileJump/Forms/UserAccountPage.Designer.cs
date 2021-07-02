
namespace FileJump.Forms
{
    partial class UserAccountPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserAccountPage));
            this.pBox_UserIcon = new System.Windows.Forms.PictureBox();
            this.lbl_Email = new System.Windows.Forms.Label();
            this.lbl_UserEmail = new System.Windows.Forms.Label();
            this.panel_mainInfo = new System.Windows.Forms.Panel();
            this.btn_LogOut = new System.Windows.Forms.Button();
            this.lbl_NewPass = new System.Windows.Forms.Label();
            this.tBox_LastName = new System.Windows.Forms.TextBox();
            this.tBox_FirstName = new System.Windows.Forms.TextBox();
            this.lbl_LastName = new System.Windows.Forms.Label();
            this.lbl_FirstName = new System.Windows.Forms.Label();
            this.btn_ChangePassword = new System.Windows.Forms.Button();
            this.timer_Animation = new System.Windows.Forms.Timer(this.components);
            this.panel_NewPassword = new System.Windows.Forms.Panel();
            this.label_Result = new System.Windows.Forms.Label();
            this.label_OldPassRequired = new System.Windows.Forms.Label();
            this.panel_PasswordChecks = new System.Windows.Forms.Panel();
            this.lbl_text_number = new System.Windows.Forms.Label();
            this.lbl_check_lowercase = new System.Windows.Forms.Label();
            this.lbl_check_uppercase = new System.Windows.Forms.Label();
            this.lbl_check_number = new System.Windows.Forms.Label();
            this.lbl_check_lenght = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_text_lowercase = new System.Windows.Forms.Label();
            this.lbl_text_lenght = new System.Windows.Forms.Label();
            this.lbl_text_capital = new System.Windows.Forms.Label();
            this.btn_SubmitNewPassword = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.input_OldPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label_PasswordsNoMatch = new System.Windows.Forms.Label();
            this.Input_Password_01 = new System.Windows.Forms.TextBox();
            this.Input_Password_02 = new System.Windows.Forms.TextBox();
            this.btn_BackFromNewPassword = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pBox_UserIcon)).BeginInit();
            this.panel_mainInfo.SuspendLayout();
            this.panel_NewPassword.SuspendLayout();
            this.panel_PasswordChecks.SuspendLayout();
            this.SuspendLayout();
            // 
            // pBox_UserIcon
            // 
            this.pBox_UserIcon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pBox_UserIcon.BackgroundImage")));
            this.pBox_UserIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pBox_UserIcon.Location = new System.Drawing.Point(158, 14);
            this.pBox_UserIcon.Name = "pBox_UserIcon";
            this.pBox_UserIcon.Size = new System.Drawing.Size(143, 136);
            this.pBox_UserIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBox_UserIcon.TabIndex = 18;
            this.pBox_UserIcon.TabStop = false;
            // 
            // lbl_Email
            // 
            this.lbl_Email.AutoSize = true;
            this.lbl_Email.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Email.ForeColor = System.Drawing.Color.Black;
            this.lbl_Email.Location = new System.Drawing.Point(19, 31);
            this.lbl_Email.Name = "lbl_Email";
            this.lbl_Email.Size = new System.Drawing.Size(110, 20);
            this.lbl_Email.TabIndex = 24;
            this.lbl_Email.Text = "Logged in as:";
            // 
            // lbl_UserEmail
            // 
            this.lbl_UserEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_UserEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lbl_UserEmail.Location = new System.Drawing.Point(168, 23);
            this.lbl_UserEmail.Name = "lbl_UserEmail";
            this.lbl_UserEmail.Size = new System.Drawing.Size(240, 33);
            this.lbl_UserEmail.TabIndex = 25;
            this.lbl_UserEmail.Text = "cmercuri85@gmail.com";
            this.lbl_UserEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel_mainInfo
            // 
            this.panel_mainInfo.Controls.Add(this.btn_LogOut);
            this.panel_mainInfo.Controls.Add(this.lbl_NewPass);
            this.panel_mainInfo.Controls.Add(this.tBox_LastName);
            this.panel_mainInfo.Controls.Add(this.tBox_FirstName);
            this.panel_mainInfo.Controls.Add(this.lbl_LastName);
            this.panel_mainInfo.Controls.Add(this.lbl_FirstName);
            this.panel_mainInfo.Controls.Add(this.btn_ChangePassword);
            this.panel_mainInfo.Controls.Add(this.lbl_UserEmail);
            this.panel_mainInfo.Controls.Add(this.lbl_Email);
            this.panel_mainInfo.Location = new System.Drawing.Point(19, 185);
            this.panel_mainInfo.Name = "panel_mainInfo";
            this.panel_mainInfo.Size = new System.Drawing.Size(443, 428);
            this.panel_mainInfo.TabIndex = 26;
            // 
            // btn_LogOut
            // 
            this.btn_LogOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(157)))), ((int)(((byte)(88)))));
            this.btn_LogOut.ForeColor = System.Drawing.Color.White;
            this.btn_LogOut.Location = new System.Drawing.Point(130, 349);
            this.btn_LogOut.Name = "btn_LogOut";
            this.btn_LogOut.Size = new System.Drawing.Size(159, 35);
            this.btn_LogOut.TabIndex = 31;
            this.btn_LogOut.Text = "Log out";
            this.btn_LogOut.UseVisualStyleBackColor = false;
            // 
            // lbl_NewPass
            // 
            this.lbl_NewPass.AutoSize = true;
            this.lbl_NewPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_NewPass.ForeColor = System.Drawing.Color.Black;
            this.lbl_NewPass.Location = new System.Drawing.Point(19, 218);
            this.lbl_NewPass.Name = "lbl_NewPass";
            this.lbl_NewPass.Size = new System.Drawing.Size(121, 20);
            this.lbl_NewPass.TabIndex = 30;
            this.lbl_NewPass.Text = "New Password";
            // 
            // tBox_LastName
            // 
            this.tBox_LastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBox_LastName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tBox_LastName.Location = new System.Drawing.Point(160, 146);
            this.tBox_LastName.Name = "tBox_LastName";
            this.tBox_LastName.Size = new System.Drawing.Size(224, 32);
            this.tBox_LastName.TabIndex = 29;
            // 
            // tBox_FirstName
            // 
            this.tBox_FirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBox_FirstName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tBox_FirstName.Location = new System.Drawing.Point(160, 90);
            this.tBox_FirstName.Name = "tBox_FirstName";
            this.tBox_FirstName.Size = new System.Drawing.Size(224, 32);
            this.tBox_FirstName.TabIndex = 28;
            // 
            // lbl_LastName
            // 
            this.lbl_LastName.AutoSize = true;
            this.lbl_LastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_LastName.ForeColor = System.Drawing.Color.Black;
            this.lbl_LastName.Location = new System.Drawing.Point(22, 152);
            this.lbl_LastName.Name = "lbl_LastName";
            this.lbl_LastName.Size = new System.Drawing.Size(91, 20);
            this.lbl_LastName.TabIndex = 27;
            this.lbl_LastName.Text = "Last Name";
            // 
            // lbl_FirstName
            // 
            this.lbl_FirstName.AutoSize = true;
            this.lbl_FirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_FirstName.ForeColor = System.Drawing.Color.Black;
            this.lbl_FirstName.Location = new System.Drawing.Point(19, 95);
            this.lbl_FirstName.Name = "lbl_FirstName";
            this.lbl_FirstName.Size = new System.Drawing.Size(92, 20);
            this.lbl_FirstName.TabIndex = 26;
            this.lbl_FirstName.Text = "First Name";
            // 
            // btn_ChangePassword
            // 
            this.btn_ChangePassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(157)))), ((int)(((byte)(88)))));
            this.btn_ChangePassword.ForeColor = System.Drawing.Color.White;
            this.btn_ChangePassword.Location = new System.Drawing.Point(184, 213);
            this.btn_ChangePassword.Name = "btn_ChangePassword";
            this.btn_ChangePassword.Size = new System.Drawing.Size(159, 35);
            this.btn_ChangePassword.TabIndex = 25;
            this.btn_ChangePassword.Text = "Change Password";
            this.btn_ChangePassword.UseVisualStyleBackColor = false;
            this.btn_ChangePassword.Click += new System.EventHandler(this.btn_ChangePassword_Click);
            // 
            // timer_Animation
            // 
            this.timer_Animation.Interval = 5;
            this.timer_Animation.Tick += new System.EventHandler(this.time_5_tick);
            // 
            // panel_NewPassword
            // 
            this.panel_NewPassword.Controls.Add(this.label_Result);
            this.panel_NewPassword.Controls.Add(this.label_OldPassRequired);
            this.panel_NewPassword.Controls.Add(this.panel_PasswordChecks);
            this.panel_NewPassword.Controls.Add(this.btn_SubmitNewPassword);
            this.panel_NewPassword.Controls.Add(this.label3);
            this.panel_NewPassword.Controls.Add(this.input_OldPassword);
            this.panel_NewPassword.Controls.Add(this.label2);
            this.panel_NewPassword.Controls.Add(this.label4);
            this.panel_NewPassword.Controls.Add(this.label_PasswordsNoMatch);
            this.panel_NewPassword.Controls.Add(this.Input_Password_01);
            this.panel_NewPassword.Controls.Add(this.Input_Password_02);
            this.panel_NewPassword.Location = new System.Drawing.Point(16, 142);
            this.panel_NewPassword.Name = "panel_NewPassword";
            this.panel_NewPassword.Size = new System.Drawing.Size(443, 471);
            this.panel_NewPassword.TabIndex = 27;
            // 
            // label_Result
            // 
            this.label_Result.AutoSize = true;
            this.label_Result.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Result.ForeColor = System.Drawing.Color.Red;
            this.label_Result.Location = new System.Drawing.Point(138, 233);
            this.label_Result.Name = "label_Result";
            this.label_Result.Size = new System.Drawing.Size(174, 24);
            this.label_Result.TabIndex = 47;
            this.label_Result.Text = "Request Timed Out";
            this.label_Result.Visible = false;
            // 
            // label_OldPassRequired
            // 
            this.label_OldPassRequired.AutoSize = true;
            this.label_OldPassRequired.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_OldPassRequired.ForeColor = System.Drawing.Color.Red;
            this.label_OldPassRequired.Location = new System.Drawing.Point(321, 0);
            this.label_OldPassRequired.Name = "label_OldPassRequired";
            this.label_OldPassRequired.Size = new System.Drawing.Size(80, 20);
            this.label_OldPassRequired.TabIndex = 53;
            this.label_OldPassRequired.Text = "Required.";
            // 
            // panel_PasswordChecks
            // 
            this.panel_PasswordChecks.Controls.Add(this.lbl_text_number);
            this.panel_PasswordChecks.Controls.Add(this.lbl_check_lowercase);
            this.panel_PasswordChecks.Controls.Add(this.lbl_check_uppercase);
            this.panel_PasswordChecks.Controls.Add(this.lbl_check_number);
            this.panel_PasswordChecks.Controls.Add(this.lbl_check_lenght);
            this.panel_PasswordChecks.Controls.Add(this.label1);
            this.panel_PasswordChecks.Controls.Add(this.lbl_text_lowercase);
            this.panel_PasswordChecks.Controls.Add(this.lbl_text_lenght);
            this.panel_PasswordChecks.Controls.Add(this.lbl_text_capital);
            this.panel_PasswordChecks.Location = new System.Drawing.Point(50, 268);
            this.panel_PasswordChecks.Name = "panel_PasswordChecks";
            this.panel_PasswordChecks.Size = new System.Drawing.Size(355, 203);
            this.panel_PasswordChecks.TabIndex = 52;
            // 
            // lbl_text_number
            // 
            this.lbl_text_number.AutoSize = true;
            this.lbl_text_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_text_number.ForeColor = System.Drawing.Color.Red;
            this.lbl_text_number.Location = new System.Drawing.Point(85, 128);
            this.lbl_text_number.Name = "lbl_text_number";
            this.lbl_text_number.Size = new System.Drawing.Size(99, 24);
            this.lbl_text_number.TabIndex = 44;
            this.lbl_text_number.Text = "A number.";
            // 
            // lbl_check_lowercase
            // 
            this.lbl_check_lowercase.AutoSize = true;
            this.lbl_check_lowercase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_check_lowercase.Location = new System.Drawing.Point(35, 34);
            this.lbl_check_lowercase.Name = "lbl_check_lowercase";
            this.lbl_check_lowercase.Size = new System.Drawing.Size(23, 25);
            this.lbl_check_lowercase.TabIndex = 35;
            this.lbl_check_lowercase.Text = "✓";
            // 
            // lbl_check_uppercase
            // 
            this.lbl_check_uppercase.AutoSize = true;
            this.lbl_check_uppercase.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_check_uppercase.Location = new System.Drawing.Point(35, 80);
            this.lbl_check_uppercase.Name = "lbl_check_uppercase";
            this.lbl_check_uppercase.Size = new System.Drawing.Size(23, 25);
            this.lbl_check_uppercase.TabIndex = 39;
            this.lbl_check_uppercase.Text = "✓";
            // 
            // lbl_check_number
            // 
            this.lbl_check_number.AutoSize = true;
            this.lbl_check_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_check_number.Location = new System.Drawing.Point(35, 128);
            this.lbl_check_number.Name = "lbl_check_number";
            this.lbl_check_number.Size = new System.Drawing.Size(23, 25);
            this.lbl_check_number.TabIndex = 40;
            this.lbl_check_number.Text = "✓";
            // 
            // lbl_check_lenght
            // 
            this.lbl_check_lenght.AutoSize = true;
            this.lbl_check_lenght.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_check_lenght.Location = new System.Drawing.Point(35, 176);
            this.lbl_check_lenght.Name = "lbl_check_lenght";
            this.lbl_check_lenght.Size = new System.Drawing.Size(23, 25);
            this.lbl_check_lenght.TabIndex = 41;
            this.lbl_check_lenght.Text = "✓";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(16, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(318, 24);
            this.label1.TabIndex = 46;
            this.label1.Text = "Password must contain the following:";
            // 
            // lbl_text_lowercase
            // 
            this.lbl_text_lowercase.AutoSize = true;
            this.lbl_text_lowercase.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_text_lowercase.ForeColor = System.Drawing.Color.Red;
            this.lbl_text_lowercase.Location = new System.Drawing.Point(85, 36);
            this.lbl_text_lowercase.Name = "lbl_text_lowercase";
            this.lbl_text_lowercase.Size = new System.Drawing.Size(164, 24);
            this.lbl_text_lowercase.TabIndex = 42;
            this.lbl_text_lowercase.Text = "A lowercase letter.";
            // 
            // lbl_text_lenght
            // 
            this.lbl_text_lenght.AutoSize = true;
            this.lbl_text_lenght.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_text_lenght.ForeColor = System.Drawing.Color.Red;
            this.lbl_text_lenght.Location = new System.Drawing.Point(85, 176);
            this.lbl_text_lenght.Name = "lbl_text_lenght";
            this.lbl_text_lenght.Size = new System.Drawing.Size(195, 24);
            this.lbl_text_lenght.TabIndex = 45;
            this.lbl_text_lenght.Text = "Minimum 8 characters";
            // 
            // lbl_text_capital
            // 
            this.lbl_text_capital.AutoSize = true;
            this.lbl_text_capital.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_text_capital.ForeColor = System.Drawing.Color.Red;
            this.lbl_text_capital.Location = new System.Drawing.Point(85, 80);
            this.lbl_text_capital.Name = "lbl_text_capital";
            this.lbl_text_capital.Size = new System.Drawing.Size(238, 24);
            this.lbl_text_capital.TabIndex = 43;
            this.lbl_text_capital.Text = "A capital (uppercase) letter.";
            // 
            // btn_SubmitNewPassword
            // 
            this.btn_SubmitNewPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(157)))), ((int)(((byte)(88)))));
            this.btn_SubmitNewPassword.FlatAppearance.BorderSize = 0;
            this.btn_SubmitNewPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SubmitNewPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_SubmitNewPassword.ForeColor = System.Drawing.Color.White;
            this.btn_SubmitNewPassword.Location = new System.Drawing.Point(70, 225);
            this.btn_SubmitNewPassword.Name = "btn_SubmitNewPassword";
            this.btn_SubmitNewPassword.Size = new System.Drawing.Size(303, 37);
            this.btn_SubmitNewPassword.TabIndex = 51;
            this.btn_SubmitNewPassword.Text = "Submit";
            this.btn_SubmitNewPassword.UseVisualStyleBackColor = false;
            this.btn_SubmitNewPassword.Click += new System.EventHandler(this.btn_Submit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label3.Location = new System.Drawing.Point(37, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 20);
            this.label3.TabIndex = 50;
            this.label3.Text = "Old password";
            // 
            // input_OldPassword
            // 
            this.input_OldPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.input_OldPassword.Location = new System.Drawing.Point(38, 27);
            this.input_OldPassword.Name = "input_OldPassword";
            this.input_OldPassword.PasswordChar = '*';
            this.input_OldPassword.Size = new System.Drawing.Size(367, 32);
            this.input_OldPassword.TabIndex = 49;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label2.Location = new System.Drawing.Point(37, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(223, 20);
            this.label2.TabIndex = 48;
            this.label2.Text = "Re-enter your new password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label4.Location = new System.Drawing.Point(37, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 20);
            this.label4.TabIndex = 47;
            this.label4.Text = "New Password";
            // 
            // label_PasswordsNoMatch
            // 
            this.label_PasswordsNoMatch.AutoSize = true;
            this.label_PasswordsNoMatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_PasswordsNoMatch.ForeColor = System.Drawing.Color.Red;
            this.label_PasswordsNoMatch.Location = new System.Drawing.Point(203, 78);
            this.label_PasswordsNoMatch.Name = "label_PasswordsNoMatch";
            this.label_PasswordsNoMatch.Size = new System.Drawing.Size(199, 20);
            this.label_PasswordsNoMatch.TabIndex = 33;
            this.label_PasswordsNoMatch.Text = "Passwords do not match!";
            this.label_PasswordsNoMatch.Click += new System.EventHandler(this.label_PasswordsNoMatch_Click);
            // 
            // Input_Password_01
            // 
            this.Input_Password_01.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Input_Password_01.Location = new System.Drawing.Point(38, 101);
            this.Input_Password_01.Name = "Input_Password_01";
            this.Input_Password_01.PasswordChar = '*';
            this.Input_Password_01.Size = new System.Drawing.Size(367, 32);
            this.Input_Password_01.TabIndex = 50;
            // 
            // Input_Password_02
            // 
            this.Input_Password_02.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Input_Password_02.Location = new System.Drawing.Point(38, 179);
            this.Input_Password_02.Name = "Input_Password_02";
            this.Input_Password_02.PasswordChar = '*';
            this.Input_Password_02.Size = new System.Drawing.Size(367, 32);
            this.Input_Password_02.TabIndex = 51;
            // 
            // btn_BackFromNewPassword
            // 
            this.btn_BackFromNewPassword.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_BackFromNewPassword.BackgroundImage")));
            this.btn_BackFromNewPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_BackFromNewPassword.Location = new System.Drawing.Point(30, 59);
            this.btn_BackFromNewPassword.Name = "btn_BackFromNewPassword";
            this.btn_BackFromNewPassword.Size = new System.Drawing.Size(78, 40);
            this.btn_BackFromNewPassword.TabIndex = 28;
            this.btn_BackFromNewPassword.UseVisualStyleBackColor = true;
            this.btn_BackFromNewPassword.Click += new System.EventHandler(this.btn_BackFromNewPassword_Click);
            // 
            // UserAccountPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 637);
            this.Controls.Add(this.btn_BackFromNewPassword);
            this.Controls.Add(this.panel_NewPassword);
            this.Controls.Add(this.panel_mainInfo);
            this.Controls.Add(this.pBox_UserIcon);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UserAccountPage";
            ((System.ComponentModel.ISupportInitialize)(this.pBox_UserIcon)).EndInit();
            this.panel_mainInfo.ResumeLayout(false);
            this.panel_mainInfo.PerformLayout();
            this.panel_NewPassword.ResumeLayout(false);
            this.panel_NewPassword.PerformLayout();
            this.panel_PasswordChecks.ResumeLayout(false);
            this.panel_PasswordChecks.PerformLayout();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.PictureBox pBox_UserIcon;

        #endregion

        private System.Windows.Forms.Timer timer_Animation;
        private System.Windows.Forms.Panel panel_mainInfo;
        private System.Windows.Forms.Button btn_ChangePassword;
        private System.Windows.Forms.Label lbl_UserEmail;
        private System.Windows.Forms.Label lbl_Email;
        private System.Windows.Forms.Label lbl_LastName;
        private System.Windows.Forms.Label lbl_FirstName;
        private System.Windows.Forms.TextBox tBox_FirstName;
        private System.Windows.Forms.TextBox tBox_LastName;
        private System.Windows.Forms.Button btn_LogOut;
        private System.Windows.Forms.Label lbl_NewPass;
        private System.Windows.Forms.Panel panel_NewPassword;
        private System.Windows.Forms.Label lbl_check_lowercase;
        private System.Windows.Forms.Label label_PasswordsNoMatch;
        private System.Windows.Forms.TextBox Input_Password_01;
        private System.Windows.Forms.TextBox Input_Password_02;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_text_lenght;
        private System.Windows.Forms.Label lbl_text_number;
        private System.Windows.Forms.Label lbl_text_capital;
        private System.Windows.Forms.Label lbl_text_lowercase;
        private System.Windows.Forms.Label lbl_check_lenght;
        private System.Windows.Forms.Label lbl_check_number;
        private System.Windows.Forms.Label lbl_check_uppercase;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox input_OldPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_SubmitNewPassword;
        private System.Windows.Forms.Panel panel_PasswordChecks;
        private System.Windows.Forms.Button btn_BackFromNewPassword;
        private System.Windows.Forms.Label label_OldPassRequired;
        private System.Windows.Forms.Label label_Result;
    }
}