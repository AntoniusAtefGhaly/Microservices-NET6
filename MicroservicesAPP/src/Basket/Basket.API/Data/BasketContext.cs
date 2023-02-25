using Basket.API.Data.Interfaces;
using Basket.API.Entities;

//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Basket.API.Data
{
    public class BasketContext : DbContext, IBasketContext
    {
        public BasketContext(DbContextOptions<BasketContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new BasketConfiguration());

            //modelBuilder.Entity<BasketCart>().
            //    HasMany(a => a.BasketCartItems)
            //.WillCascadeOnDelete(true);
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<BasketCart>()
        //    .HasMany(a => a.BasketCartItems)
        //    .WithOptional() // or `WithRequired() in case Car requires Person
        //    .WillCascadeOnDelete(true);
        //}
        public DbSet<BasketCart> BasketCarts { get; set; }

        public DbSet<BasketCartItem> BasketCartItems { get; set; }

        public void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}