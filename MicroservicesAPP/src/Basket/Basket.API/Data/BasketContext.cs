using Basket.API.Data.Interfaces;
using Basket.API.Entities;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Data
{
    public class BasketContext : DbContext, IBasketContext
    {
        public BasketContext(DbContextOptions<BasketContext> options) : base(options)
        {
        }

        public DbSet<BasketCart> BasketCarts { get; set; }

        public DbSet<BasketCartItem> BasketCartItems { get; set; }

        public void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}