using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4HW4.Data.Entities
{
    internal class SuppliersEntity
    {
        public string SupplierId { get; set; }
        public string CompanyName { get; set; }
        public string ContractName { get; set; }
        public string ContractTitle { get; set; }
        public string Address { get; set; }

        public List<ProductsEntity> Products { get; set; } = new List<ProductsEntity>();
    }
}
