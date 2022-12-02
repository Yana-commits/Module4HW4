using Microsoft.EntityFrameworkCore;
using Module4HW4.Data;
using Module4HW4.Data.Entities;
using Module4HW4.Models;
using Module4HW4.Repositories.Abstractions;
using Module4HW4.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4HW4.Repositories
{
    internal class PaymentRepository : IPaymentRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PaymentRepository(IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
        {
            _dbContext = dbContextWrapper.DbContext;
        }
        public async Task<string> AddPaymentAsync(PaymentType paymentType, bool allowed)
        {
            var payment = new PaymentEntity()
            {
                PaymentId = Guid.NewGuid().ToString(),
                PaymentType = paymentType,
                Allowed = allowed
             
            };

            await _dbContext.Payments.AddAsync(payment);
            await _dbContext.SaveChangesAsync();

            return payment.PaymentId;
        }
        public async Task<PaymentEntity?> GetPaymentAsync(string id)
        {
            return await _dbContext.Payments.FirstOrDefaultAsync(d => d.PaymentId == id);
        }
    }
}
