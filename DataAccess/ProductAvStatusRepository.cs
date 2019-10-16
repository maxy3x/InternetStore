using System.Collections.Generic;
using System.Linq;
using DataAccess.Context;
using DataAccess.Interfaces;
using Domain.Models;

namespace DataAccess
{
    public class ProductAvStatusRepository : IProductAvStatusRepository
    {
        private readonly WebStoreDbContext _context;

        public ProductAvStatusRepository(WebStoreDbContext context)
        {
            _context = context;
        }
        public void Insert(ProductAvailabilityStatus item)
        {
            ProductAvailabilityStatus newItem = new ProductAvailabilityStatus()
            {
                Name = item.Name,
                IsDeleted = false
            };
            _context.ProductAvailabilityStatus.Add(newItem);
            _context.SaveChanges();
        }

        public ProductAvailabilityStatus GetById(int? id)
        {
            var poductAvStatus = _context.ProductAvailabilityStatus
                .Single(s => s.Id == id);
            return poductAvStatus;
        }

        public void Update(ProductAvailabilityStatus modifiedItem)
        {
            _context.ProductAvailabilityStatus.Update(modifiedItem);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var poductAvStatus = _context.ProductAvailabilityStatus
                .Single(s => s.Id == id);
            poductAvStatus.IsDeleted = true;
            _context.SaveChanges();
        }

        public List<ProductAvailabilityStatus> GetByStr(string searchStr)
        {
            return _context.ProductAvailabilityStatus.Where(c => c.Name.Contains(searchStr)).ToList();
        }
        public IEnumerable<ProductAvailabilityStatus> GetAllAvailable()
        {
            return _context.ProductAvailabilityStatus.Where(x => x.IsDeleted == false).ToList();
        }
        public IEnumerable<ProductAvailabilityStatus> GetAll()
        {
            return _context.ProductAvailabilityStatus.ToList();
        }
    }
}