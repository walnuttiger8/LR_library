using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace LR_library.WTForms.Validators
{
    public class Email : Validator
    {
        public override bool isValid()
        {
            string emailAddress = field.GetValue() as string;
            try
            {
                MailAddress m = new MailAddress(emailAddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public override string Vaildate()
        {
            return "Введите корректную почту";
        }
    }
}
