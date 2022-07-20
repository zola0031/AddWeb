using AddWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AddWebAPI.Context
{
    public class AddWebDBContext : DbContext
    {
        public AddWebDBContext()
        {

        }
        public AddWebDBContext(DbContextOptions<AddWebDBContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Experience> Experiences { get; set; }
    }
}
