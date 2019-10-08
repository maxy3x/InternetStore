using System.Collections.Generic;
using Domain.Models;

namespace DataAccess.Interfaces
{
    public interface IProductImagesRepository
    {
        void Insert(ProductImage item);
        ProductImage GetById(int? id);
        void Update(ProductImage modifiedImage);
        void Delete(int id);
        IEnumerable<ProductImage> GetByProductId(int productId);
    }
}