using Microsoft.EntityFrameworkCore;
using Organic_Shop_BackEnd.Model;

namespace Organic_Shop_BackEnd.Database
{
    public class DatabaseContext : DbContext
    {
        protected readonly IConfiguration configuration;

        public DatabaseContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<Category> Categories { get; set; } 
    }
}
