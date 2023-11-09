using Kitchen.Backend.Model;
using Kitchen.Backend.Model.Menu;
using Kitchen.Backend.Model.Payment;
using Kitchen.Backend.Model.Post;
using Kitchen.Backend.Model.Stock;
using Microsoft.EntityFrameworkCore;

namespace Kitchen.Backend.DataLayer
{
    public class KitchenDbContext : DbContext
    {
        public KitchenDbContext(DbContextOptions<KitchenDbContext> options) 
            : base(options) { }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Table> Table { get; set; }
        public DbSet<Beverages> Beveragess { get; set; }
        //public DbSet<Dessert> Desserts { get; set; }
        //public DbSet<FastFood> FastFoods { get; set; }
        //public DbSet<Payment> Payments { get; set; }
        //public DbSet<Post> Posts { get; set; }
        //public DbSet<KgProduct> KgProducts { get; set; }
        //public DbSet<PieceProduct> PieceProducts { get; set; }

        //public DbSet<User> Users { get; set; }
    }
}
