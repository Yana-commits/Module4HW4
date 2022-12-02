using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4HW4.Data.Entities
{
    internal class CategoryEntity
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public bool Active { get; set; }
        public List<ProductsEntity> Products { get; set; } = new List<ProductsEntity>();
    }
}
