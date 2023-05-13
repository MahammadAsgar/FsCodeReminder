using FsCodeDomain.Entities;

namespace FsCodeAplication.Repositories.Abstractions.Entities
{
    public interface IReminderRepository
    {
        Task<Reminder> GetReminder(int id);
        Task<IEnumerable<Reminder>> GetAllReminders();
        Task<IEnumerable<Reminder>> GetActiveReminders();
    }
}
