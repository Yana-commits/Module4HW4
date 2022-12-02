using Module4HW4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4HW4.Services.Abstractions
{
    internal interface ICategoryService
    {
        Task<string> AddCategoryAsync(string categoryName, string description, string picture);
        Task<Category> GetGetCategoryAsync(string id);
        Task<bool> MakeNotActiveAsync(string id);
    }
}
