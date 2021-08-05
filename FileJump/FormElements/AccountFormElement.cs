using FileJump.CustomControls;
using FileJump.GUI;
using FileJump.Network;
using FileJump.Settings;
using FileJump_Network.EventSystem;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileJump.FormElements
{
    public class AccountFormElement
    {
        private Form mainForm { get; set; }
        private Panel MainPanel { get; set; }

        private Label label_FailLogin { get; set; }

        private TextBox input_Email { get; set; }
        private TextBox input_Password { get; set; }

        // REGISTRATION

        private TextBox input_FirstName { get; set; }
        private TextBox input_LastName { get; set; }

        private TextBox input_RegisterPassword1 { get; set; }
        private TextBox input_RegisterPassword2 { get; set; }

        private Label label_PasswordNoMatch { get; set; }
        private Label label_EmailNotValid { get; set; }

        private Panel panel_PasswordChecks { get; set; }

        private PictureBox pb_Check_Lower { get; set; }
        private PictureBox pb_Check_Upper { get; set; }
        private PictureBox pb_Check_Number { get; set; }
        private PictureBox pb_Check_Lenght { get; set; }

        // Checks
        private bool EmailValid { get; set; }
        private bool PasswordValid { get; set; }
        



        private CustomGeneralButton btn_SendRegistrationInfo { get; set; }


        private CustomGeneralButton btn_SendLoginInfo { get; set; }
               

        public Panel CreateAccountPanel(Point location, int width, int height, Form _form, int PageIndex = -1)
        {
            // Events
            ApiCommunication.LoginActionResult += LoginActionResult;
            ApiCommunication.RegistrationActionResult += RegistrationActionResult;

            mainForm = _form;

            MainPanel = new Panel();
            MainPanel.Location = location;
            MainPanel.Size = new Size(width, height);
            MainPanel.BackColor = Color.Transparent;

            if(PageIndex == 0)
            {
                CreateRegistrationPage();
                return MainPanel;
            }

            if(PageIndex == 1)
            {
                CreateLoginPage();
                return MainPanel;
            }

            if (!UserSettings.LoggedOn)
            {
                CreateOfflinePage();
            } else
            {
                CreateOnlinePage();
            }

            return MainPanel;
        }

        private void ReloadMainPage()
        {
            if (!UserSettings.LoggedOn)
            {
                CreateOfflinePage();
            }
            else
            {
                CreateOnlinePage();
            }
        }

        private void CreateOfflinePage()
        {
            MainPanel.Controls.Clear();

            Label label_Text = new Label();

            label_Text.Font = GUITools.FONT_WallText;
            label_Text.Size = new Size(MainPanel.Width, 150);
            label_Text.AutoSize = false;
            label_Text.TextAlign = ContentAlignment.MiddleCenter;
            label_Text.ForeColor = GUITools.COLOR_DarkMode_Text_Light;
            label_Text.Text = "You are not logged in!\r\n\r\nLOGIN to your account, or register a new one to access all of the online features.";
            //label_Text.Location = new Point((MainPanel.Width / 2) - TextRenderer.MeasureText(label_Text.Text, label_Text.Font).Width / 2, 200);
            label_Text.Location = new Point(0 , 100);

            MainPanel.Controls.Add(label_Text);

            //
            // LOGIN BUTTON
            //

            CustomGeneralButton btn_Login = new CustomGeneralButton();

            btn_Login.Size = new Size(200, 50);


            btn_Login.Text = "";

            btn_Login.TextFont = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Pixel);

            btn_Login.Location = new Point((int)((decimal)MainPanel.Width / 3.3M - btn_Login.Width / 2), label_Text.Location.Y + label_Text.Size.Height + 10);

            btn_Login.ButtonText = "Login";
            btn_Login.ForeColor = GUITools.COLOR_DarkMode_Text_Bright;
            btn_Login.Click += LoginButtonClick;

            MainPanel.Controls.Add(btn_Login);

            //
            // "or" Text
            //

            Label label_Or = new Label();

            label_Or.Font = GUITools.FONT_WallText;
            label_Or.AutoSize = true;
            label_Or.ForeColor = GUITools.COLOR_DarkMode_Text_Light;
            label_Or.Text = "or";
            //label_Text.Location = new Point((MainPanel.Width / 2) - TextRenderer.MeasureText(label_Text.Text, label_Text.Font).Width / 2, 200);
            label_Or.Location = new Point(btn_Login.Location.X + btn_Login.Width + 40, btn_Login.Location.Y + btn_Login.Height - label_Or.Height);

            MainPanel.Controls.Add(label_Or);

            //
            // REGISTER BUTTON
            //

            CustomGeneralButton btn_Register = new CustomGeneralButton();

            btn_Register.Size = new Size(200, 50);


            btn_Register.Text = "";

            btn_Register.TextFont = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Pixel);

            btn_Register.Location = new Point(MainPanel.Width - btn_Login.Width - btn_Register.Width / 2, label_Text.Location.Y + label_Text.Size.Height + 10);

            btn_Register.ButtonText = "Register";
            btn_Register.ForeColor = GUITools.COLOR_DarkMode_Text_Bright;
            btn_Register.Click += RegisterButtonClick;

            MainPanel.Controls.Add(btn_Register);
        }

        private void RegisterButtonClick(object sender, EventArgs e)
        {
            CreateRegistrationPage();
        }

        private void LoginButtonClick(object sender, EventArgs e)
        {
            CreateLoginPage();
        }

        private void CreateLoginPage()
        {
            MainPanel.Controls.Clear();

            //
            // Main Panel
            //

            Panel LoginPanel= new Panel();

            LoginPanel.Size = new Size((int)((decimal)MainPanel.Width / 2),
                                                     (int)((decimal)MainPanel.Height / 2M));

            LoginPanel.Location = new Point(
                                  MainPanel.Width / 2 - LoginPanel.Width / 2,
                                  MainPanel.Height / 2 - LoginPanel.Height / 2);

            LoginPanel.BackColor = Color.Transparent;
            LoginPanel.Paint += BorderPaint;

            MainPanel.Controls.Add(LoginPanel);

            //
            // Overhead text
            //

            Label label_Title = new Label();

            label_Title.AutoSize = true;
            label_Title.Text = "Login with your Email";
            label_Title.Font = new Font("Arial", 18, FontStyle.Bold, GraphicsUnit.Pixel);
            label_Title.ForeColor = GUITools.COLOR_DarkMode_Text_Light;
            label_Title.Location = new Point(LoginPanel.Width / 2 - TextRenderer.MeasureText(label_Title.Text, label_Title.Font).Width / 2, 20);
            label_Title.TabIndex = 12;


            LoginPanel.Controls.Add(label_Title);

            // Input sizes
            decimal width = (decimal)LoginPanel.Width;
            int inputWidth = (int)Math.Round((width / 100M) * 90);

            //
            // Input email
            //
            input_Email = new TextBox();

            input_Email.Font = GUITools.FONT_WallText;
            //input_Email.Size = new Size(LoginPanel.Width, 32);

            input_Email.Size = new Size(inputWidth, 32);
            input_Email.BackColor = GUITools.COLOR_Dividers_Light;
            input_Email.ForeColor = Color.White;
            input_Email.Location = new Point(LoginPanel.Width / 2 - input_Email.Width / 2, 100);
            input_Email.TabIndex = 11;

            input_Email.TextChanged += LoginInputTextChanged;

            LoginPanel.Controls.Add(input_Email);

            //
            // Email Label
            //

            Label label_Email = new Label();

            label_Email.AutoSize = true;
            label_Email.Font = new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label_Email.ForeColor = GUITools.COLOR_DarkMode_Text_Light;
            label_Email.Location = new Point(input_Email.Location.X, input_Email.Location.Y - label_Email.Height - 2);
            label_Email.TabIndex = 12;
            label_Email.Text = "E-Mail";

            LoginPanel.Controls.Add(label_Email);

            //
            // Label failed login
            //

            label_FailLogin = new Label();

            label_FailLogin.AutoSize = false;
            label_FailLogin.TextAlign = ContentAlignment.MiddleCenter;
            label_FailLogin.Size = new Size(LoginPanel.Width, 30);
            label_FailLogin.Text = "";
            label_FailLogin.Font = new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label_FailLogin.ForeColor = GUITools.COLOR_RedText;
            label_FailLogin.Location = new Point(0, label_Email.Location.Y - 25);
            label_FailLogin.TabIndex = 12;
            label_FailLogin.Visible = false;


            LoginPanel.Controls.Add(label_FailLogin);

            //
            // Password Label
            //

            Label label_Password = new Label();

            label_Password.AutoSize = true;
            label_Password.Font = new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label_Password.ForeColor = GUITools.COLOR_DarkMode_Text_Light;
            label_Password.Location = new Point(input_Email.Location.X, input_Email.Location.Y + 50);
            label_Password.TabIndex = 12;
            label_Password.Text = "Password";

            LoginPanel.Controls.Add(label_Password);



            //
            // Input Password
            //
            input_Password = new TextBox();

            input_Password.Font = GUITools.FONT_WallText;
            //input_Email.Size = new Size(LoginPanel.Width, 32);

            input_Password.Size = new Size(inputWidth, 32);
            input_Password.BackColor = GUITools.COLOR_Dividers_Light;
            input_Password.ForeColor = Color.White;
            input_Password.Location = new Point(LoginPanel.Width / 2 - input_Password.Width / 2, label_Password.Location.Y + label_Password.Height + 5);
            input_Password.TabIndex = 11;
            input_Password.TextChanged += LoginInputTextChanged;

            LoginPanel.Controls.Add(input_Password);



            // 
            // check_Rememberme
            // 

            CheckBox check_Rememberme = new CheckBox();

            check_Rememberme.AutoSize = true;
            check_Rememberme.Font = new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            check_Rememberme.ForeColor = GUITools.COLOR_DarkMode_Text_Light;
            check_Rememberme.Location = new Point(input_Email.Location.X, input_Password.Location.Y + input_Password.Height + 10);
            check_Rememberme.Size = new Size(141, 24);
            check_Rememberme.TabIndex = 10;
            check_Rememberme.Text = "Remember me";
            check_Rememberme.UseVisualStyleBackColor = true;
            check_Rememberme.Checked = true;

            LoginPanel.Controls.Add(check_Rememberme);

            // 
            // btn_ForgotPassword
            // 

            Button btn_ForgotPassword = new Button();

            btn_ForgotPassword.BackColor = Color.Transparent;
            btn_ForgotPassword.FlatAppearance.BorderSize = 0;
            btn_ForgotPassword.FlatStyle = FlatStyle.Flat;
            btn_ForgotPassword.Font = new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            btn_ForgotPassword.Text = "Forgot password?";
            btn_ForgotPassword.Size = new Size(TextRenderer.MeasureText(btn_ForgotPassword.Text, btn_ForgotPassword.Font).Width + 10, 25);
            btn_ForgotPassword.ForeColor = GUITools.COLOR_DarkMode_Text_Light;
            btn_ForgotPassword.Location = new Point(input_Email.Location.X + input_Email.Width - btn_ForgotPassword.Width,
                input_Password.Location.Y + input_Password.Height + 10);

            btn_ForgotPassword.FlatAppearance.MouseOverBackColor = btn_ForgotPassword.BackColor;
            btn_ForgotPassword.FlatAppearance.MouseDownBackColor = btn_ForgotPassword.BackColor;

            btn_ForgotPassword.MouseEnter += (s, e) => btn_ForgotPassword.Cursor = Cursors.Hand;
            btn_ForgotPassword.MouseLeave += (s, e) => btn_ForgotPassword.Cursor = Cursors.Arrow;

            btn_ForgotPassword.Name = "btn_ForgotPassword";

            btn_ForgotPassword.TabIndex = 15;

            btn_ForgotPassword.UseVisualStyleBackColor = false;
            //btn_ForgotPassword.Click += new System.EventHandler(this.btn_ForgotPassword_Click);

            LoginPanel.Controls.Add(btn_ForgotPassword);

            //
            // Send button
            //

            btn_SendLoginInfo = new CustomGeneralButton();

            btn_SendLoginInfo.Size = new Size(input_Email.Width, 50);


            btn_SendLoginInfo.Text = "";

            btn_SendLoginInfo.TextFont = GUITools.FONT_WallText;

            btn_SendLoginInfo.Location = new Point(check_Rememberme.Location.X, check_Rememberme.Location.Y + check_Rememberme.Height + 20);

            btn_SendLoginInfo.ButtonText = "Login";
            btn_SendLoginInfo.TextColor = GUITools.COLOR_DarkMode_Text_Bright;
            btn_SendLoginInfo.Click += SendLoginInfo;

            LoginPanel.Controls.Add(btn_SendLoginInfo);

            //
            // "or" text
            //

            Label label_Or = new Label();

            label_Or.Font = GUITools.FONT_WallText;
            label_Or.AutoSize = true;
            label_Or.ForeColor = GUITools.COLOR_DarkMode_Text_Light;
            label_Or.Text = "or";
            //label_Text.Location = new Point((MainPanel.Width / 2) - TextRenderer.MeasureText(label_Text.Text, label_Text.Font).Width / 2, 200);
            label_Or.Location = new Point(LoginPanel.Location.X + LoginPanel.Width / 2 - TextRenderer.MeasureText(label_Or.Text, label_Or.Font).Width / 2,
                LoginPanel.Location.Y + LoginPanel.Height + 20);

            MainPanel.Controls.Add(label_Or);

            //
            // register button
            //

            CustomGeneralButton btn_RegisterAccount = new CustomGeneralButton();

            btn_RegisterAccount.Size = new Size(btn_SendLoginInfo.Width, 50);


            btn_RegisterAccount.Text = "";

            btn_RegisterAccount.TextFont = GUITools.FONT_WallText;

            btn_RegisterAccount.Location = new Point(LoginPanel.Location.X + LoginPanel.Width / 2 - btn_RegisterAccount.Width / 2,
                label_Or.Location.Y + label_Or.Height + 20);

            btn_RegisterAccount.ButtonText = "Register new Account";
            btn_RegisterAccount.ForeColor = GUITools.COLOR_DarkMode_Text_Bright;

            btn_RegisterAccount.Click += RegisterButtonClick;

            mainForm.AcceptButton = btn_SendLoginInfo;

            MainPanel.Controls.Add(btn_RegisterAccount);


        }

        private void CreateRegistrationPage()
        {
            MainPanel.Controls.Clear();

            //
            // Main Panel
            //

            Panel RegistrationInputPanel = new Panel();

            RegistrationInputPanel.Size = new Size((int)((decimal)MainPanel.Width / 2.2M),
                                                     (int)((decimal)MainPanel.Height / 1.3M));

            RegistrationInputPanel.Location = new Point(
                                  (int)((decimal)MainPanel.Width / 3.5M) - RegistrationInputPanel.Width / 2,
                                  MainPanel.Height / 2 - RegistrationInputPanel.Height / 2);

            RegistrationInputPanel.BackColor = Color.Transparent;
            RegistrationInputPanel.Paint += BorderPaint;

            MainPanel.Controls.Add(RegistrationInputPanel);

            //
            // Overhead text
            //

            Label label_Title = new Label();

            label_Title.AutoSize = true;
            label_Title.Text = "Register a new Account";
            label_Title.Font = new Font("Arial", 18, FontStyle.Bold, GraphicsUnit.Pixel);
            label_Title.ForeColor = GUITools.COLOR_DarkMode_Text_Light;
            label_Title.Location = new Point(RegistrationInputPanel.Width / 2 - TextRenderer.MeasureText(label_Title.Text, label_Title.Font).Width / 2, 20);
            label_Title.TabIndex = 12;


            RegistrationInputPanel.Controls.Add(label_Title);

            // Input sizes
            decimal width = (decimal)RegistrationInputPanel.Width;
            int inputWidth = (int)Math.Round((width / 100M) * 90);

            int curY = 80;
            int leftX = RegistrationInputPanel.Width / 2 - inputWidth / 2;
            int fieldSpacing = 60;
            

            //
            // Email Label
            //

            Label label_Email = new Label();

            label_Email.AutoSize = true;
            label_Email.Font = new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label_Email.ForeColor = GUITools.COLOR_DarkMode_Text_Light;
            label_Email.Location = new Point(leftX, curY);
            label_Email.TabIndex = 12;
            label_Email.Text = "E-Mail";

            RegistrationInputPanel.Controls.Add(label_Email);

            //
            // Email not valid label
            //

            label_EmailNotValid = new Label();

            label_EmailNotValid.AutoSize = true;
            label_EmailNotValid.Font = new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label_EmailNotValid.Text = "E-mail is not valid!";
            label_EmailNotValid.ForeColor = GUITools.COLOR_RedText;
            label_EmailNotValid.Location = new Point(leftX + inputWidth - TextRenderer.MeasureText(label_EmailNotValid.Text, label_EmailNotValid.Font).Width,
                curY);
            label_EmailNotValid.TabIndex = 12;


            RegistrationInputPanel.Controls.Add(label_EmailNotValid);

            //
            // Input email
            //
            input_Email = new TextBox();

            input_Email.Font = GUITools.FONT_WallText;
            //input_Email.Size = new Size(LoginPanel.Width, 32);

            input_Email.Size = new Size(inputWidth, 32);
            input_Email.BackColor = GUITools.COLOR_Dividers_Light;
            input_Email.ForeColor = Color.White;
            input_Email.Location = new Point(leftX, label_Email.Location.Y + label_Email.Height + 5);
            input_Email.TabIndex = 11;

            input_Email.TextChanged += RegisterInputTextChanged;

            RegistrationInputPanel.Controls.Add(input_Email);

            curY += fieldSpacing;


            //
            // First Name Label
            //

            Label label_FirstName = new Label();

            label_FirstName.AutoSize = true;
            label_FirstName.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            label_FirstName.ForeColor = GUITools.COLOR_DarkMode_Text_Light;
            label_FirstName.Location = new Point(leftX, curY);
            label_FirstName.TabIndex = 12;
            label_FirstName.Text = "First Name";

            RegistrationInputPanel.Controls.Add(label_FirstName);


            //
            // Input First Name
            //
            input_FirstName = new TextBox();

            input_FirstName.Font = GUITools.FONT_WallText;
            //input_Email.Size = new Size(LoginPanel.Width, 32);

            input_FirstName.Size = new Size(inputWidth, 32);
            input_FirstName.BackColor = GUITools.COLOR_Dividers_Light;
            input_FirstName.ForeColor = Color.White;
            input_FirstName.Location = new Point(leftX, curY + label_FirstName.Height + 5);
            input_FirstName.TabIndex = 11;
            input_FirstName.TextChanged += RegisterInputTextChanged;

            RegistrationInputPanel.Controls.Add(input_FirstName);

            curY += fieldSpacing;

            //
            // Last Name Label
            //

            Label label_LastName = new Label();

            label_LastName.AutoSize = true;
            label_LastName.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            label_LastName.ForeColor = GUITools.COLOR_DarkMode_Text_Light;
            label_LastName.Location = new Point(leftX, curY);
            label_LastName.TabIndex = 12;
            label_LastName.Text = "Last Name";

            RegistrationInputPanel.Controls.Add(label_LastName);

            //
            // Input Last Name
            //

            input_LastName = new TextBox();

            input_LastName.Font = GUITools.FONT_WallText;
            input_LastName.Size = new Size(inputWidth, 32);
            input_LastName.BackColor = GUITools.COLOR_Dividers_Light;
            input_LastName.ForeColor = Color.White;
            input_LastName.Location = new Point(leftX, curY + label_FirstName.Height + 5);
            input_LastName.TabIndex = 11;
            input_LastName.TextChanged += RegisterInputTextChanged;

            RegistrationInputPanel.Controls.Add(input_LastName);

            curY += fieldSpacing;
            curY += fieldSpacing / 2; // Spacing the password fields a bit

            //
            // Password 1 Label
            //

            Label label_Password_1 = new Label();

            label_Password_1.AutoSize = true;
            label_Password_1.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            label_Password_1.ForeColor = GUITools.COLOR_DarkMode_Text_Light;
            label_Password_1.Location = new Point(leftX, curY);
            label_Password_1.TabIndex = 12;
            label_Password_1.Text = "Password";

            RegistrationInputPanel.Controls.Add(label_Password_1);

            //
            // Input Password 1
            //

            input_RegisterPassword1 = new TextBox();

            input_RegisterPassword1.Font = GUITools.FONT_WallText;
            input_RegisterPassword1.Size = new Size(inputWidth, 32);
            input_RegisterPassword1.BackColor = GUITools.COLOR_Dividers_Light;
            input_RegisterPassword1.ForeColor = Color.White;
            input_RegisterPassword1.Location = new Point(leftX, curY + label_FirstName.Height + 5);
            input_RegisterPassword1.TabIndex = 11;
            input_RegisterPassword1.PasswordChar = '*';
            input_RegisterPassword1.TextChanged += RegisterInputTextChanged;

            RegistrationInputPanel.Controls.Add(input_RegisterPassword1);

            curY += fieldSpacing;

            //
            // Password 2 Label
            //

            Label label_Password_2 = new Label();

            label_Password_2.AutoSize = true;
            label_Password_2.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            label_Password_2.ForeColor = GUITools.COLOR_DarkMode_Text_Light;
            label_Password_2.Location = new Point(leftX, curY);
            label_Password_2.TabIndex = 12;
            label_Password_2.Text = "Repeat Password";

            RegistrationInputPanel.Controls.Add(label_Password_2);


            //
            // Input Password 2
            //

            input_RegisterPassword2 = new TextBox();

            input_RegisterPassword2.Font = GUITools.FONT_WallText;
            input_RegisterPassword2.Size = new Size(inputWidth, 32);
            input_RegisterPassword2.BackColor = GUITools.COLOR_Dividers_Light;
            input_RegisterPassword2.ForeColor = Color.White;
            input_RegisterPassword2.Location = new Point(leftX, curY + label_FirstName.Height + 5);
            input_RegisterPassword2.TabIndex = 11;
            input_RegisterPassword2.PasswordChar = '*';
            input_RegisterPassword2.TextChanged += RegisterInputTextChanged;

            RegistrationInputPanel.Controls.Add(input_RegisterPassword2);

            curY += fieldSpacing;

            label_PasswordNoMatch = new Label();

            label_PasswordNoMatch.AutoSize = true;
            label_PasswordNoMatch.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            label_PasswordNoMatch.ForeColor = GUITools.COLOR_RedText;
            label_PasswordNoMatch.Text = "Passwords do not match!";
            label_PasswordNoMatch.Location = new Point(leftX + inputWidth - TextRenderer.MeasureText(label_PasswordNoMatch.Text, label_PasswordNoMatch.Font).Width,
                curY - 3);
            label_PasswordNoMatch.TabIndex = 12;


            RegistrationInputPanel.Controls.Add(label_PasswordNoMatch);

            //
            // Send button
            //

            btn_SendRegistrationInfo = new CustomGeneralButton();

            btn_SendRegistrationInfo.Size = new Size(inputWidth, 50);


            btn_SendRegistrationInfo.Text = "";

            btn_SendRegistrationInfo.TextFont = GUITools.FONT_WallText;

            btn_SendRegistrationInfo.Location = new Point(RegistrationInputPanel.Width / 2 - btn_SendRegistrationInfo.Width / 2,
                RegistrationInputPanel.Height - btn_SendRegistrationInfo.Height - 10);

            btn_SendRegistrationInfo.ButtonText = "Register Account";
            btn_SendRegistrationInfo.TextColor = GUITools.COLOR_DarkMode_Text_Bright;
            btn_SendRegistrationInfo.Click += SendRegistrationInfo;

            RegistrationInputPanel.Controls.Add(btn_SendRegistrationInfo);


            ////////////////////////////    RIGHT PANEL   ///////////////////////////////


            panel_PasswordChecks = new Panel();

            panel_PasswordChecks.BackColor = Color.Transparent;
            panel_PasswordChecks.Size = new Size(300, 400);
            panel_PasswordChecks.Location = new Point(RegistrationInputPanel.Location.X + RegistrationInputPanel.Width + 20,
                MainPanel.Height / 2 - panel_PasswordChecks.Height / 2);

            MainPanel.Controls.Add(panel_PasswordChecks);

            int startY = 80;
            
            int checkX = 20;
            int textX = 60;

            Label title = new Label();

            title.AutoSize = true;
            title.Font = GUITools.FONT_WallText;
            title.Text = "Password must contain the following:";
            title.ForeColor = GUITools.COLOR_DarkMode_Text_Light;
            title.Location = new Point(panel_PasswordChecks.Width / 2 -  TextRenderer.MeasureText(title.Text, title.Font).Width / 2, startY);
            title.TabIndex = 12;
            

            panel_PasswordChecks.Controls.Add(title);

            int pboxSize = TextRenderer.MeasureText(title.Text, title.Font).Height;

            startY += 60;
            
            //
            // LOWERCASE
            //

            pb_Check_Lower = new PictureBox();

            pb_Check_Lower.Size = new Size(pboxSize, pboxSize);
            pb_Check_Lower.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_Check_Lower.Image = Properties.Resources.TransferResult_CrossThick;
            pb_Check_Lower.Location = new Point(checkX, startY);

            panel_PasswordChecks.Controls.Add(pb_Check_Lower);

            Label upc = new Label();

            upc.AutoSize = true;
            upc.Font = GUITools.FONT_WallText_Small;
            upc.Text = "A lowercase letter.";
            upc.ForeColor = GUITools.COLOR_DarkMode_Text_Light;
            upc.Location = new Point(textX, startY);
            upc.TabIndex = 12;

            panel_PasswordChecks.Controls.Add(upc);

            startY += 50;

            //
            // UPPERCASE
            //

            pb_Check_Upper = new PictureBox();

            pb_Check_Upper.Size = new Size(pboxSize, pboxSize);
            pb_Check_Upper.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_Check_Upper.Image = Properties.Resources.TransferResult_CrossThick;
            pb_Check_Upper.Location = new Point(checkX, startY);

            panel_PasswordChecks.Controls.Add(pb_Check_Upper);

            Label lwc = new Label();

            lwc.AutoSize = true;
            lwc.Font = GUITools.FONT_WallText_Small;
            lwc.Text = "An capital (uppercase) letter.";
            lwc.ForeColor = GUITools.COLOR_DarkMode_Text_Light;
            lwc.Location = new Point(textX, startY);
            lwc.TabIndex = 12;

            panel_PasswordChecks.Controls.Add(lwc);

            startY += 50;

            //
            // NUMBER
            //

            pb_Check_Number = new PictureBox();

            pb_Check_Number.Size = new Size(pboxSize, pboxSize);
            pb_Check_Number.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_Check_Number.Image = Properties.Resources.TransferResult_CrossThick;
            pb_Check_Number.Location = new Point(checkX, startY);

            panel_PasswordChecks.Controls.Add(pb_Check_Number);

            Label nmr = new Label();

            nmr.AutoSize = true;
            nmr.Font = GUITools.FONT_WallText_Small;
            nmr.Text = "A number.";
            nmr.ForeColor = GUITools.COLOR_DarkMode_Text_Light;
            nmr.Location = new Point(textX, startY);
            nmr.TabIndex = 12;

            panel_PasswordChecks.Controls.Add(nmr);

            startY += 50;

            //
            // LENGHT
            //

            pb_Check_Lenght = new PictureBox();

            pb_Check_Lenght.Size = new Size(pboxSize, pboxSize);
            pb_Check_Lenght.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_Check_Lenght.Image = Properties.Resources.TransferResult_CrossThick;
            pb_Check_Lenght.Location = new Point(checkX, startY);

            panel_PasswordChecks.Controls.Add(pb_Check_Lenght);

            Label lng = new Label();

            lng.AutoSize = true;
            lng.Font = GUITools.FONT_WallText_Small;
            lng.Text = "Minimum 8 characters";
            lng.ForeColor = GUITools.COLOR_DarkMode_Text_Light;
            lng.Location = new Point(textX, startY);
            lng.TabIndex = 12;

            panel_PasswordChecks.Controls.Add(lng);

            panel_PasswordChecks.Visible = false;
            label_PasswordNoMatch.Visible = false;
            label_EmailNotValid.Visible = false;


            //
            // BACK BUTTON
            //

            CustomGeneralButton btn_Back = new CustomGeneralButton();

            btn_Back.Size = new Size(200, 50);


            btn_Back.Text = "";

            btn_Back.TextFont = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Pixel);

            btn_Back.Location = new Point(MainPanel.Width - btn_Back.Width - 30, MainPanel.Height - btn_Back.Height - 30);

            btn_Back.ButtonText = "Back to Account Page";

            btn_Back.ForeColor = GUITools.COLOR_DarkMode_Text_Bright;

            btn_Back.Click += (sender, args) =>
            {
                ReloadMainPage();
            };

            MainPanel.Controls.Add(btn_Back);
        }



        ////////////////////// REGISTRATION ////////////////////////


        //private void Password_Input_TextChanged(object sender, EventArgs e)
        //{
        //    Password01Valid = PasswordMeetsRequirements(Input_Password_01.Text);

        //    if (Input_Password_01.Text.Length > 0 && Input_Password_01.Text == Input_Password_02.Text)
        //    {
        //        Password02Valid = true;
        //    }
        //    else
        //    {
        //        Password02Valid = false;
        //    }

        //    UpdateValidity();
        //}

        //private void UpdateValidity()
        //{
        //    if (Input_Password_02.Text.Length > 0)
        //    {
        //        if (Password02Valid == false)
        //        {
        //            label_PasswordsNoMatch.Visible = true;
        //        }
        //        else
        //        {
        //            label_PasswordsNoMatch.Visible = false;
        //        }
        //    }

        //    if (Input_Password_01.Text.Length > 0 && !Password01Valid)
        //    {
        //        label_PasswordInvalid.Visible = true;
        //    }
        //    else
        //    {
        //        label_PasswordInvalid.Visible = false;
        //    }

        //    // EMAIL

        //    if (Input_Email.Text.Length > 0)
        //    {
        //        if (EmailValid)
        //        {
        //            label_EmailInvalid.Visible = false;
        //        }
        //        else
        //        {
        //            label_EmailInvalid.Text = "Invalid Email!";
        //            label_EmailInvalid.Visible = true;
        //        }
        //    }
        //    else
        //    {
        //        label_EmailInvalid.Visible = false;
        //    }

        //    if (EmailValid || Password01Valid || Password02Valid)
        //    {
        //        btn_Login.Enabled = true;
        //    }
        //    else
        //    {
        //        btn_Login.Enabled = false;
        //    }


        //}

        private void CreateRegistrationSuccessfulPanel()
        {
            MainPanel.Controls.Clear();
            Label title = new Label();

            title.AutoSize = false;

            title.Size = new Size(600, 300);
            title.BackColor = Color.Transparent;
            title.TextAlign = ContentAlignment.MiddleCenter;
            title.Font = GUITools.FONT_WallText_Big;
            title.Text = "Thank you for registering an account with us!\n\r\n\r\n\r" +
                "An email will be shortly sent to the specified Email,\n\r" +
                "follow the link to activate your account and start\n\n" +
                "uploading your files!";

            title.ForeColor = GUITools.COLOR_DarkMode_Text_Light;

            title.Location = new Point(MainPanel.Width / 2 - title.Width / 2, (int)((decimal)MainPanel.Height / 2.7M) - title.Height / 2); // fine tweaking

            MainPanel.Controls.Add(title);

            //
            // Back button
            //

            CustomGeneralButton btn_Back = new CustomGeneralButton();

            btn_Back.Size = new Size(200, 50);


            btn_Back.Text = "";

            btn_Back.TextFont = new Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Pixel);

            btn_Back.Location = new Point(MainPanel.Width / 2 - btn_Back.Width / 2, title.Location.Y + title.Height + 30);

            btn_Back.ButtonText = "Back to Login";
            btn_Back.ForeColor = GUITools.COLOR_DarkMode_Text_Bright;
            btn_Back.Click += LoginButtonClick;

            MainPanel.Controls.Add(btn_Back);




        }


        private void RegistrationActionResult(object sender, RegistrationResultEventArgs e)
        {
            if (e.Successful)
            {
                MainPanel.Controls.Clear();
                CreateRegistrationSuccessfulPanel();
            }
            else
            {

            }
        }

        private void SendRegistrationInfo(object sender, EventArgs e)
        {
            if(!PasswordValid || !input_RegisterPassword1.Text.Equals(input_RegisterPassword2.Text))
            {
                return;
            }

            // Send the post. Will come back as an event in RegistrationActionResult
            ApiCommunication.SendNewAccountRegistrationData(
                input_Email.Text, input_RegisterPassword1.Text, input_FirstName.Text, input_LastName.Text);

        }

        private bool PasswordMeetsRequirements(string pw)
        {
            bool pass = true;

            // Lenght

            if (pw.Length < 8)
            {
                pb_Check_Lenght.Image = Properties.Resources.TransferResult_CrossThick;
                pass = false;
            }
            else
            {
                pb_Check_Lenght.Image = Properties.Resources.TransferResult_CheckMark;
            }

            // Contains capital letter

            if (pw.Where(char.IsUpper).Count() <= 0)
            {
                pb_Check_Upper.Image = Properties.Resources.TransferResult_CrossThick;
                pass = false;
            }
            else
            {
                pb_Check_Upper.Image = Properties.Resources.TransferResult_CheckMark;
            }

            // Contains lowercase

            if (pw.Where(char.IsLower).Count() <= 0)
            {
                pb_Check_Lower.Image = Properties.Resources.TransferResult_CrossThick;
                pass = false;
            }
            else
            {
                pb_Check_Lower.Image = Properties.Resources.TransferResult_CheckMark;
            }

            // Contains number

            if (pw.Where(char.IsDigit).Count() <= 0)
            {
                pb_Check_Number.Image = Properties.Resources.TransferResult_CrossThick;
                pass = false;
            }
            else
            {
                pb_Check_Number.Image = Properties.Resources.TransferResult_CheckMark;
            }

            return pass;
        }

        private void RegisterInputTextChanged(object sender, EventArgs e)
        {
            // Email

            bool inputValid = true;
            EmailValid = true;

            if(input_Email.Text.Length > 0)
            {
                if (input_Email.Text.Where(x => x.Equals('@')).Count() != 1)
                {
                    label_EmailNotValid.Visible = true;
                    EmailValid = false;
                    inputValid = false;
                } 
                else
                {
                    label_EmailNotValid.Visible = false;
                }
            } 
            else
            {
                EmailValid = false;
                inputValid = false;
            }

           
            // Show panels

            if (input_RegisterPassword1.Text.Length > 0)
            {
                panel_PasswordChecks.Visible = true;
            }
            else
            {
                panel_PasswordChecks.Visible = false;
                inputValid = false;
            }

            if(input_RegisterPassword1.Text != input_RegisterPassword2.Text)
            {
                // Only show the warning when the 2nd password contains characters
                if(input_RegisterPassword2.Text.Length > 0)
                {
                    label_PasswordNoMatch.Visible = true;
                }
                else
                {
                    label_PasswordNoMatch.Visible = false;
                }
                
                inputValid = false;
            } 
            else
            {
                label_PasswordNoMatch.Visible = false;
            }

            PasswordValid = PasswordMeetsRequirements(input_RegisterPassword1.Text);

            if(!PasswordValid || !EmailValid)
            {
                inputValid = false;
            }




            if (inputValid)
            {
                btn_SendRegistrationInfo.Enabled = true;
            }
            else
            {
                btn_SendRegistrationInfo.Enabled = false;
            }




        }

        private void LoginInputTextChanged(object sender, EventArgs e)
        {
            // Hide it regardless
            label_FailLogin.Visible = false;

            if (input_Password.Text.Length > 0 && input_Email.Text.Length > 0)
            {
                btn_SendLoginInfo.Enabled = true;
            }
            else
            {
                btn_SendLoginInfo.Enabled = false;
            }
        }

        private void SendLoginInfo(object sender, EventArgs args)
        {
            if (input_Email.Text.Length > 0 && input_Password.Text.Length > 0)
            {
                btn_SendLoginInfo.Enabled = false;

                ApiCommunication.SendLoginRequest(input_Email.Text, input_Password.Text);

            }
        }

        private void LoginActionResult(object sender, LoginResultEventArgs args)
        {
            btn_SendLoginInfo.Enabled = true;

            if (args.Successful)
            {
                PerformSuccessfulLogin();
            }
            else
            {
                DisplayFailedLogin(args.Message);
            }

        }

        private void DisplayFailedLogin(string message)
        {
            label_FailLogin.Visible = true;
            label_FailLogin.Text = message;

        }

        private void PerformSuccessfulLogin()
        {
            
        }

        private void CreateOnlinePage()
        {
            MainPanel.Controls.Clear();
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
