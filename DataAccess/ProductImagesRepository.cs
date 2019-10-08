using System.Collections.Generic;
using DataAccess.Interfaces;
using Domain.Models;

namespace DataAccess
{
    public class ImagesRepository : IProductImagesRepository
    {
        public void Insert(ProductImage item)
        {
            throw new System.NotImplementedException();
        }

        public ProductImage GetById(int? id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(ProductImage modifiedImage)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ProductImage> GetByProductId(int productId)
        {
            throw new System.NotImplementedException();
        }
    }
}