using Module4HW4.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4HW4.Repositories.Abstractions
{
    internal interface IProductsRepository
    {
        Task<string> AddProductAsync(string productName, string productDescription,
            int UnitPrice, int currentOrder, string supplier, string category);
        Task<ProductsEntity?> GetProductAsync(string id);
        Task<bool> UpdateDescription(string id, string description);
        Task<bool> Delete(string id);
    }
}
