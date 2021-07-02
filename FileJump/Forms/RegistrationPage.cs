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
using FileJump_Network.EventSystem;
using FileJump_Network.Interfaces;
using FileJump_Network.Models;

namespace FileJump.Forms
{
    public partial class RegistrationPage : Form
    {
        private bool EmailValid { get; set; } = false;

        private bool Password01Valid { get; set; } = false; // Valid if it meets the lenght and content requirements
        private bool Password02Valid { get; set; } = false; // Valid if it matches password 01
        public RegistrationPage()
        {
            InitializeComponent();
            Input_Password_01.TextChanged += Password_Input_TextChanged;
            Input_Password_02.TextChanged += Password_Input_TextChanged;
            Input_Email.TextChanged += EmailTextChanged;

            label_PasswordsNoMatch.Visible = false;
            label_PasswordInvalid.Visible = false;
            label_PasswordInvalid.TabStop = true;
            label_EmailInvalid.Visible = false;
            label_Response.Visible = false;
            btn_Login.Enabled = false;
            panel_Success.Visible = false;

            this.AcceptButton = btn_Login;

            ApiCommunication.RegistrationActionResult += RegistrationResult;

        }



        private void EmailTextChanged(object sender, EventArgs e)
        {
            if (Input_Email.Text.Where(x => x.Equals('@')).Count() == 1)
            {
                EmailValid = true;
            }
            else
            {
                EmailValid = false;
            }

            UpdateValidity();
        }

        private void Password_Input_TextChanged(object sender, EventArgs e)
        {
            Password01Valid = PasswordMeetsRequirements(Input_Password_01.Text);
            
            if(Input_Password_01.Text.Length > 0 && Input_Password_01.Text == Input_Password_02.Text)
            {
                Password02Valid = true;
            }
            else
            {
                Password02Valid = false;
            }

            UpdateValidity();
        }

        private void UpdateValidity()
        {
            if(Input_Password_02.Text.Length > 0)
            {
                if(Password02Valid == false)
                {
                    label_PasswordsNoMatch.Visible = true;
                } else
                {
                    label_PasswordsNoMatch.Visible = false;
                }
            }

            if (Input_Password_01.Text.Length > 0 && !Password01Valid)
            {
                label_PasswordInvalid.Visible = true;
            }
            else
            {
                label_PasswordInvalid.Visible = false;
            }

            // EMAIL

            if(Input_Email.Text.Length > 0)
            {
                if (EmailValid)
                {
                    label_EmailInvalid.Visible = false;
                }
                else
                {
                    label_EmailInvalid.Text = "Invalid Email!";
                    label_EmailInvalid.Visible = true;
                }
            } else
            {
                label_EmailInvalid.Visible = false;
            }

            if (EmailValid || Password01Valid || Password02Valid)
            {
                btn_Login.Enabled = true;
            } else
            {
                btn_Login.Enabled = false;
            }


        }

        private bool PasswordMeetsRequirements(string pw)
        {
            if (pw.Length < 8) return false;

            if (pw.Where(char.IsUpper).Count() <= 0) return false;
            
            if (pw.Where(char.IsLower).Count() <= 0) return false;
            
            if (pw.Where(char.IsDigit).Count() <= 0) return false;

            return true;
        }

        private void ShowSuccessPanel()
        {
            this.AcceptButton = btn_CloseForm;
            panel_main.Visible = false;
            panel_Success.Visible = true;
            panel_Success.Location = panel_main.Location;
        }


        private void SendRegistrationData()
        {
            if (!EmailValid || !Password01Valid || !Password02Valid)
            {
                return;
            }

            // Send the post. Will come back as an event
            ApiCommunication.SendNewAccountRegistrationData(
                Input_Email.Text, Input_Password_01.Text, Input_FirstName.Text, Input_LastName.Text);
        }

        private void RegistrationResult(object sender, RegistrationResultEventArgs args)
        {
            if (args.Successful)
            {
                ShowSuccessPanel();
            }
            else
            {
                label_Response.Visible = true;
                label_Response.Text = args.Message;
            }
        }

        private void ResetFields()
        {
            Input_Email.Text = "";
            Input_FirstName.Text = "";
            Input_LastName.Text = "";
            Input_Password_01.Text = "";
            Input_Password_02.Text = "";
            label_PasswordsNoMatch.Visible = false;
            label_PasswordInvalid.Visible = false;
            label_EmailInvalid.Visible = false;
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            SendRegistrationData();
            ResetFields();

        }

        private void btn_CloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
