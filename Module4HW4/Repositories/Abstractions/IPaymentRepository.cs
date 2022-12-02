using Module4HW4.Data.Entities;
using Module4HW4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4HW4.Repositories.Abstractions
{
    internal interface IPaymentRepository
    {
        Task<string> AddPaymentAsync(PaymentType paymentType, bool allowed);
        Task<PaymentEntity?> GetPaymentAsync(string id);
    }
}
