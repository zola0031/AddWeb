using AddWebAPI.Context;
using AddWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddWebAPI.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly AddWebDBContext _dBContext;

        public UserRepository(AddWebDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<User> CreateAsync(User user)
        {
            try
            {
                await _dBContext.Users.AddAsync(user);
                await _dBContext.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<User> UpdateAsync(User user)
        {

            try
            {
                _dBContext.Users.Update(user);
                await _dBContext.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task DeleteAsync(Guid id)
        {
            var result = await GetByIdAsync(id);
            _dBContext.Users.Remove(result);
            await _dBContext.SaveChangesAsync();
        }

        public async Task<List<User>> GetAsync()
        {
            var users = await _dBContext.Users.ToListAsync();
            return users;
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            var user = await _dBContext.Users
                            .Include(e => e.Experiences)
                            .FirstOrDefaultAsync(x => x.Id == id);
            return user;
        }
    }
}
