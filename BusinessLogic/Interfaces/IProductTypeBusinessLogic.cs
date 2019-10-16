using System.Collections.Generic;
using Domain.Models;

namespace BusinessLogic.Interfaces
{
    public interface IProductTypeBusinessLogic
    {
        void Insert(ProductType item);
        ProductType GetById(int? id);
        void Update(ProductType modifiedItem);
        void Delete(int id);
        List<ProductType> GetByStr(string searchStr);
        IEnumerable<ProductType> GetAll();
        IEnumerable<ProductType> GetAllAvailable();
        
    }
}