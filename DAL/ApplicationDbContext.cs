using Microsoft.EntityFrameworkCore;

using Mortiz.Domain.Entity;

namespace Mortiz.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
           // Database.EnsureCreated();
        }

        public DbSet<User> User { get; set; }
        public DbSet<Clothes> Clothes { get; set; }

    }
}
