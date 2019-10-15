using System.Collections.Generic;
using Domain.Models;

namespace DataAccess.Interfaces
{
    public interface IProductColorRepository
    {
        void Insert(ProductColor item);
        ProductColor GetById(int? id);
        void Update(ProductColor modifiedProduct);
        void Delete(int id);
        List<ProductColor> GetByStr(string searchStr);
        IEnumerable<ProductColor> GetAll();
        IEnumerable<ProductColor> GetAllAvailable();
    }
}