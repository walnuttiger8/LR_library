using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR_library.WTForms
{
    public class BooleanField : Field
    {
        private CheckBox input;

        public BooleanField(string label, string name)
        {
            this.label = new Label()
            {
                Text = label,
                Size = new System.Drawing.Size(240, 25),
                Font = new System.Drawing.Font("Verdana", 9.0f),
            };
            input = new CheckBox()
            {
                Size = new System.Drawing.Size(20, 20),
                
            };
            this.name = name;
        }

        public override void Draw(int x, int y, Control groupBox)
        {
            label.Location = new System.Drawing.Point(x + 10 + 25, y + 5);
            input.Location = new System.Drawing.Point(x + 10, y);
            groupBox.Controls.Add(label);
            groupBox.Controls.Add(input);
        }

        public override object GetValue()
        {
            return input.Checked;
        }
    }
}
