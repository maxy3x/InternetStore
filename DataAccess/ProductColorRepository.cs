using System.Collections.Generic;
using System.Linq;
using DataAccess.Context;
using DataAccess.Interfaces;
using Domain.Models;

namespace DataAccess
{
    public class ProductColorRepository : IProductColorRepository
    {
        private readonly WebStoreDbContext _context;

        public ProductColorRepository(WebStoreDbContext context)
        {
            _context = context;
        }
        public void Insert(ProductColor item)
        {
            ProductColor newItem = new ProductColor()
            {
                Name = item.Name,
                IsDeleted = false
            };
            _context.ProductColor.Add(newItem);
            _context.SaveChanges();
        }

        public ProductColor GetById(int? id)
        {
            var productColor = _context.ProductColor
                .Single(s => s.Id == id);
            return productColor;
        }

        public void Update(ProductColor modifiedItem)
        {
            _context.ProductColor.Update(modifiedItem);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var productColor = _context.ProductColor
                .Single(s => s.Id == id);
            productColor.IsDeleted = true;
            _context.SaveChanges();
        }

        public List<ProductColor> GetByStr(string searchStr)
        {
            return _context.ProductColor.Where(c => c.Name.Contains(searchStr)).ToList();
        }
        public IEnumerable<ProductColor> GetAllAvailable()
        {
            return _context.ProductColor.Where(x => x.IsDeleted == false).ToList();
        }
        public IEnumerable<ProductColor> GetAll()
        {
            return _context.ProductColor.ToList();
        }
    }
}