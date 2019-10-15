using System.Collections.Generic;
using System.Linq;
using DataAccess.Context;
using DataAccess.Interfaces;
using Domain.Models;

namespace DataAccess
{
    public class ProductMetalRepository : IProductMetalRepository
    {
        private readonly WebStoreDbContext _context;

        public ProductMetalRepository(WebStoreDbContext context)
        {
            _context = context;
        }
        public void Insert(ProductMetal item)
        {
            ProductMetal newItem = new ProductMetal()
            {
                Name = item.Name,
                IsDeleted = false
            };
            _context.ProductMetal.Add(newItem);
            _context.SaveChanges();
        }

        public ProductMetal GetById(int? id)
        {
            var poductMetal = _context.ProductMetal
                .Single(s => s.Id == id);
            return poductMetal;
        }

        public void Update(ProductMetal modifiedItem)
        {
            _context.ProductMetal.Update(modifiedItem);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var poductMetal = _context.ProductMetal
                .Single(s => s.Id == id);
            poductMetal.IsDeleted = true;
            _context.SaveChanges();
        }

        public List<ProductMetal> GetByStr(string searchStr)
        {
            return _context.ProductMetal.Where(c => c.Name.Contains(searchStr)).ToList();
        }
        public IEnumerable<ProductMetal> GetAllAvailable()
        {
            return _context.ProductMetal.Where(x => x.IsDeleted == false).ToList();
        }
        public IEnumerable<ProductMetal> GetAll()
        {
            return _context.ProductMetal.ToList();
        }
    }
}