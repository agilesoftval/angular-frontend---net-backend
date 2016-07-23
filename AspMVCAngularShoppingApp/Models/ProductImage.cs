using System;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AngularDemo.Models
{
    public class ProductImage
    {
        [Key]
        public int ImageId { get; set; }
        public string ImageUrl { get; set; }
    }

    public class ProductImageVm : ProductImage
    {
        public static readonly Expression<Func<ProductImage, ProductImageVm>> Select =
            x => new ProductImageVm
            {
                ImageId = x.ImageId,
                ImageUrl = x.ImageUrl,
            };
    }
}