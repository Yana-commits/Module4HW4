using Module4HW4.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4HW4.Repositories.Abstractions
{
    internal interface IShippersRepository
    {
        Task<string> AddSupplierAsync(string companyName, string Phone);
        Task<ShippersEntity?> GetShipperAsync(string id);
    }
}
