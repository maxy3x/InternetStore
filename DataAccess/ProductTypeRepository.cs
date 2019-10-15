using System.Collections.Generic;
using System.Linq;
using DataAccess.Context;
using DataAccess.Interfaces;
using Domain.Models;

namespace DataAccess
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly WebStoreDbContext _context;

        public ProductTypeRepository(WebStoreDbContext context)
        {
            _context = context;
        }
        public void Insert(ProductType item)
        {
            ProductType newItem = new ProductType()
            {
                Name = item.Name,
                IsDeleted = false
            };
            _context.ProductType.Add(newItem);
            _context.SaveChanges();
        }

        public ProductType GetById(int? id)
        {
            var poductType = _context.ProductType
                .Single(s => s.Id == id);
            return poductType;
        }

        public void Update(ProductType modifiedItem)
        {
            _context.ProductType.Update(modifiedItem);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var productType = _context.ProductType
                .Single(s => s.Id == id);
            productType.IsDeleted = true;
            _context.SaveChanges();
        }

        public List<ProductType> GetByStr(string searchStr)
        {
            return _context.ProductType.Where(c => c.Name.Contains(searchStr)).ToList();
        }
        public IEnumerable<ProductType> GetAllAvailable()
        {
            return _context.ProductType.Where(x => x.IsDeleted == false).ToList();
        }
        public IEnumerable<ProductType> GetAll()
        {
            return _context.ProductType.ToList();
        }
    }
}