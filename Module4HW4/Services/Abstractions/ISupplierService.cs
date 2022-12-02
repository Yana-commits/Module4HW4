using Module4HW4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4HW4.Services.Abstractions
{
    internal interface ISupplierService
    {
        Task<string> AddSupplierAsync(string companyName, string contractName,
            string contractTitle, string address, List<Products> products);
        Task<Suppliers> GetSuppliersAsync(string id);
        Task<bool> UpdateAdress(string id, string adress);
        Task<bool> Delete(string id);
    }
}
