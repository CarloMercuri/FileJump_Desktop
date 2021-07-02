using FileJump.Network;
using FileJump.Settings;
using FileJump_Network.EventSystem;
using FileJump_Network.Interfaces;
using FileJump_Network.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileJump.Forms
{
    public partial class LoginPage : Form
    {
        private string TypedPassword { get; set; }

         public LoginPage()
        {
            InitializeComponent();
            DisplayMainLoginForm();
           // label_InvalidLogin.Visible = true;

            Input_Password.TextChanged += InputTextChanged;
            Input_Email.TextChanged += InputTextChanged;

            // Events
            ApiCommunication.LoginActionResult += LoginActionResult;
            
        }

        private void LoginActionResult(object sender, LoginResultEventArgs args)
        {
            if (args.Successful)
            {
                PerformSuccessfulLogin();
            } 
            else
            {
                DisplayFailedLogin(args.Message);
            }

        }

        private void PerformSuccessfulLogin()
        {
            // If user wants to be remembered
            if (check_Rememberme.Checked)
            {
                UserSettings.RememberLogin = true;
                UserSettings.UserPassword = Input_Password.Text;
            }


            this.Close();
        }

        private void LoginUnsuccessful(object sender, LoginFailEventArgs e)
        {
            DisplayFailedLogin(e.Message);
        }

        private void InputTextChanged(object sender, EventArgs e)
        {
            // Hide it regardless
            label_InvalidLogin.Visible = false;

            if(Input_Password.Text.Length > 0 && Input_Email.Text.Length > 0)
            {
                btn_Login.Enabled = true;
            } else
            {
                btn_Login.Enabled = false;
            }
        }

        private void DisplayPasswordRecovery()
        {
            panel_MainLogin.Visible = false;
            panel_ForgotPassword.Visible = true;
            input_ForgotPW_Email.Text = "";
            panel_ForgotPassword.Location = new Point(9, 125);
            btn_BackToLogin.Visible = true;
            label_EmailRecoverySuccess.Visible = false;
            label_InvalidEmail.Visible = false;
            label_InvalidEmail.Text = "Invalid Email Address!";
            this.AcceptButton = btn_SendForgotPW;
        }

        private void DisplayMainLoginForm()
        {
            panel_ForgotPassword.Visible = false;
            btn_BackToLogin.Visible = false;

            label_InvalidLogin.Visible = false;
            btn_Login.Enabled = false;
            Input_Email.Text = "";
            Input_Password.Text = "";
            panel_MainLogin.Visible = true;
            panel_MainLogin.Location = new Point(9, 125);

            this.AcceptButton = btn_Login;


        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if(Input_Email.Text.Length > 0 && Input_Password.Text.Length > 0)
            {
                btn_Login.Enabled = false;

                ApiCommunication.SendLoginRequest(Input_Email.Text, Input_Password.Text);

              

                btn_Login.Enabled = true;
            }
        }



        private void DisplayFailedLogin(string reason)
        {
            Input_Email.Text = "";
            Input_Password.Text = "";
            label_InvalidLogin.Visible = true;
            label_InvalidLogin.Text = reason;
        }

        private void btn_ForgotPassword_Click(object sender, EventArgs e)
        {
            DisplayPasswordRecovery();
        }

        private void btn_BackToLogin_Click(object sender, EventArgs e)
        {
            DisplayMainLoginForm();
        }

        private async void btn_SendForgotPW_Click(object sender, EventArgs e)
        {
            Task<IActionApiResponse> response = ApiCommunication.SendPasswordRecoveryRequest(input_ForgotPW_Email.Text);

            IActionApiResponse model = await response;

            if (model.Successful)
            {
                label_EmailRecoverySuccess.Visible = true;
            } else
            {
                label_InvalidEmail.Visible = true;
                label_InvalidEmail.Text = model.Response.ReasonPhrase;
            }
        }

        private void input_ForgotPW_EmailChanged(object sender, EventArgs e)
        {
            btn_SendForgotPW.Enabled = false;

            if(input_ForgotPW_Email.Text.Length <= 0)
            {
                label_InvalidEmail.Visible = false;
                label_EmailRecoverySuccess.Visible = false;
                return;
            }

            if (!input_ForgotPW_Email.Text.Contains("@"))
            {
                label_InvalidEmail.Visible = true;
                return;
            }

            label_InvalidEmail.Visible = false;
            btn_SendForgotPW.Enabled = true;
        }

        private void btn_CloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
