using Microsoft.Extensions.Logging;
using Module4HW4.Data;
using Module4HW4.Models;
using Module4HW4.Repositories;
using Module4HW4.Repositories.Abstractions;
using Module4HW4.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4HW4.Services
{
    internal class PaymentService : BaseDataService<ApplicationDbContext> , IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly ILogger<PaymentService> _loggerService;
        protected PaymentService(IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<IBaseDataService> logger, IPaymentRepository paymentRepository,
        ILogger<PaymentService> loggerService ) : base(dbContextWrapper, logger)
        {
           _paymentRepository = paymentRepository;
            _loggerService = loggerService;
        }

        public async Task<string> AddPaymentAsync(PaymentType paymentType, bool allowed)
        {
            var id = await _paymentRepository.AddPaymentAsync(paymentType,allowed);
            _loggerService.LogInformation($"Created product with Id= {id}");

            return id.ToString();
        }
        public async Task<Payment> GetPaymentAsync(string id)
        {
            var result = await _paymentRepository.GetPaymentAsync(id);

            if (result == null)
            {
                _loggerService.LogWarning($"Not founded payment with Id = {id}");
                return null!;
            }

            return new Payment()
            {
                PaymentId = result.PaymentId,
                PaymentType = result.PaymentType,
                Allowed = result.Allowed
            };
        }
    }
}
