using Microsoft.EntityFrameworkCore;
using Module4HW4.Data;
using Module4HW4.Data.Entities;
using Module4HW4.Repositories.Abstractions;
using Module4HW4.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4HW4.Repositories
{
    internal class ProductsRepository : IProductsRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductsRepository(IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
        {
            _dbContext = dbContextWrapper.DbContext;
        }
        public async Task<string> AddProductAsync(string productName, string productDescription,
            int UnitPrice, int currentOrder, string supplier,string category)
        {
            var product = new ProductsEntity()
            {
                ProductId = Guid.NewGuid().ToString(),
                ProductName = productName,
                ProductDescription = productDescription,
                UnitPrice = UnitPrice,
                SupplierId = supplier,
                CurrentOrder = currentOrder,
                CategoryId = category
                
            };

            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();

            return product.ProductId;
        }
        public async Task<ProductsEntity?> GetProductAsync(string id)
        {
            return await _dbContext.Products.FirstOrDefaultAsync(d => d.ProductId == id);
        }
        public async Task<bool> UpdateDescription(string id, string description)
        {
            var entity = await _dbContext.Products.FirstOrDefaultAsync(d => d.ProductId == id);
            if (entity == null)
            {
                return false;
            }

            entity!.ProductDescription = description;
            _dbContext.Entry(entity).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();

            return true;
        }
        public async Task<bool> Delete(string id)
        {
            var entity = await _dbContext.Products.FirstOrDefaultAsync(d => d.ProductId == id);
            if (entity == null)
            {
                return false;
            }

            _dbContext.Entry(entity).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
