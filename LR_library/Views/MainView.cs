using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LR_library.Views;
using LR_library.Forms;

namespace LR_library
{
    public partial class MainView : Form
    {
        RegisterForm registerForm;
        SignForm signForm;
        
        public MainView()
        {
            InitializeComponent();
            registerForm = new RegisterForm(tabPageRegister);
            signForm = new SignForm(tabPageSign);
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            
            registerForm.Draw();
            signForm.Draw();
        }

        private void linkLabelResetPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ResetPasswordForm resetPasswordForm = new ResetPasswordForm();
            StandaloneView standaloneView = new StandaloneView(this, resetPasswordForm);
            standaloneView.Show();
        }
    }
}
