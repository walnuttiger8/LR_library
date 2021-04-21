using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_library.WTForms.Validators
{
    public abstract class Validator
    {
        public Field field;
        public abstract bool isValid();

        public abstract string Vaildate();
    }
}
