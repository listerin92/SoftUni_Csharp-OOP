using Microsoft.EntityFrameworkCore;
using ProductCatalog.Infrastructure.Data.Model;

namespace ProductCatalog.Infrastructure.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
        :base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }

    }
}