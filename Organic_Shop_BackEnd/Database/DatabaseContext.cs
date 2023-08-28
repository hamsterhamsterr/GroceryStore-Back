using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Organic_Shop_BackEnd.Model;

namespace Organic_Shop_BackEnd.Database
{
    public class DatabaseContext : IdentityDbContext<ApiUser>
    {
        protected readonly IConfiguration configuration;

        public DatabaseContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                },
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
