using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CircularProgressBar;
using FileJump.Network;
using FileJump.Properties;
using FileJump.Settings;
using FileJump_Network.Interfaces;
using FileJump_Network.Models;

namespace FileJump.Forms
{
    public partial class UserAccountPage : Form
    {

        private Panel CurrentPanel { get; set; }


        private string char_checkmark = "\u2713";
        private string char_cross = "X";

        private bool PasswordValid { get; set; }
        private bool PasswordsMatch { get; set; }

        private bool OldPasswordValid { get; set; }

        public UserAccountPage()
        {
            InitializeComponent();

            lbl_UserEmail.Text = UserSettings.UserEmail;
            tBox_FirstName.Text = UserSettings.UserFirstName;
            tBox_LastName.Text = UserSettings.UserLastName;


            Input_Password_01.TextChanged += Password_Input_TextChanged;
            Input_Password_02.TextChanged += Password_Input_TextChanged;

            btn_LogOut.Click += btn_Logout_Click;

            DisableNewPasswordPanel();
            EnableMainInfoPanel();

        }



        public UserAccountPage(AccountInfoModel userModel)
        {
            InitializeComponent();

            Input_Password_01.TextChanged += Password_Input_TextChanged;
            Input_Password_02.TextChanged += Password_Input_TextChanged;

            DisableNewPasswordPanel();
            EnableMainInfoPanel();

            lbl_UserEmail.Text = userModel.Email;
            tBox_FirstName.Text = userModel.FirstName;
            tBox_LastName.Text = userModel.LastName;

        }

        private void DisableMainPanel()
        {
            panel_mainInfo.Visible = false;
        }

        private void DisableNewPasswordPanel()
        {
            panel_NewPassword.Visible = false;
            btn_BackFromNewPassword.Visible = false;
            label_PasswordsNoMatch.Visible = false;
            panel_PasswordChecks.Visible = false;
            label_OldPassRequired.Visible = false;
            Input_Password_01.Text = "";
            Input_Password_02.Text = "";
            input_OldPassword.Text = "";
        }

        private void EnableMainInfoPanel()
        {
            this.AcceptButton = null;
            panel_mainInfo.Visible = true;
            panel_mainInfo.Location = new Point(12, 130);
        }

        private void EnableNewPasswordPanel()
        {
            this.AcceptButton = btn_SubmitNewPassword;
            panel_NewPassword.Visible = true;
            panel_NewPassword.Location = new Point(12, 130);
            btn_BackFromNewPassword.Visible = true;
            label_PasswordsNoMatch.Visible = false;
            panel_PasswordChecks.Visible = false;
            label_OldPassRequired.Visible = false;
            Input_Password_01.Text = "";
            Input_Password_02.Text = "";
            input_OldPassword.Text = "";
            label_Result.Visible = false;

        }

        private void MakeItRed(string which)
        {
            switch (which)
            {
                case "Lenght":
                    lbl_check_lenght.Text = char_cross;
                    lbl_check_lenght.ForeColor = Color.Red;
                    lbl_text_lenght.ForeColor = Color.Red;  
                    break;

                case "Uppercase":
                    lbl_check_uppercase.Text = char_cross;
                    lbl_check_uppercase.ForeColor = Color.Red;
                    lbl_text_capital.ForeColor = Color.Red;
                    break;

                case "Lowercase":
                    lbl_check_lowercase.Text = char_cross;
                    lbl_check_lowercase.ForeColor = Color.Red;
                    lbl_text_lowercase.ForeColor = Color.Red;
                    break;

                case "Number":
                    lbl_check_number.Text = char_cross;
                    lbl_check_number.ForeColor = Color.Red;
                    lbl_text_number.ForeColor = Color.Red;
                    break;
            }
        }

        private void MakeItGreen(string which)
        {
            switch (which)
            {
                case "Lenght":
                    lbl_check_lenght.Text = char_checkmark;
                    lbl_check_lenght.ForeColor = Color.Green;
                    lbl_text_lenght.ForeColor = Color.Green;
                    break;

                case "Uppercase":
                    lbl_check_uppercase.Text = char_checkmark;
                    lbl_check_uppercase.ForeColor = Color.Green;
                    lbl_text_capital.ForeColor = Color.Green;
                    break;

                case "Lowercase":
                    lbl_check_lowercase.Text = char_checkmark;
                    lbl_check_lowercase.ForeColor = Color.Green;
                    lbl_text_lowercase.ForeColor = Color.Green;
                    break;

                case "Number":
                    lbl_check_number.Text = char_checkmark;
                    lbl_check_number.ForeColor = Color.Green;
                    lbl_text_number.ForeColor = Color.Green;
                    break;
            }
        }

        private void CheckPasswordRequirements(string pw)
        {
            PasswordValid = true;
            OldPasswordValid = true;

            if (pw.Length < 8)
            {
                MakeItRed("Lenght");
                PasswordValid = false;
            } else
            {
                MakeItGreen("Lenght");
            }

            if (pw.Where(char.IsUpper).Count() <= 0)
            {
                MakeItRed("Uppercase");
                PasswordValid = false;
            } else
            {
                MakeItGreen("Uppercase");
            }

            if (pw.Where(char.IsLower).Count() <= 0)
            {
                MakeItRed("Lowercase");
                PasswordValid = false;
            } else
            {
                MakeItGreen("Lowercase");
            }

            if (pw.Where(char.IsDigit).Count() <= 0)
            {
                MakeItRed("Number");
                PasswordValid = false;
            } else
            {
                MakeItGreen("Number");
            }

            // Check that passwords match
            if(Input_Password_01.Text != Input_Password_02.Text)
            {
                label_PasswordsNoMatch.Visible = true;
                PasswordsMatch = false;
            } else
            {
                label_PasswordsNoMatch.Visible = false;
                PasswordsMatch = true;
            }

            if(input_OldPassword.Text.Length <= 0)
            {
                label_OldPassRequired.Visible = true;
                OldPasswordValid = false;
            }

            if(PasswordsMatch && PasswordValid && OldPasswordValid)
            {
                //btn_Submit.BackColor = Color.FromArgb(0, 15, 157, 88);
                btn_SubmitNewPassword.Enabled = true;
            } else
            {
                //btn_Submit.BackColor = Color.Gray;
                btn_SubmitNewPassword.Enabled = false;
            }
           
        }

        private void Password_Input_TextChanged(object sender, EventArgs e)
        {
            label_Result.Visible = false;

            if(Input_Password_01.Text.Length > 0)
            {
                CheckPasswordRequirements(Input_Password_01.Text);
                panel_PasswordChecks.Visible = true;
            } else
            {
                label_PasswordsNoMatch.Visible = false;
                panel_PasswordChecks.Visible = false;
            }
        }

        private void CreateChangePasswordPanel()
        {

        }

       
        private void time_5_tick(object sender, EventArgs e)
        {
            /*
            //panel_mainInfo.Location = new Point(panel_mainInfo.Location.X - 15, panel_mainInfo.Location.Y);
            panel_ChangePassword.Location = new Point(panel_ChangePassword.Location.X - 45, panel_ChangePassword.Location.Y);

            if (panel_ChangePassword.Location.X < 15)
            {
                timer_Animation.Enabled = false;
            }
            */
        }

        private void btn_ChangePassword_Click(object sender, EventArgs e)
        {
            DisableMainPanel();
            EnableNewPasswordPanel();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Logout_Click(object sender, EventArgs e)
        {
            ApiCommunication.Logout();
            this.Close();
        }

        private async void btn_Submit_Click(object sender, EventArgs e)
        {
            if(!PasswordsMatch || !PasswordValid || !OldPasswordValid)
            {
                return;
            }

            Task<IActionApiResponse> response = ApiCommunication.SendChangePasswordRequest(
                   input_OldPassword.Text, Input_Password_01.Text, UserSettings.UserAccessToken);

            IActionApiResponse model = await response;



            if (model.Successful)
            {
                // Save the new password if needed
                if (UserSettings.RememberLogin)
                {
                    UserSettings.UserPassword = Input_Password_01.Text;
                }

                input_OldPassword.Text = "";
                Input_Password_01.Text = "";
                Input_Password_02.Text = "";
                btn_SubmitNewPassword.Enabled = false;
                panel_PasswordChecks.Visible = false;
                label_Result.Text = "Success!";
                label_Result.Visible = true;
                label_Result.Location = new Point(120, 270);
            } else
            {

                input_OldPassword.Text = "";
                Input_Password_01.Text = "";
                Input_Password_02.Text = "";
                panel_PasswordChecks.Visible = false;
                label_Result.Text = model.Response.ReasonPhrase;
                label_Result.Visible = true;
                label_Result.Location = new Point(120, 270);
            }



        }


        private void label_PasswordsNoMatch_Click(object sender, EventArgs e)
        {

        }

        private void btn_BackFromNewPassword_Click(object sender, EventArgs e)
        {
            DisableNewPasswordPanel();
            EnableMainInfoPanel();
        }
    }
}
