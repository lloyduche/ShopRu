

using Microsoft.EntityFrameworkCore;

namespace ShopRu.Persistence.Context
{
    public class ShopRuDbContext:DbContext
    {

        public ShopRuDbContext(DbContextOptions<ShopRuDbContext> dbContextOptions): base(dbContextOptions)
        {

        }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }
        
    }
}
