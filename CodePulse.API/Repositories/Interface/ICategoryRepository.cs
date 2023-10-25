using CodePulse.API.Models.Domain;
using CodePulse.API.Models.DTO;
using System.Collections;

namespace CodePulse.API.Repositories.Interface
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);

        Task<IEnumerable<Category>>GetAllAsync();

       Task<Category?> GetById(Guid id);

      Task<Category?>  UpdateAsynce (Category category);
        
    Task<Category?>  DeleAsync(Guid id);      
    }
}
