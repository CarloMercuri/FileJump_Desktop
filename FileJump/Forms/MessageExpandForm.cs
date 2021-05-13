using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileJump
{
    public partial class MessageExpandForm : Form
    {
        public MessageExpandForm(string text)
        {
            InitializeComponent();
            mainTextBox.Text = text;
        }
    }
}
