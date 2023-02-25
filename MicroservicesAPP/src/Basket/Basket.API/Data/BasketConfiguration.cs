using Basket.API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Basket.API.Data
{
    public class BasketConfiguration : IEntityTypeConfiguration<BasketCart>
    {
        public void Configure(EntityTypeBuilder<BasketCart> builder)
        {
            builder.HasData(
                 GetPreconfiguredProducts()
                );
        }

        private static IEnumerable<BasketCart> GetPreconfiguredProducts()
        {
            return new List<BasketCart>()
            {
                new BasketCart("user1"),
                new BasketCart("user2"),
                new BasketCart("user3")
            };
        }
    }
}