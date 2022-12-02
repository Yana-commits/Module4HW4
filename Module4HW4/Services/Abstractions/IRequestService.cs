using Module4HW4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4HW4.Services.Abstractions
{
    internal interface IRequestService
    {
        Task<Products?> GetProductWithNameAsync(string name);
        Task<List<Customers>> GetCustomer(string customerClass);
        Task<List<string>> GetSupplierCompanies();
        Task<List<OrderDetails>> GetExistOrderDetails();
        Task<List<int>> GetOrdersDetails(int minPrice);
    }
}
