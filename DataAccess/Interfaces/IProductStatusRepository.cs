using System.Collections.Generic;
using Domain.Models;

namespace DataAccess.Interfaces
{
    public interface IProductStatusRepository
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