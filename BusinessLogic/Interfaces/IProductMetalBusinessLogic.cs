using System.Collections.Generic;
using Domain.Models;

namespace BusinessLogic.Interfaces
{
    public interface IProductMetalBusinessLogic
    {
        void Insert(ProductMetal item);
        ProductMetal GetById(int? id);
        void Update(ProductMetal modifiedItem);
        void Delete(int id);
        List<ProductMetal> GetByStr(string searchStr);
        IEnumerable<ProductMetal> GetAll();
        IEnumerable<ProductMetal> GetAllAvailable();
    }
}