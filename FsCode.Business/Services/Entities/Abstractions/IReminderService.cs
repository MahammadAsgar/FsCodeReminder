using FsCodeBusiness.Dtos.Post;
using FsCodeBusiness.Dtos.Put;
using FsCodeBusiness.Results;

namespace FsCodeBusiness.Services.Entities.Abstractions
{
    public interface IReminderService
    {
        Task<ServiceResult> AddReminder(ReminderPost reminderPost);
        Task<ServiceResult> GetReminder(int id);
        Task<ServiceResult> GetReminders();
        Task<ServiceResult> GetActiveReminders();
        Task<ServiceResult> UpdateReminder(int id, ReminderPut reminderPut);
        Task<ServiceResult> DeleteReminder(int id);
    }
}
