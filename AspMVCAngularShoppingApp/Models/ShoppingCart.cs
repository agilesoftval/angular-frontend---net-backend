﻿using System;
using System.Collections.Generic;

namespace AngularDemo.Models
{
    public class ShoppingCart : IShoppingCart
    {
        public Guid ShoppingSesssionId { get; set; }
        public void AddToCart(Product products)
        {
            throw new NotImplementedException();
        }

        public void AddToCart(ICollection<Product> products)
        {
            throw new NotImplementedException();
        }

        public string Checkout(Product product)
        {
            throw new NotImplementedException();
        }

        public string Checkout(ICollection<Product> products)
        {
            throw new NotImplementedException();
        }
    }
}