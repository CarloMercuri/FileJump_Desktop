using FileJump.CustomControls;
using FileJump.Forms;
using FileJump.GUI;
using FileJump.Settings;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileJump.FormElements
{
    public class OnlineStorageFormElement
    {
        private MainAppForm mainForm { get; set; }

        private Panel MainPanel { get; set; }

        public Panel CreateOnlineStoragePage(Point location, int width, int height, MainAppForm _form)
        {
            mainForm = _form;

            MainPanel = new Panel();
            MainPanel.Location = location;
            MainPanel.Size = new Size(width, height);
            MainPanel.BackColor = Color.Transparent;

            if (!UserSettings.LoggedOn)
            {
                CreateOfflinePage();
            }
            else
            {
                CreateOnlinePage();
            }

            return MainPanel;
        }

        private void CreateOfflinePage()
        {
            MainPanel.Controls.Clear();

            Label label_Text = new Label();

            label_Text.Font = GUITools.FONT_WallText;
            label_Text.Size = new Size(MainPanel.Width, 100);
            label_Text.AutoSize = false;
            label_Text.TextAlign = ContentAlignment.MiddleCenter;
            label_Text.ForeColor = GUITools.COLOR_DarkMode_Text_Light;
            label_Text.Text = "You are not logged in!\r\n\r\nLOGIN to your account, or register a new one to access all of the online features.";
            //label_Text.Location = new Point((MainPanel.Width / 2) - TextRenderer.MeasureText(label_Text.Text, label_Text.Font).Width / 2, 200);
            label_Text.Location = new Point(0, 100);

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

        private void LoginButtonClick(object sender, EventArgs e)
        {
            mainForm.LoadAccountPage("Login");
        }

        private void RegisterButtonClick(object sender, EventArgs e)
        {
            mainForm.LoadAccountPage("Registration");
        }

        private void CreateOnlinePage()
        {
            
        }


    }
}
