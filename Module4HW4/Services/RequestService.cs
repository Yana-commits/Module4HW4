using Microsoft.Extensions.Logging;
using Module4HW4.Data;
using Module4HW4.Data.Entities;
using Module4HW4.Models;
using Module4HW4.Repositories;
using Module4HW4.Repositories.Abstractions;
using Module4HW4.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Module4HW4.Services
{
    internal class RequestService : BaseDataService<ApplicationDbContext>, IRequestService
    {
        private readonly IRequestRepository _requestRepository;
        private readonly ILogger<RequestService> _loggerService;
        protected RequestService(IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<IBaseDataService> logger, IRequestRepository requestRepository,
            ILogger<RequestService> loggerService) : base(dbContextWrapper, logger)
        {
            _loggerService = loggerService;
            _requestRepository = requestRepository;
        }

        public async Task<Products?> GetProductWithNameAsync(string name)
        {
            var result = await _requestRepository.GetProductWithNameAsync(name);

            if (result == null)
            {
                _loggerService.LogWarning($"Not founded product with name = {name}");
                return null!;
            }
            return new Products()
            {
                ProductId = result.ProductId,
                ProductName = result.ProductName,
                ProductDescription = result.ProductDescription,
                UnitPrice = result.UnitPrice,
                SupplierId = result.SupplierId,
                CurrentOrder = result.CurrentOrder,
                CategoryId = result.CategoryId

            };
        }
        public async Task<List<Customers>> GetCustomer(string customerClass)
        {
            var result = await _requestRepository.GetCustomer(customerClass);
            if (result == null)
            {
                _loggerService.LogWarning($"Not founded customers with class = {customerClass}");
                return null!;
            }
            var customers = new List<Customers>();
            foreach (var item in result)
            {
                var cust = new Customers()
                {
                    CustomerId = item.CustomerId,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Class = item.Class,
                    Address = item.Address
                };

                customers.Add(cust);
            }
            return customers;
        }

        public async Task<List<string>> GetSupplierCompanies()
        {
            var result = await _requestRepository.GetSupplierCompanies();

            if (result == null)
            {
                _loggerService.LogWarning($"Not founded suppliers componies");
                return null!;
            }
            return result;
        }

        public async Task<List<OrderDetails>> GetExistOrderDetails()
        {
            var result = await _requestRepository.GetExistOrderDetails();
            if (result == null)
            {
                _loggerService.LogWarning($"Not founded existed order details");
                return null!;
            }
            var orderDetails = new List<OrderDetails>();
            foreach (var item in result)
            {
                var order = new OrderDetails()
                {
                    OrderID = item.OrderId,
                    ProductID = item.ProductId,
                    Price = item.Price,
                    OrderNumber = item.OrderNumber,
                    ShipDate = item.ShipDate,
                };

                orderDetails.Add(order);
            }
            return orderDetails;
        }
        public async Task<List<int>> GetOrdersDetails(int minPrice)
        {
            var result = await _requestRepository.GetOrdersDetails(minPrice);

            if (result == null)
            {
                _loggerService.LogWarning($"Not founded Oders with price more then {minPrice}");
                return null!;
            }

            return result;
        }
    }
}
