using System.Collections.Generic;
using Domain.Models;

namespace DataAccess.Interfaces
{
    public interface IProductMetalRepository
    {
        void Insert(ProductMetal item);
        ProductMetal GetById(int? id);
        void Update(ProductMetal modifiedProduct);
        void Delete(int id);
        List<ProductMetal> GetByStr(string searchStr);
        IEnumerable<ProductMetal> GetAll();
        IEnumerable<ProductMetal> GetAllAvailable();
    }
}