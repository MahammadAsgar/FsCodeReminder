using FsCodeBusiness.Mapping;
using FsCodeBusiness.Services.Email;
using FsCodeBusiness.Services.Entities.Abstractions;
using FsCodeBusiness.Services.Entities.Implementations;
using FsCodeBusiness.Services.Mail;
using FsCodeBusiness.Services.Telegram;
using Microsoft.Extensions.DependencyInjection;

namespace FsCodeBusiness
{

    public static class ServiceRegistration
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IReminderService,ReminderService>();
            services.AddScoped<ITelegramService, TelegramService>();
            services.AddScoped<IMailService, MailService>();

            services.AddAutoMapper(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<MapProfile>();
            });
        }
    }
}
