using Microsoft.Extensions.Logging;
using Module4HW4.Data;
using Module4HW4.Models;
using Module4HW4.Repositories.Abstractions;
using Module4HW4.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4HW4.Services
{
    internal class SupplierService : BaseDataService<ApplicationDbContext> , ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly ILogger<SupplierService> _loggerService;

        public SupplierService(IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            ISupplierRepository supplierRepository, ILogger<SupplierService> loggerService)
            : base(dbContextWrapper, logger)
        {
            _supplierRepository = supplierRepository;
            _loggerService = loggerService;
        }

        public async Task<string> AddSupplierAsync(string companyName, string contractName,
            string contractTitle, string address, List<Products> products)
        {
            var id = await _supplierRepository.AddSupplierAsync(companyName, contractName, contractTitle, address, products);
            _loggerService.LogInformation($"Created supplier with Id= {id}");

            return id.ToString();
        }

        public async Task<Suppliers> GetSuppliersAsync(string id)
        {
            var result = await _supplierRepository.GetSupplierAsync(id);

            if (result == null)
            {
                _loggerService.LogWarning($"Not founded Supplier with Id = {id}");
                return null!;
            }

            return new Suppliers()
            {
                SupplierId = result.SupplierId,
                CompanyName = result.CompanyName,
                ContractName = result.ContractName,
                ContractTitle = result.ContractTitle,   
                Address = result.Address
            };
        }
        public async Task<bool> UpdateAdress(string id, string adress)
        {
            var result = await _supplierRepository.UpdateAdress(id,adress);

            if (!result)
            {
                _loggerService.LogWarning("Not found");
                return false;
            }

            _loggerService.LogInformation($"Supplier {id} was updated");
            return true;
        }

        public async Task<bool> Delete(string id)
        { 
        var result = await _supplierRepository.Delete(id);

            if (!result)
            {
                _loggerService.LogWarning("Not found");
                return false;
            }

            _loggerService.LogInformation($"Supplier {id} was deleted");
            return true;
        }
    }
}
