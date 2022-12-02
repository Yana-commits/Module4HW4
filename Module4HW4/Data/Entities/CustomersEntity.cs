using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4HW4.Data.Entities
{
    internal class CustomersEntity
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Class { get; set; }
        public string Address { get; set; }

        public List<OrdersEntity> Orders = new List<OrdersEntity>();
    }
}
