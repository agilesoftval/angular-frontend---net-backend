namespace AngularDemo.Models
{
    internal interface IShoppingWishList : IShoppingCart, ICheckout
    {
        void AddToWishList(Product products);
    }
}