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
    internal class ShippersService : BaseDataService<ApplicationDbContext>, IShippersService
    {
        private readonly IShippersRepository _shippersRepository;
        private readonly ILogger<ShippersService> _loggerService;

        protected ShippersService(IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<IBaseDataService> logger, IShippersRepository shippersRepository,
            ILogger<ShippersService> loggerService) : base(dbContextWrapper, logger)
        {
            _shippersRepository = shippersRepository;
            _loggerService = loggerService;
        }
        public async Task<string> AddShipperAsync(string companyName, string Phone)
        {
            var id = await _shippersRepository.AddSupplierAsync(companyName, Phone);
            _loggerService.LogInformation($"Created shipper with Id= {id}");

            return id.ToString();
        }
        public async Task<Shippers> GetShipperAsync(string id)
        {
            var result = await _shippersRepository.GetShipperAsync(id);

            if (result == null)
            {
                _loggerService.LogWarning($"Not founded shipper with Id = {id}");
                return null!;
            }

            return new Shippers()
            {
                ShipperId = result.ShipperId,
                CompanyName = result.CompanyName,
                Phone = result.Phone
            };
        }
    }
}
