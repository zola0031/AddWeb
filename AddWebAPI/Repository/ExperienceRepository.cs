using AddWebAPI.Context;
using AddWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddWebAPI.Repository
{
    public class ExperienceRepository : IExperienceRepository
    {

        private readonly AddWebDBContext _dBContext;

        public ExperienceRepository(AddWebDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task<Experience> CreateAsync(Experience experience)
        {
            try
            {
                await _dBContext.Experiences.AddAsync(experience);
                await _dBContext.SaveChangesAsync();
                return experience;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Experience> UpdateAsync(Experience experience)
        {

            try
            {
                _dBContext.Experiences.Update(experience);
                await _dBContext.SaveChangesAsync();
                return experience;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task DeleteAsync(Guid id)
        {
            var result = await GetByIdAsync(id);
            _dBContext.Experiences.Remove(result);
            await _dBContext.SaveChangesAsync();
        }

        public async Task<List<Experience>> GetAsync()
        {
            var experiences = await _dBContext.Experiences.ToListAsync();
            return experiences;
        }

        public async Task<List<Experience>> GetByUserIdAsync(Guid userId)
        {
            var experiences = await _dBContext.Experiences.Where(x => x.UserId == userId).ToListAsync();
            return experiences;
        }

        public async Task<Experience> GetByIdAsync(Guid id)
        {
            var experience = await _dBContext.Experiences.FindAsync(id);
            return experience;
        }
    }
}
