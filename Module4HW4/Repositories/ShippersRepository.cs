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
    internal class ShippersRepository: IShippersRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ShippersRepository(IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
        {
            _dbContext = dbContextWrapper.DbContext;
        }
        public async Task<string> AddSupplierAsync(string companyName, string Phone)
        {
            var shipper = new ShippersEntity()
            {
                ShipperId = Guid.NewGuid().ToString(),
                CompanyName = companyName,
                Phone = Phone
                
            };

            await _dbContext.Shippers.AddAsync(shipper);
            await _dbContext.SaveChangesAsync();

            return shipper.ShipperId;
        }
        public async Task<ShippersEntity?> GetShipperAsync(string id)
        {
            return await _dbContext.Shippers.FirstOrDefaultAsync(d => d.ShipperId == id);
        }
    }
}
