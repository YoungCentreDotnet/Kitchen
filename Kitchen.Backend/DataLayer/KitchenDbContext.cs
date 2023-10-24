using Kitchen.Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Kitchen.Backend.DataLayer
{
    public class KitchenDbContext : DbContext
    {
        public KitchenDbContext(DbContextOptions<KitchenDbContext> options) 
            : base(options) { }


        public DbSet<Admin> Admins { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
