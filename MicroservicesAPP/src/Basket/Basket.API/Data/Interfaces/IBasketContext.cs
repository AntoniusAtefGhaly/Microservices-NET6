using Basket.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Data.Interfaces
{
    public interface IBasketContext
    {
        public DbSet<BasketCart> BasketCarts { get; set; }
        public DbSet<BasketCartItem> BasketCartItems { get; set; }

        void SaveChanges();
    }
}