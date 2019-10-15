using System.Collections.Generic;
using Domain.Models;

namespace BusinessLogic.Interfaces
{
    public interface IProductColorBusinessLogic
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