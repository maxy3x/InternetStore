using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public class WebStoreDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductStatus> ProductStatus { get; set; }
        public DbSet<ProductImage> ProductImage { get; set; }
        public DbSet<ProductAvailabilityStatus> ProductAvailabilityStatus { get; set; }
        public DbSet<ProductColor> ProductColor { get; set; }
        public DbSet<ProductMetal> ProductMetal { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public WebStoreDbContext(DbContextOptions<WebStoreDbContext> options)
            : base(options)
        {
                   
        }
    }
}