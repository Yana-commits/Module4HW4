using Module4HW4.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4HW4.Repositories.Abstractions
{
    internal interface ICategoryRepository
    {
        Task<string> AddCategoryAsync(string categoryName, string description, string picture);
        Task<CategoryEntity?> GetCategoryAsync(string id);
        Task<bool> MakeNotActive(string id);
    }
}
