using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4HW4.Models
{
    internal class OrderDetails
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int OrderNumber { get; set; }
        public int Price { get; set; }
        public DateTime ShipDate { get; set; }
    }
}
