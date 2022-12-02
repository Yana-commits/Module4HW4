using Module4HW4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4HW4.Services.Abstractions
{
    interface IProductsService
    {
        Task<string> AddProductAsync(string productName, string productDescription,
            int UnitPrice, int currentOrder, string supplier, string category);
        Task<Products> GetProductAsync(string id);
        Task<bool> UpdateDescription(string id, string description);
        Task<bool> Delete(string id);
    }
}
