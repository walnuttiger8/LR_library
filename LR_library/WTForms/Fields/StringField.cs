using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LR_library.WTForms.Validators;

namespace LR_library.WTForms
{
    public class StringField : Field
    {
        private TextBox input;

        public StringField(string label, string name)
        {
            this.label = new Label()
            {
                Text = label,
                Size = new System.Drawing.Size(80, 25),
                Font = new System.Drawing.Font("Verdana", 10.0f),
            };
            input = new TextBox()
            {
                Size = new System.Drawing.Size(260, 30),
                Font = new System.Drawing.Font("Verdana", 12.0f),
            };
            this.name = name;
        }

        public StringField(string label, string name, List<Validator> validators) : this(label, name)
        {
            this.validators = new List<Validator>();
            foreach (Validator validator in validators)
            {
                validator.field = this;
                this.validators.Add(validator);
            }
        }

        public override void Draw(int x, int y, Control groupBox)
        {
            label.Location = new System.Drawing.Point(x + 10, y + 5);
            input.Location = new System.Drawing.Point(x + 10, y + label.Size.Height + 5);
            errorLabel.Location = new System.Drawing.Point(x + 10 + label.Size.Width, y + 5);
            groupBox.Controls.Add(label);
            groupBox.Controls.Add(errorLabel);
            groupBox.Controls.Add(input);
        }

        public override object GetValue()
        {
            return input.Text;
        }

        public void setPlaceholder(string text)
        {
            input.Text = text;
        }
    }
}
