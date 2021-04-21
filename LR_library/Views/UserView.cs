using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR_library.Views
{
    public partial class UserView : Form
    {
        public UserView()
        {
            InitializeComponent();
        }

        private void UserView_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();         
        }
    }
}
