using System.Collections.Generic;

namespace AngularDemo.Models
{
    internal interface IShoppingCart : IShopping, ICheckout
    {
        void AddToCart(Product product);
        void AddToCart(ICollection<Product> products);
    }
}