using System.Collections.Generic;
using Domain.Models;

namespace BusinessLogic.Interfaces
{
    public interface IProductBusinessLogic
    {
        void Insert(Product item);
        Product GetById(int? id);
        void Update(Product modifiedProduct);
        void Delete(int id);
        List<Product> GetByStr(string searchStr);
        IEnumerable<Product> GetAll();
        IEnumerable<Product> GetAllActive();
        IEnumerable<Product> GetByProductType(ProductType productType);
        IEnumerable<Product> GetByProductColor(ProductColor productColor);
        IEnumerable<Product> GetByProductMetal(ProductMetal productMetal);
        IEnumerable<Product> GetByProductStatus(ProductStatus productStatus);
        IEnumerable<Product> GetAllAvailable(ProductAvailabilityStatus productAvailability);
        IEnumerable<Product> GetByGender(Gender gender);
    }
}