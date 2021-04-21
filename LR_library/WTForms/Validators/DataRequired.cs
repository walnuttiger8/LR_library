using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_library.WTForms.Validators
{
    public class DataRequired : Validator
    {
        public override bool isValid()
        {
            object value = field.GetValue();
            if (value is string)
            {
                return (value as string).Length != 0;
            }
            return true;
        }

        public override string Vaildate()
        {
            return "Требуется значение";
        }
    }
}
