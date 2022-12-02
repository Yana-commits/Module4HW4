using Module4HW4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4HW4.Services.Abstractions
{
    internal interface IPaymentService
    {
        Task<string> AddPaymentAsync(PaymentType paymentType, bool allowed);
        Task<Payment> GetPaymentAsync(string id);
    }
}
