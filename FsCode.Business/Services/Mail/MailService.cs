using FsCodeBusiness.Services.Mail;
using System.Net;
using System.Net.Mail;

namespace FsCodeBusiness.Services.Email
{
    public class MailService : IMailService
    {
        public MailService()
        {

        }

        public async Task SendMail(string to, string content)
        {
            MailMessage mail = new MailMessage();

            mail.Subject = "Reminder";
            mail.Body = content;
            mail.From = new MailAddress("mahammadasgarli59@gmail.com", "Mahammad Asgarli", System.Text.Encoding.UTF8);
            mail.To.Add(to);
            SmtpClient smtp = new();
            smtp.Credentials = new NetworkCredential("mahammadasgarli59@gmail.com", "Qeyrimueyyendunya");
            smtp.Port = 587;
            smtp.Host = "smtp.office365.com";
            smtp.EnableSsl = true;
            await smtp.SendMailAsync(mail);
        }
    }
}
