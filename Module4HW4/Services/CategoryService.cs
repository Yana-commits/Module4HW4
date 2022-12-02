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
    internal class CategoryService : BaseDataService<ApplicationDbContext>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<CategoryService> _loggerService;
        protected CategoryService(IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<IBaseDataService> logger, ICategoryRepository categoryRepository,
        ILogger<CategoryService> loggerService
            ) : base(dbContextWrapper, logger)
        {
            _categoryRepository = categoryRepository;
            _loggerService = loggerService;
        }

        public async Task<string> AddCategoryAsync(string categoryName, string description, string picture)
        {
            var id = await _categoryRepository.AddCategoryAsync(categoryName, description, picture);
            _loggerService.LogInformation($"Created category with Id= {id}");

            return id.ToString();
        }
        public async Task<Category> GetGetCategoryAsync(string id)
        {
            var result = await _categoryRepository.GetCategoryAsync(id);

            if (result == null)
            {
                _loggerService.LogWarning($"Not founded category with Id = {id}");
                return null!;
            }

            if (result.Active == false)
            {
                _loggerService.LogWarning($"Category is not active");
                return null!;
            }

            return new Category()
            {
                CategoryId = result.CategoryId,
                CategoryName = result.CategoryName,
                Description = result.Description,
                Picture = result.Picture,
                Active = result.Active
            };
        }
        public async Task<bool> MakeNotActiveAsync(string id)
        {
            var result = await _categoryRepository.MakeNotActive(id);

            if (!result)
            {
                _loggerService.LogWarning("Not found");
                return false;
            }

            _loggerService.LogInformation($"Category is not active");
            return true;
        }
    }
}
