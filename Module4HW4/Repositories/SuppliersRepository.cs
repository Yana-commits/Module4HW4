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
    internal class SuppliersRepository : ISupplierRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public SuppliersRepository(IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
        {
            _dbContext = dbContextWrapper.DbContext;
        }

        public async Task<string> AddSupplierAsync(string companyName, string contractName, string contractTitle, string address,
            List<Products> products)
        {
            var supplier = new SuppliersEntity()
            {
                SupplierId = Guid.NewGuid().ToString(),
                CompanyName = companyName,
                ContractName = contractName,
                ContractTitle = contractTitle,
                Address = address
            };

            //await _dbContext.Products.AddRangeAsync(products.Select(s => new ProductsEntity() 
            //{
            //    ProductName = s.ProductName,
            //    ProductDescription = s.ProductDescription,
            //    UnitPrice = s.UnitPrice,
            //    SupplierId = supplier.SupplierId,
            //    CurrentOrder = s.CurrentOrder,
            //    CategoryId = s.CategoryId
            //}
            //));
            await _dbContext.Suppliers.AddAsync(supplier);
            await _dbContext.SaveChangesAsync();

            return supplier.SupplierId;
        }

        public async Task<SuppliersEntity?> GetSupplierAsync(string id)
        {
            return await _dbContext.Suppliers.FirstOrDefaultAsync(d => d.SupplierId == id);
        }

        public async Task<bool> UpdateAdress(string id, string adress)
        {
            var entity = await _dbContext.Suppliers.FirstOrDefaultAsync(d => d.SupplierId == id);
            if (entity == null)
            {
                return false;
            }

            entity!.Address = adress;
            _dbContext.Entry(entity).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(string id)
        {
            var entity = await _dbContext.Suppliers.FirstOrDefaultAsync(d => d.SupplierId == id);
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
