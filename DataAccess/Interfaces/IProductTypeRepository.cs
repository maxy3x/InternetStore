using System.Collections.Generic;
using Domain.Models;
using Domain.Models.Enumerations;

namespace DataAccess.Interfaces
{
    public interface IProductTypeRepository
    {
        void Insert(ProductType item);
        ProductType GetById(int? id);
        void Update(ProductType modifiedProduct);
        void Delete(int id);
        List<ProductType> GetByStr(string searchStr);
        IEnumerable<ProductType> GetAll();
        IEnumerable<ProductType> GetAllAvailable();
    }
}