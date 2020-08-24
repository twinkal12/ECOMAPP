using Microsoft.EntityFrameworkCore;
using core.Entities;
using System.Reflection;

namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base
        (options)
        {


        }
        public DbSet<product> products{get; set;}
         public DbSet<ProductBrand> productBrands{get; set;}

         public DbSet<ProductType> productsType {get; set;}
        
protected override void OnModelCreating(ModelBuilder modelBuilder)
{ base.OnModelCreating(modelBuilder);
modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

}

    }
}