using Microsoft.EntityFrameworkCore;
using Module4HW4.Data;
using Module4HW4.Data.Entities;
using Module4HW4.Models;
using Module4HW4.Repositories.Abstractions;
using Module4HW4.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4HW4.Repositories
{
    internal class RequestRepository : IRequestRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public RequestRepository(IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
        {
            _dbContext = dbContextWrapper.DbContext;
        }

        public async Task<ProductsEntity?> GetProductWithNameAsync(string name)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(d => d.ProductName == name);
        }

        public async Task<List<CustomersEntity>> GetCustomer(string customerClass)
        {
           
            var result = _dbContext.Customers.Where(i => i.Class == customerClass).ToListAsync();
            return await result;
        }

        public async Task<List<string>> GetSupplierCompanies()
        {
            return await _dbContext.Suppliers.Select(i => i.CompanyName).ToListAsync();
        }

        public async Task<List<OrderDetailsEntity>> GetExistOrderDetails()
        { 
           var orders = _dbContext.Orders.Select(i => i.OrderId);

            var orderDetails = _dbContext.OrderDetails.Where(u => orders.Contains(u.OrderId)).ToListAsync();
            return await orderDetails;
        }

        public async Task<OrdersEntity> GetOrdersWithSpeciality(int id)
        {
            var order = _dbContext.Orders.Include(u => u.Payment).Include(i => i.Shipper).
                Where(d => d.OrderId == id).FirstOrDefaultAsync();

            return await order;
        }

        public async Task<List<int>> GetOrdersDetails(int minPrice)
        {
            var orders = _dbContext.OrderDetails.Select(u => u.Price).Where(i => i >= minPrice).ToListAsync();
            return await orders;
        }
    }
}
