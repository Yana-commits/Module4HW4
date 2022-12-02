using Module4HW4.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4HW4.Repositories.Abstractions
{
    internal interface IRequestRepository
    {
        Task<ProductsEntity?> GetProductWithNameAsync(string name);
        Task<List<CustomersEntity>> GetCustomer(string customerClass);
        Task<List<string>> GetSupplierCompanies();
        Task<List<OrderDetailsEntity>> GetExistOrderDetails();
        Task<OrdersEntity> GetOrdersWithSpeciality(int id);
        Task<List<int>> GetOrdersDetails(int minPrice);
    }
}
