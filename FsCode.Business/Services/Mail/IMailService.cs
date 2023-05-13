namespace FsCodeBusiness.Services.Mail
{
    public interface IMailService
    {
        Task SendMail(string to, string content);
    }
}
