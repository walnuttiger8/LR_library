using LR_library.Controllers;
using LR_library.Views;
using LR_library.WTForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LR_library.Forms
{
    public class SignForm : WTForm
    {
        static StringField name = new StringField("Логин:", "login");
        static PasswordField password = new PasswordField("Пароль:  ", "password");
        static BooleanField rememberMe = new BooleanField("Запомнить меня", "rememberMe");
        static ButtonField submit = new ButtonField("Войти", "submit");
        public MainView mainView;

        public SignForm(Control groupBox)
        {
            this.groupBox = groupBox;
            submit.AddClickHandler(SignIn);
            fields = new List<Field> { name, password, rememberMe, submit };
        }

        public void SignIn(object sender, EventArgs e)
        {
            var values = GetData();
            string login = values["login"] as string;
            UserController user = UserController.FromLogin(login);


            if (user != null && user.CheckPassword(values["password"] as string))
            {
                if (user.Role == "user")
                {
                    UserView userView = new UserView();
                    mainView.Hide();
                    userView.Show();
                }
                else if (user.Role == "admin")
                {
                    AdminView adminView = new AdminView();
                    adminView.Show();
                    mainView.Hide();
                }
                return;
            }
            MessageBox.Show("пользователь не найден");
        }
    }
}
