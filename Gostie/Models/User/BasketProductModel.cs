using Gostie.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gostie.Models.User
{
    public class BasketProductModel
    {
        public BasketProductModel(Basket basket,Product product)
        {
            this.basket = basket;
            this.product = product;
        }
        public Basket basket{ get; set; }
        public Product product { get; set; }
    }
}
