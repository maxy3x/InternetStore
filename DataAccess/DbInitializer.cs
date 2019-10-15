using System;
using DataAccess.Context;
using System.Linq;
using Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace DataAccess
{
    
    public class DbInitializer
    {
        public static void Initialize(WebStoreDbContext context)
        {
            context.Database.EnsureCreated();
            if (!context.Product.Any())
            {
                var deps = new Product[]
                {
                    new Product() {Name = "Product 01"},
                    new Product() {Name = "Product 02"}
                };
                foreach (var item in deps)
                {
                    context.Product.Add(item);
                }
                context.SaveChanges();
            }
            
            if (!context.ProductStatus.Any())
            {
                var companies = new ProductStatus[]
                {
                    new ProductStatus() {Name = "New"}
                };
                foreach (var item in companies)
                {
                    context.ProductStatus.Add(item);
                }
                context.SaveChanges();
            }
            if (!context.ProductAvailabilityStatus.Any())
            {
                var companies = new ProductAvailabilityStatus[]
                {
                    new ProductAvailabilityStatus() {Name = "Available"},
                    new ProductAvailabilityStatus() {Name = "Not Available"}
                };
                foreach (var item in companies)
                {
                    context.ProductAvailabilityStatus.Add(item);
                }
                context.SaveChanges();
            }
            if (!context.ProductColor.Any())
            {
                var companies = new ProductColor[]
                {
                    new ProductColor() {Name = "White"},
                    new ProductColor() {Name = "Black"}
                };
                foreach (var item in companies)
                {
                    context.ProductColor.Add(item);
                }
                context.SaveChanges();
            }
            if (!context.ProductMetal.Any())
            {
                var companies = new ProductMetal[]
                {
                    new ProductMetal() {Name = "Gold"},
                    new ProductMetal() {Name = "Silver"}
                };
                foreach (var item in companies)
                {
                    context.ProductMetal.Add(item);
                }
                context.SaveChanges();
            }
            if (!context.ProductType.Any())
            {
                var companies = new ProductType[]
                {
                    new ProductType() {Name = "Ring"},
                    new ProductType() {Name = "Earring"}
                };
                foreach (var item in companies)
                {
                    context.ProductType.Add(item);
                }
                context.SaveChanges();
            }
        }
    }
}
