using Catalog.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Data.Interfaces
{
    public interface ICatalogContext
    {
        public DbSet<Product> Products { get; set; }

        void SaveChanges();
    }
}