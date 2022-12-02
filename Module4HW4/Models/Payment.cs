using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4HW4.Models
{
    internal class Payment
    {
        public string PaymentId { get; set; }
        public PaymentType PaymentType { get; set; }
        public bool Allowed { get; set; }
    }
}
