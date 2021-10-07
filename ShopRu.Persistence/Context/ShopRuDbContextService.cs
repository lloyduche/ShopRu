using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopRu.Persistence.Context
{
    public static class ShopRuDbContextService
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContextPool<ShopRuDbContext>(dbContextOptions =>
            dbContextOptions.UseSqlite(
                configuration.GetConnectionString("ShopRuConnection")           
                ));

            return services;
        }
        
    }
}
