using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR_library.WTForms
{
    public abstract class Field
    {
        public Label label;
        public string name;
        public Label errorLabel = new Label()
        {
            Text = "",
            Size = new System.Drawing.Size(220, 20),
            Font = new System.Drawing.Font("Verdana", 8.0f),
            ForeColor = System.Drawing.Color.Red,
        };
        public List<Validators.Validator> validators;

        public abstract void Draw(int x, int y, Control groupBox);
        public abstract object GetValue();

        public bool isValid()
        {
            errorLabel.Text = "";
            if (validators == null)
            {
                return true;
            }
            foreach (var validator in validators)
            {
                if (!validator.isValid())
                {
                    errorLabel.Text += validator.Vaildate();
                    return false;
                }
            }
            return true;
        }
    }
}
