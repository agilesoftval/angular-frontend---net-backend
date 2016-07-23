using System.Data.Entity;

namespace AngularDemo.Models
{
    public class ShoppingAppDbContext : DbContext
    {
        public ShoppingAppDbContext()
            : base("ShoppingAppConnection")
        {
        }

        public ShoppingAppDbContext(string nameOrConnectionString) 
            : base(nameOrConnectionString)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImage { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
    }
}