using Microsoft.EntityFrameworkCore;
using core.Entities;

namespace Infrastructure.Data
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base
        (options)
        {


        }
        public DbSet<product> products{get; set;}
        
    }
}