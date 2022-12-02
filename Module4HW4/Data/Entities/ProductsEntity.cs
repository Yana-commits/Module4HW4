using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4HW4.Data.Entities
{
    internal class ProductsEntity
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int UnitPrice { get; set; }
        public string SupplierId { get; set; }
        public SuppliersEntity Supplier { get; set; }
        public string CategoryId { get; set; }
        public CategoryEntity Category { get; set; }
        public int CurrentOrder { get; set; }

        public List<OrderDetailsEntity> OrderDetails = new List<OrderDetailsEntity>();
    }
}
