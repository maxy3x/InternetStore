using System.Collections.Generic;
using Domain.Models;

namespace BusinessLogic.Interfaces
{
    public interface IProductStatusBusinessLogic
    {
        void Insert(ProductStatus item);
        ProductStatus GetById(int? id);
        void Update(ProductStatus modifiedItem);
        void Delete(int id);
        List<ProductStatus> GetByStr(string searchStr);
        IEnumerable<ProductStatus> GetAll();
        IEnumerable<ProductStatus> GetAllAvailable();
    }
}