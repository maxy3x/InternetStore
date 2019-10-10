using System.Collections.Generic;
using System.Linq;
using DataAccess.Context;
using DataAccess.Interfaces;
using Domain.Models;
using Domain.Models.Enumerations;

namespace DataAccess
{
    public class ProductRepository : IProductRepository
    {
        private readonly WebStoreDbContext _context;

        public ProductRepository(WebStoreDbContext context)
        {
            _context = context;
        }
        public void Insert(Product item)
        {
            Product newProduct = new Product()
            {
                Name = item.Name,
                Amount = item.Amount,
                AvailabilityStatus = item.AvailabilityStatus,
                Gender = item.Gender,
                Price = item.Price,
                ProductColor = item.ProductColor,
                ProductMetal = item.ProductMetal,
                ProductStatus = item.ProductStatus,
                ProductType = item.ProductType,
                Weight = item.Weight,
                IsDeleted = false
            };
            _context.Product.Add(newProduct);
            _context.SaveChanges();
        }

        public Product GetById(int? id)
        {
            var poduct = _context.Product
                .Single(s => s.Id == id);
            return poduct;
        }

        public void Update(Product modifiedProduct)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            var employee = _context.Product
                .Single(s => s.Id == id);
            employee.IsDeleted = true;
            _context.SaveChanges();
        }

        public List<Product> GetByStr(string searchStr)
        {
            return _context.Product.Where(c => c.Name.Contains(searchStr)).ToList();
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Product.Where(x => x.IsDeleted == false).ToList();
        }

        public IEnumerable<Product> GetByProductType(ProductType productType)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Product> GetByProductColor(ProductColor productColor)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Product> GetByProductMetal(ProductMetal productMetal)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Product> GetByProductStatus(ProductStatus productStatus)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Product> GetAllAvailable(ProductAvailabilityStatus productAvailability)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Product> GetByGender(Gender gender)
        {
            throw new System.NotImplementedException();
        }
    }
}