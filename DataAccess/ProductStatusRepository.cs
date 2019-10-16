using System.Collections.Generic;
using System.Linq;
using DataAccess.Context;
using DataAccess.Interfaces;
using Domain.Models;

namespace DataAccess
{
    public class ProductStatusRepository : IProductStatusRepository
    {
        private readonly WebStoreDbContext _context;

        public ProductStatusRepository(WebStoreDbContext context)
        {
            _context = context;
        }
        public void Insert(ProductStatus item)
        {
            ProductStatus newItem = new ProductStatus()
            {
                Name = item.Name,
                IsDeleted = false
            };
            _context.ProductStatus.Add(newItem);
            _context.SaveChanges();
        }

        public ProductStatus GetById(int? id)
        {
            var poductStatus = _context.ProductStatus
                .Single(s => s.Id == id);
            return poductStatus;
        }

        public void Update(ProductStatus modifiedItem)
        {
            _context.ProductStatus.Update(modifiedItem);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var poductStatus = _context.ProductStatus
                .Single(s => s.Id == id);
            poductStatus.IsDeleted = true;
            _context.SaveChanges();
        }

        public List<ProductStatus> GetByStr(string searchStr)
        {
            return _context.ProductStatus.Where(c => c.Name.Contains(searchStr)).ToList();
        }
        public IEnumerable<ProductStatus> GetAllAvailable()
        {
            return _context.ProductStatus.Where(x => x.IsDeleted == false).ToList();
        }
        public IEnumerable<ProductStatus> GetAll()
        {
            return _context.ProductStatus.ToList();
        }
    }
}