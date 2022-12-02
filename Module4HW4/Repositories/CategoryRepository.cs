using Microsoft.EntityFrameworkCore;
using Module4HW4.Data;
using Module4HW4.Data.Entities;
using Module4HW4.Repositories.Abstractions;
using Module4HW4.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module4HW4.Repositories
{
    internal class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryRepository(IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
        {
            _dbContext = dbContextWrapper.DbContext;
        }

        public async Task<string> AddCategoryAsync(string categoryName, string description, string picture)
        {
            var category = new CategoryEntity()
            {
                CategoryId = Guid.NewGuid().ToString(),
                CategoryName = categoryName,
                Description = description,
                Picture = picture,
                Active = true
               
            };

            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();

            return category.CategoryId;
        }

        public async Task<CategoryEntity?> GetCategoryAsync(string id)
        {
            return await _dbContext.Categories.FirstOrDefaultAsync(f => f.CategoryId == id);
        }

        public async Task<bool> MakeNotActive(string id)
        {
            var entity = await _dbContext.Categories.FirstOrDefaultAsync(d => d.CategoryId == id);
            if (entity == null)
            {
                return false;
            }

            entity!.Active = false;
            _dbContext.Entry(entity).CurrentValues.SetValues(entity);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
