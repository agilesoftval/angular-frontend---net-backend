using System.Data.Entity.Infrastructure;

namespace AngularDemo.Models
{
    public class ShoppingAppDbContextFactory
        : IDbContextFactory<ShoppingAppDbContext>
    {
        public ShoppingAppDbContext Create()
        {
            return new ShoppingAppDbContext("ShoppingAppConnection");
        }
    }
}