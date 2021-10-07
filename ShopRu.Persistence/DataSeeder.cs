using Microsoft.EntityFrameworkCore;
using ShopRu.Domain.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRu.Persistence
{
    public static class DataSeeder
    {

        public static void Seed(this ModelBuilder modelBuilder)
        {
            #region Data for Customers

            modelBuilder.Entity<Customer>()
                .HasData(
                
                new Customer
                {

                }
                
                );
            #endregion

        }

    }
}
