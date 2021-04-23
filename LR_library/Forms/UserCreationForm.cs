using LR_library.Controllers;
using LR_library.WTForms;
using LR_library.WTForms.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR_library.Forms
{
    class UserCreationForm : WTForm
    {
        StringField name = new StringField("Имя", "name",
            new List<Validator> { new DataRequired() });
        StringField login = new StringField("Логин", "login",
            new List<Validator> { new DataRequired() });
        StringField email = new StringField("Почта", "email",
            new List<Validator> { new DataRequired(), new Email() });
        PasswordField password = new PasswordField("Пароль:  ", "password",
            new List<Validator> { new DataRequired() });
        StringField role = new StringField("Роль:", "role",
            new List<Validator>() { new DataRequired() });
        ButtonField submit = new ButtonField("подтвердить", "submit");

        public UserCreationForm()
        {
            fields = new List<Field>() { name, login, email, password, role, submit };
            submit.AddClickHandler(Create);
        }

        public void Create(object sender, EventArgs e)
        {
            if (isValid())
            {
                try
                {
                    var data = GetData();
                    string name = data["name"] as string;
                    string login = data["login"] as string;
                    string email = data["email"] as string;
                    string password = data["password"] as string;
                    string role = data["role"] as string;

                    using (UserContainer db = new UserContainer())
                    {
                        User user = new User() { Name=name, Login=login, Email=email};
                        var controller = new UserController(user);
                        controller.SetPassword(password);
                        user.Role = role;
                        db.UserSet.Add(user);
                        db.SaveChanges();
                    }
                    parentForm.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Не удалось выполнить операцию");
                }
            }
        }
    }
}
