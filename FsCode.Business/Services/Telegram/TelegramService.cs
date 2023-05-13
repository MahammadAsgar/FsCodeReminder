using FsCodeBusiness.Results;
using System.Net;
using Telegram.Bot;

namespace FsCodeBusiness.Services.Telegram
{
    public class TelegramService : ITelegramService
    {
        readonly TelegramBotClient _telegramBotClient;
        public TelegramService()
        {
            _telegramBotClient = new TelegramBotClient("5930057337:AAE6rHnNLZMwWt3sV9DnZRsTIXVaVV7iyXs");
        }

        public async Task SendMesssage(string to, string content)
        {
            var token = "5930057337:AAE6rHnNLZMwWt3sV9DnZRsTIXVaVV7iyXs";
            string url = $"https://api.telegram.org/bot{token}/sendMessage?chat_id=@mahammad_asgarli&text={content}";
            Uri uri = new Uri(url);
            WebClient webClient = new WebClient();
            var body = webClient.DownloadString(uri);
        }
    }
}


/*
 public string TelegramSendMessage(string apilToken, string destID, string text)
{
   string urlString = $"https://api.telegram.org/bot{apilToken}/sendMessage?chat_id={destID}&text={text}";

   WebClient webclient = new WebClient();

   return webclient.DownloadString(urlString);
 */