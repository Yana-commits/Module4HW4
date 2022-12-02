using Microsoft.Extensions.Logging;
using Module4HW4.Models;
using Module4HW4.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4HW4.Services
{
    internal class NotificationService : INotificationService
    {
        private readonly ILogger<NotificationService> _loggerService;
        public NotificationService(ILogger<NotificationService> loggerService)
        {
            _loggerService = loggerService;
        }

        public void Notify(NotifyType type, string massage, string to)
        {
            _loggerService.LogInformation($"Notitication was sent for type {type}");
        }
    }
}
