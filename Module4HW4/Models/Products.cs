using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4HW4.Models
{
    internal class Products
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int UnitPrice { get; set; }
        public string SupplierId { get; set; }
        public string CategoryId { get; set; }
        public int CurrentOrder { get; set; }
    }
}
