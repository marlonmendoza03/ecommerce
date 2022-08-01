using Microsoft.EntityFrameworkCore;
using Repository.RepositoryDTO;

namespace Repository.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Products> products { get; set; }
        public DbSet<Users> users { get; set; }
        public DbSet<Orders> orders { get; set; }
        public DbSet<Logs> logs { get; set; }
    }
}
