using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4HW4.Models
{
    internal class Orders
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int OrderNumber { get; set; }
        public int PaymentId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShipDate { get; set; }
        public int ShipperId { get; set; }
        public bool Deleted { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
