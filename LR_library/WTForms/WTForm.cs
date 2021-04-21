using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR_library.WTForms
{
    public abstract class WTForm
    {
        public Control groupBox;
        public List<Field> fields;
        public Form parentForm;

        public void Draw()
        {
            int y = 10;
            foreach(Field field in fields)
            {
                field.Draw(0, y, groupBox);
                y += 60;
            }
        }

        public Dictionary<string, object> GetData()
        {
            Dictionary<string, object> result = new Dictionary<string, object>();

            foreach (Field field in fields)
            {
              
                result[field.name] = field.GetValue();
            }
            return result;
        }

        public bool isValid()
        {
            bool valid = true;
            foreach (Field field in fields)
            {
                if (!field.isValid())
                {
                    valid = false;
                }
            }
            return valid;
        }
    }
}
