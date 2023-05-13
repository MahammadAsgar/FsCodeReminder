using Dapper;
using FsCodeAplication.Repositories.Abstractions.Entities;
using FsCodeAplication.UnitOfWorks;
using FsCodeBusiness.Services.Mail;
using FsCodeDomain.Entities;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
[assembly: FunctionsStartup(typeof(DateChecker.DateCheck))]

namespace DateChecker
{
    public class DateCheck
    {
        readonly IMailService _mailService;
        readonly IReminderRepository _reminderRepository;
        readonly IUnitOfWork _unitOfWork;
        public DateCheck(IMailService mailService, IReminderRepository reminderRepository, IUnitOfWork unitOfWork)
        {
            _mailService = mailService;
            _reminderRepository = reminderRepository;
            _unitOfWork = unitOfWork;
        }

        [FunctionName(nameof(StartAz))]
        public async Task StartAz([TimerTrigger("0 0 9 * * *", RunOnStartup = true, UseMonitor = true)]
         TimerInfo info, [DurableClient] IDurableOrchestrationClient context)
        {
            var reminders = new List<Reminder>();
            var query = $"SELECT *FROM Reminders Where IsActive={1}";
            using (var connection = new SqlConnection("Data Source=DESKTOP-9DHLH99;Initial Catalog=ReminderDb;Integrated Security=True"))
            {
                connection.Open();
                reminders = connection.Query<Reminder>(query).ToList();
            }
            //var reminders = await _reminderRepository.GetActiveReminders();//Doesn't work
            foreach (var item in reminders)
            {
                if ((DateTime.Now - item.SendAt).Days == 0)
                {
                    item.IsActive = false;
                    _unitOfWork.Repository<Reminder>().Update(item);
                    _unitOfWork.Commit();
                    if (item.Method == "email")
                    {
                        await _mailService.SendMail(item.To, item.Content);
                    }
                    else if (item.Method == "telegram")
                    {
                        //telegram
                    }
                }
            }
        }

    }
}