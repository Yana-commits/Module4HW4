using Microsoft.Extensions.Logging;
using Module4HW4.Data;
using Module4HW4.Models;
using Module4HW4.Repositories;
using Module4HW4.Repositories.Abstractions;
using Module4HW4.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4HW4.Services
{
    internal class ProductsService : BaseDataService<ApplicationDbContext>, IProductsService
    {
        private readonly IProductsRepository _productsRepository;
        private readonly ILogger<ProductsService> _loggerService;
        protected ProductsService(IDbContextWrapper<ApplicationDbContext> dbContextWrapper, 
            ILogger<IBaseDataService> logger, IProductsRepository productsRepository,
            ILogger<ProductsService> loggerService) : base(dbContextWrapper, logger)
        {
            _productsRepository = productsRepository;
            _loggerService = loggerService;
        }
        public async Task<string> AddProductAsync(string productName, string productDescription,
            int UnitPrice, int currentOrder, string supplier, string category)
        {
            var id = await _productsRepository.AddProductAsync(productName,productDescription,UnitPrice, currentOrder,supplier,category);
            _loggerService.LogInformation($"Created product with Id= {id}");

            return id.ToString();
        }
        public async Task<Products> GetProductAsync(string id)
        {
            var result = await _productsRepository.GetProductAsync(id);

            if (result == null)
            {
                _loggerService.LogWarning($"Not founded product with Id = {id}");
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
        public async Task<bool> UpdateDescription(string id, string description)
        {
            var result = await _productsRepository.UpdateDescription(id, description);

            if (!result)
            {
                _loggerService.LogWarning("Not found");
                return false;
            }

            _loggerService.LogInformation($"Product {id} was updated");
            return true;
        }
        public async Task<bool> Delete(string id)
        {
            var result = await _productsRepository.Delete(id);

            if (!result)
            {
                _loggerService.LogWarning("Not found");
                return false;
            }

            _loggerService.LogInformation($"Product {id} was deleted");
            return true;
        }
    }
}
