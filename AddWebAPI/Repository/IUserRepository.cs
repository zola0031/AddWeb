using AddWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AddWebAPI.Repository
{
    public interface IUserRepository
    {
        Task<User> CreateAsync(User user);
        Task DeleteAsync(Guid id);
        Task<List<User>> GetAsync();
        Task<User> GetByIdAsync(Guid id);
        Task<User> UpdateAsync(User user);
    }
}