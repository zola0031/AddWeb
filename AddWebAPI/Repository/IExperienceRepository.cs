using AddWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AddWebAPI.Repository
{
    public interface IExperienceRepository
    {
        Task<Experience> CreateAsync(Experience experience);
        Task DeleteAsync(Guid id);
        Task<List<Experience>> GetAsync();
        Task<List<Experience>> GetByUserIdAsync(Guid userId);
        Task<Experience> GetByIdAsync(Guid id);
        Task<Experience> UpdateAsync(Experience experience);
    }
}