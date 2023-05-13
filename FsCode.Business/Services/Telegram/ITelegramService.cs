using FsCodeBusiness.Results;

namespace FsCodeBusiness.Services.Telegram
{
    public interface ITelegramService
    {
        Task SendMesssage(string to, string content);
    }
}
