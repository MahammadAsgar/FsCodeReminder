﻿using FsCodeBusiness.Dtos.Post;
using FsCodeBusiness.Dtos.Put;
using FsCodeBusiness.Results;
using FsCodeBusiness.Services.Entities.Abstractions;
using FsCodeBusiness.Services.Mail;
using FsCodeBusiness.Services.Telegram;
using Microsoft.AspNetCore.Mvc;

namespace FsCodeApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RemindersController : ControllerBase
    {
        readonly IReminderService _reminderService;
        readonly ITelegramService _telegramService;
        readonly IMailService _mailService;
        public RemindersController(IReminderService reminderService, ITelegramService telegramService, IMailService mailService)
        {
            _reminderService = reminderService;
            _telegramService = telegramService;
            _mailService = mailService;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResult>> AddReminder([FromForm] ReminderPost reminderPost)
        {
            var response = await _reminderService.AddReminder(reminderPost);
            return Ok(response);
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResult>> EditReminder(int id, ReminderPut reminderPut)
        {
            var response = await _reminderService.UpdateReminder(id, reminderPut);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResult>> DeleteReminder(int id)
        {
            var response = await _reminderService.DeleteReminder(id);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResult>> GetReminder(int id)
        {
            var response = await _reminderService.GetReminder(id);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResult>> GetReminders()
        {
            var response = await _reminderService.GetReminders();
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResult>> GetActiveReminders()
        {
            var response = await _reminderService.GetActiveReminders();
            return Ok(response);
        }
    }
}
