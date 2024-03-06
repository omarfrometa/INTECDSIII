using DSIII.WebAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace DSIII.WebAPI
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> User { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
    }
}
