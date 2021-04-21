using LR_library.Controllers;
using LR_library.WTForms;
using LR_library.WTForms.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_library.Forms
{
    class ChangePasswordForm : WTForm
    {
        static PasswordField password = new PasswordField("Пароль:  ", "password",
            new List<Validator>() { new DataRequired() });
        static PasswordField passwordRepeat = new PasswordField("Повторите пароль", "passwordRepeat",
            new List<Validator>() { new EqualTo(password) });
        static ButtonField submit = new ButtonField("Подтвердить", "submit");
        UserController user;

        public ChangePasswordForm(UserController user)
        {
            fields = new List<Field>() { password, passwordRepeat, submit };
            submit.AddClickHandler(new EventHandler(ChangePassword));
            this.user = user;
        }

        public void ChangePassword(object sender, EventArgs e)
        {
            if (isValid())
            {
                string value = password.GetValue() as string;
                user.SetPassword(value);
                using (UserContainer db = new UserContainer())
                {
                    db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                parentForm.Close();
            }
        }
    }
}
