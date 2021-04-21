using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LR_library.WTForms;
using LR_library.WTForms.Validators;
using LR_library.Controllers;
using System.Windows.Forms;
using LR_library.Views;

namespace LR_library.Forms
{
    class ResetPasswordForm : WTForm
    {
        public StringField email = new StringField("Почта", "email",
            new List<Validator> { new Email() });
        public StringField code = new StringField("Код", "code");
        public ButtonField sendButton = new ButtonField("Отправить код", "sendButton");
        public ButtonField submit = new ButtonField("Подтвердить", "submit");
        private UserController user;

        public ResetPasswordForm()
        {
            sendButton.AddClickHandler(SendEmail);
            submit.AddClickHandler(ResetPassword);
            fields = new List<Field> { email, code, sendButton, submit };
            user = null;
        }

        public void SendEmail(object sender, EventArgs e)
        {
            string userEmail = email.GetValue() as string;

            UserController user = UserController.FromEmail(userEmail);

            if (user == null)
            {
                MessageBox.Show("Пользователь не найден");
                return;
            }

            UserCode userCode = user.SetUserCode();
            MailController.Send(userEmail, userCode.Code);

        }

        public void ResetPassword(object sender, EventArgs e)
        {
            string value = email.GetValue() as string;

            user = UserController.FromEmail(value);

            if (user == null)
            {
                MessageBox.Show("Пользователь не найден");
                return;
            }

            value = code.GetValue() as string;
            if (!user.CheckUserCode(value))
            {
                MessageBox.Show("Неверный код");
                return;
            }


            ChangePasswordForm changePasswordForm = new ChangePasswordForm(user);
            StandaloneView standaloneView = new StandaloneView(parentForm, changePasswordForm);
            parentForm.Close();
            standaloneView.Show();

        }
    }
}
