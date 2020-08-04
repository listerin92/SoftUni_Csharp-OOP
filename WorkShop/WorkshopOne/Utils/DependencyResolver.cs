using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using ProductCatalog.Pages;
using ProductCatalog.Core.Contracts;
using ProductCatalog.Core.Services;
using ProductCatalog.Infrastructure.Data;
using ProductCatalog.Infrastructure.Data.Common;

namespace ProductCatalog.Utils
{
    public static class DependencyResolver
    {
        public static IServiceProvider GetServiceProvider()
        {
            var services = new ServiceCollection();

            services.AddSingleton<Application>();
            services.AddScoped<Menu>();
            services.AddScoped<ProductPage>();

            services.AddSingleton<IRepository, Repository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddDbContext<ApplicationDBContext>(o => o.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=dotnet-productcatalog;Trusted_Connection=True;MultipleActiveResultSets=true"));

            return services.BuildServiceProvider();
        }
    }
}
