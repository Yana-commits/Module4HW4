using Module4HW4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4HW4.Data.Entities
{
    internal class PaymentEntity
    {
        public string PaymentId { get; set; }
        public PaymentType PaymentType { get; set; }
        public bool Allowed { get; set; }
        public OrdersEntity Order { get; set; }
    }
}
