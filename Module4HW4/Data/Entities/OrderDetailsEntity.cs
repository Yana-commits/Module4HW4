using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4HW4.Data.Entities
{
    internal class OrderDetailsEntity
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public ProductsEntity Product { get; set; }
        public int OrderNumber { get; set; }
        public OrdersEntity Order { get; set; }
        public int Price { get; set; }
        public DateTime ShipDate { get; set; }
    }
}
