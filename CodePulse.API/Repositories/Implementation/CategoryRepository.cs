using CodePulse.API.Data;
using CodePulse.API.Models.Domain;
using CodePulse.API.Models.DTO;
using CodePulse.API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CodePulse.API.Repositories.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext dbContext;

        public CategoryRepository(ApplicationDbContext dbContext)

        {
            this.dbContext = dbContext;  
        }
        public async Task<Category> CreateAsync(Category category)
        {
            await dbContext.Categorys.AddAsync(category);
            await dbContext.SaveChangesAsync();

            return category;
        }

        public async Task<Category?> DeleAsync(Guid id)
        {
            var existingCategory = await dbContext.Categorys.FirstOrDefaultAsync(x => x.Id == id);
            if (existingCategory is null)
            {
                return null;
            }
            dbContext.Categorys.Remove(existingCategory);
            await dbContext.SaveChangesAsync();
            return existingCategory;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
         return  await dbContext.Categorys.ToListAsync();
        }

        public async Task<Category?> GetById(Guid id)
        {
         return  await dbContext.Categorys.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Category?> UpdateAsynce(Category category)
        {
         var existingCategory = await dbContext.Categorys.FirstOrDefaultAsync(x=>x.Id == category.Id);
            if (existingCategory != null)
            {
                dbContext.Entry(existingCategory).CurrentValues.SetValues(category);
                await dbContext.SaveChangesAsync();
                return category;
            }
            return null;
        }

     
    }
}
