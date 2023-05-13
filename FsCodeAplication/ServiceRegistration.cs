using FsCodeAplication.Content;
using FsCodeAplication.Repositories.Abstractions;
using FsCodeAplication.Repositories.Abstractions.Entities;
using FsCodeAplication.Repositories.Implementations;
using FsCodeAplication.Repositories.Implementations.Entities;
using FsCodeAplication.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FsCodeAplication
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddDbContext<FsCodeDbContent>(options => options.UseSqlServer(Configuration.ConnectionString));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IReminderRepository, ReminderRepository>();
        }
    }
}
