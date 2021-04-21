using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace LR_library.Controllers
{
    public static class MailController
    {
        static MailAddress from;
        static MailController()
        {
            from = new MailAddress("kzn_library@mail.ru");
        }

        public static void Send(string toAddr, string message)
        {
            MailAddress to = new MailAddress(toAddr);
            MailMessage m = new MailMessage(from, to);
            m.Subject = "Код восстановления";

            m.Body = "<h1>Код: " + message + "</h1>";
            m.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient("smtp.mail.ru", 587);
            smtp.Credentials = new NetworkCredential("kzn_library@mail.ru", "library_kzn");
            smtp.EnableSsl = true;
            smtp.Send(m);

        }
    }
}
