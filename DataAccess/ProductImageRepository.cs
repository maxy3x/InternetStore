using System.Collections.Generic;
using System.Linq;
using DataAccess.Context;
using DataAccess.Interfaces;
using Domain.Models;

namespace DataAccess
{
    public class ProductImageRepository : IProductImageRepository
    {
        private readonly WebStoreDbContext _context;

        public ProductImageRepository(WebStoreDbContext context)
        {
            _context = context;
        }
        public void Insert(ProductImage item)
        {
            ProductImage newImage = new ProductImage()
            {
                Name = item.Name,
                Path = item.Path,
                Product = item.Product,
                IsDeleted = false
            };
            _context.ProductImage.Add(newImage);
            _context.SaveChanges();
        }

        public void InsertFew(IEnumerable<ProductImage> items)
        {
            throw new System.NotImplementedException();
        }

        public ProductImage GetById(int id)
        {
            var image = _context.ProductImage
                .Single(s => s.Id == id);
            return image;
        }

        public void Update(ProductImage modifiedProduct)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            var employee = _context.ProductImage
                .Single(s => s.Id == id);
            employee.IsDeleted = true;
            _context.SaveChanges();
        }

        public IEnumerable<ProductImage> GetByStr(string searchStr)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ProductImage> GetAll()
        {
            return _context.ProductImage.Where(x => x.IsDeleted == false).ToList();
        }

        public IEnumerable<ProductImage> GetByProductId(int productId)
        {
            return _context.ProductImage.Where(x => x.Product == productId).ToList();
        }

    }
}