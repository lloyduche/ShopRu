using Microsoft.EntityFrameworkCore;
using ShopRu.Domain;
using ShopRu.Domain.Customer;
using ShopRu.Domain.Discount;
using ShopRu.Domain.Invoice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShopRu.Persistence.Context
{
    public interface IShopRuDbContext
    {

         DbSet<Item> Items { get; set; }
         DbSet<Customer> Customers { get; set; }
         DbSet<Discount> Discounts { get; set; }
         DbSet<Invoice> Invoices { get; set; }
         Task<int> SaveChangesAsync();

    }
}
