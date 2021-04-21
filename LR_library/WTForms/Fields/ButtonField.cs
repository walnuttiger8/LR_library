using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR_library.WTForms
{
    public class ButtonField : Field
    {
        private Button input = new Button();

        public ButtonField(string label, string name)
        {
            input = new Button()
            {
                Text = label,
                Size = new System.Drawing.Size(label.Length * 10, 35),
                Font = new System.Drawing.Font("Verdana", 11.0f),
                MinimumSize = new System.Drawing.Size(120, 35)
            };
            this.label = new Label()
            {
                Text = label,
            };
            this.name = name;
        }

        public ButtonField(string label, string name, EventHandler handler) : this(label, name)
        {
            input.Click += handler;
        }

        public void AddClickHandler(EventHandler handler)
        {
            input.Click += handler;
        }

        public override void Draw(int x, int y, Control groupBox)
        {
            input.Location = new System.Drawing.Point(x + 5, y);
            groupBox.Controls.Add(input);
        }

        public override object GetValue()
        {
            return true;
        }
    }
}
