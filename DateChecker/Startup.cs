using FsCodeAplication.Content;
using FsCodeAplication.Repositories.Abstractions.Entities;
using FsCodeAplication.Repositories.Implementations.Entities;
using FsCodeAplication.UnitOfWorks;
using FsCodeBusiness;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
[assembly: FunctionsStartup(typeof(DateChecker.Startup))]

namespace DateChecker
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddDbContext<FsCodeDbContent>(options => options.UseSqlServer("Data Source=DESKTOP-9DHLH99;Initial Catalog=ReminderDb;Integrated Security=True"));
            builder.Services.AddScoped<IReminderRepository, ReminderRepository>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            //builder.Services.AddScoped<IMailService, MailService>();
            //builder.Services.AddApplicationServices();
            builder.Services.AddBusinessServices();
        }
    }
}
