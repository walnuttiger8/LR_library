using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LR_library.WTForms;
using LR_library.WTForms.Validators;

namespace LR_library.Views
{
    public partial class StandaloneView : Form
    {
        public WTForm form;
        public Form parentForm;

        public StandaloneView()
        {
            InitializeComponent();
        }

        public StandaloneView(Form parentForm, WTForm form) : this()
        {
            form.groupBox = groupBoxForm;
            this.parentForm = parentForm;
            form.parentForm = this;
            this.form = form;
        }

        private void StandaloneView_Load(object sender, EventArgs e)
        {
            parentForm.Enabled = false;
            form.Draw();
        }

        private void StandaloneView_FormClosed(object sender, FormClosedEventArgs e)
        {
            parentForm.Enabled = true;
        }
    }
}
