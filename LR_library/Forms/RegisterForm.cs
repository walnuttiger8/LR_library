using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LR_library.WTForms;
using LR_library.WTForms.Validators;
using System.Windows.Forms;
using LR_library.Controllers;

namespace LR_library.Forms
{
    public class RegisterForm : WTForm
    {
        static StringField name = new StringField("Имя", "name",
            new List<Validator> { new DataRequired() });
        static StringField login = new StringField("Логин", "login",
            new List<Validator> { new DataRequired() });
        static StringField email = new StringField("Почта", "email",
            new List<Validator> { new DataRequired(), new Email() });
        static PasswordField password = new PasswordField("Пароль: ", "password",
            new List<Validator> { new DataRequired() });
        static PasswordField passwordRepeat = new PasswordField("Повторите пароль:", "passwordRepeat",
            new List<Validator> { new DataRequired(), new EqualTo(password) });
        static BooleanField rememberMe = new BooleanField("Запомнить меня", "rememberMe");
        static ButtonField submit = new ButtonField("Зарегестрироваться", "submit");

        public RegisterForm(Control groupBox)
        {
            this.groupBox = groupBox;
            submit.AddClickHandler(new EventHandler(Register));
            fields = new List<Field> { name, login, email, password, passwordRepeat, rememberMe, submit };
        }

        public void Register(object sender, EventArgs e)
        {
            if (isValid())
            {
                var data = GetData();
                string name = data["name"] as string;
                string login = data["login"] as string;
                string email = data["email"] as string;
                string password = data["password"] as string;

                using (UserContainer db = new UserContainer())
                {
                    User user = new User() { Login = login, Email = email, Name = name};
                    UserController u = new UserController(user);
                    u.SetPassword(password);

                    db.UserSet.Add(user);
                    db.SaveChanges();
                }
                MessageBox.Show("registered");
            }
        }
    }
}
