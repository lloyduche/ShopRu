

using Microsoft.EntityFrameworkCore;
using ShopRu.Domain;
using ShopRu.Domain.Customer;
using ShopRu.Domain.Discount;
using ShopRu.Domain.Invoice;
using System.Threading;
using System.Threading.Tasks;

namespace ShopRu.Persistence.Context
{
    public class ShopRuDbContext:DbContext,IShopRuDbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
      

        public async Task<int> SaveChangesAsync()
        {
            var result = await base.SaveChangesAsync();
            return result;
        }
        public ShopRuDbContext(DbContextOptions<ShopRuDbContext> dbContextOptions): base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
        
    }
}
