using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopRu.Domain;
using ShopRu.Domain.Customer;
using ShopRu.Domain.Discount;
using ShopRu.Persistence.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShopRu.Persistence
{
    public static class DataSeeder
    {
        private static string path = Path.GetFullPath(@"../ShopRu.Persistence/Data.Json/");
        public static async Task Seed(ShopRuDbContext context, IServiceProvider serviceProvider)
        {

            context.Database.EnsureCreated();

            //seed Customer
            var customerList = GetSampleData<Customer>(File.ReadAllText(path + "Customer.json"));
            
            using(var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var cxt = serviceScope.ServiceProvider.GetService<ShopRuDbContext>();
                if (!cxt.Customers.Any())
                {
                    await context.AddRangeAsync(customerList);

                }
              
            }

            //seed discount
            var discountList = GetSampleData<Discount>(File.ReadAllText(path + "Discount.json"));
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var cxt = serviceScope.ServiceProvider.GetService<ShopRuDbContext>();
                if (!cxt.Discounts.Any())
                {
                    await context.AddRangeAsync(discountList);
                }


            }

            //seed items
            var itemList = GetSampleData<Item>(File.ReadAllText(path + "Item.json"));
            using (var serviceScope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var cxt = serviceScope.ServiceProvider.GetService<ShopRuDbContext>();
                if (!cxt.Items.Any())
                {
                    await context.AddRangeAsync(itemList);
                }


            }


            //invoice creation algorithm




            await context.SaveChangesAsync();
        }

        private static List<T> GetSampleData<T>(string location)
        {
            var output = JsonSerializer.Deserialize<List<T>>(location,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return output;
        }

    }
}
