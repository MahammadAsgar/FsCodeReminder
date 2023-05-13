using FsCodeBusiness.Results;

namespace FsCodeBusiness.Services.Telegram
{
    public interface ITelegramService
    {
        Task<ServiceResult> SendMesssage(string to, string content);
    }
}
