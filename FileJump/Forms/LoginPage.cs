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
            Input_Password.Text = "";
        }

    }
}
