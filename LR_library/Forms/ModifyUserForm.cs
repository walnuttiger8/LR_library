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
    public class ModifyUserForm : WTForm
    {
        // login, name, password, role
        StringField login = new StringField("Логин:", "login",
            new List<Validator>() { new DataRequired() });
        StringField name = new StringField("Имя:", "name",
            new List<Validator>() { new DataRequired() });
        StringField role = new StringField("Роль:", "role",
            new List<Validator>() { new DataRequired() });
        PasswordField password = new PasswordField("Пароль:  ", "password");
        ButtonField submit = new ButtonField("Подтвердить", "submit");
        UserController user;

        public ModifyUserForm(UserController user)
        {
            fields = new List<Field>() { login, name, password, role, submit };

            login.setPlaceholder(user.Login);
            name.setPlaceholder(user.Name);
            role.setPlaceholder(user.Role);

            submit.AddClickHandler(Modify);
            this.user = user;

        }

        public void Modify(object sender, EventArgs e)
        {
            if (isValid())
            {
                try
                {
                    var data = GetData();
                    string password = data["password"] as string;
                    string login = data["login"] as string;
                    string name = data["name"] as string;
                    string role = data["role"] as string;

                    if (password != "")
                    {
                        user.SetPassword(password);
                    }

                    user.Login = login;
                    user.Name = name;
                    user.Role = role;

                    user.Modify();
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
