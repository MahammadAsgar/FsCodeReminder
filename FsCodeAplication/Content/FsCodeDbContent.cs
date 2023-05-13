using FsCodeDomain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FsCodeAplication.Content
{
    public class FsCodeDbContent : DbContext
    {
        public FsCodeDbContent(DbContextOptions<FsCodeDbContent> options) : base(options)
        {

        }
        public DbSet<Reminder> Reminders { get; set; }
    }
}
