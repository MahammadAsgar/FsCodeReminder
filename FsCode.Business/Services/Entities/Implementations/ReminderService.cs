using AutoMapper;
using FsCodeAplication.Repositories.Abstractions.Entities;
using FsCodeAplication.UnitOfWorks;
using FsCodeBusiness.Dtos.Get;
using FsCodeBusiness.Dtos.Post;
using FsCodeBusiness.Dtos.Put;
using FsCodeBusiness.Results;
using FsCodeBusiness.Services.Entities.Abstractions;
using FsCodeDomain.Entities;

namespace FsCodeBusiness.Services.Entities.Implementations
{
    public class ReminderService : IReminderService
    {
        readonly IMapper _mapper;
        readonly IUnitOfWork _unitOfWork;
        readonly IReminderRepository _reminderRepository;
        public ReminderService(IMapper mapper, IUnitOfWork unitOfWork, IReminderRepository reminderRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _reminderRepository = reminderRepository;
        }
        public async Task<ServiceResult> AddReminder(ReminderPost reminderPost)
        {
            var reminder = _mapper.Map<Reminder>(reminderPost);
            reminder.IsActive = true;
            await _unitOfWork.Repository<Reminder>().AddAsync(reminder);
            _unitOfWork.Commit();
            return new ServiceResult(true);
        }

        public async Task<ServiceResult> DeleteReminder(int id)
        {
            var reminder = await _reminderRepository.GetReminder(id);
            if (reminder != null)
            {
                _unitOfWork.Repository<Reminder>().Delete(reminder);
                _unitOfWork.Commit();
                return new ServiceResult(true);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> GetReminder(int id)
        {
            var reminder = await _reminderRepository.GetReminder(id);
            if (reminder != null)
            {
                var response = _mapper.Map<ReminderGet>(reminder);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> GetReminders()
        {
            var reminders = await _reminderRepository.GetAllReminders();
            if (reminders != null)
            {
                var response = _mapper.Map<IEnumerable<ReminderGet>>(reminders);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> GetActiveReminders()
        {
            var reminders = await _reminderRepository.GetActiveReminders();
            if (reminders != null)
            {
                var response = _mapper.Map<IEnumerable<ReminderGet>>(reminders);
                return new ServiceResult(true, response);
            }
            return new ServiceResult(false);
        }

        public async Task<ServiceResult> UpdateReminder(int id, ReminderPut reminderPut)
        {
            var reminder = await _reminderRepository.GetReminder(id);
            if (reminder != null)
            {
                if (!string.IsNullOrEmpty(reminderPut.To))
                {
                    reminder.To = reminderPut.To;
                }

                if (!string.IsNullOrEmpty(reminderPut.Content))
                {
                    reminder.Content = reminderPut.Content;
                }

                if (!string.IsNullOrEmpty(reminderPut.Method))
                {
                    reminder.Method = reminderPut.Method;
                }

                if (reminderPut.SendAt != null)
                {
                    reminder.SendAt = reminderPut.SendAt.Value;
                }
                _unitOfWork.Repository<Reminder>().Update(reminder);
                _unitOfWork.Commit();
                return new ServiceResult(true);
            }
            return new ServiceResult(false);
        }
    }
}
