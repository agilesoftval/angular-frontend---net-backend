using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AngularDemo.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int ProductQuantity { get; set; }
        public ProductImage ProductImage { get; set; }
        public int ProductRating { get; set; }
        public string ProductCategory { get; set; }
        public int ProductPrice { get; set; }
        protected int ProductVendorCount { get; set; }
        public ICollection<Vendor> ProductVendor { get; set; }
    }

    public class ProductVm : Product
    {
        public static readonly Expression<Func<Product, ProductVm>> Select =
             x => new ProductVm
             {
                 ProductImage = x.ProductImage,
                 ProductVendorCount = x.ProductVendor.Count,
                 ProductId = x.ProductId,
                 ProductName = x.ProductName,
                 ProductDescription = x.ProductDescription,
                 ProductQuantity = x.ProductQuantity,
                 ProductRating = x.ProductRating,
                 ProductCategory = x.ProductCategory,
                 ProductPrice = x.ProductPrice
             };
    }
}