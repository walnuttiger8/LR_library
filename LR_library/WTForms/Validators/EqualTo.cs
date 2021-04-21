using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_library.WTForms.Validators
{
    public class EqualTo: Validator
    {
        public Field compareField;
        public EqualTo(Field field)
        {
            compareField = field;
        }

        public override bool isValid()
        {
            return (compareField.GetValue() as string) == (field.GetValue() as string);
        }

        public override string Vaildate()
        {
            return $"Должно совпадать с {compareField.label.Text}";
        }
    }
}
