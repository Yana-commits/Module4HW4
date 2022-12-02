using Module4HW4.Data.Entities;
using Module4HW4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4HW4.Repositories.Abstractions
{
    internal interface ISupplierRepository
    {
        Task<string> AddSupplierAsync(string companyName, string contractName, string contractTitle, string address,
            List<Products> products);
        Task<SuppliersEntity?> GetSupplierAsync(string id);
        Task<bool> UpdateAdress(string id, string adress);
        Task<bool> Delete(string id);
    }
}
