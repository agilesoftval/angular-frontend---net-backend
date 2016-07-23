using System.Collections.Generic;

namespace AngularDemo.Models
{
    internal interface ICheckout
    {
        string Checkout(Product product);
        string Checkout(ICollection<Product> products);
    }
}