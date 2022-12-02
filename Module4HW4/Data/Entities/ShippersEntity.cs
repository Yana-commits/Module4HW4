using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4HW4.Data.Entities
{
    internal class ShippersEntity
    {
        public string ShipperId { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public List<OrdersEntity> Orders { get; set; } = new List<OrdersEntity>();
    }
}
