using System.Collections.Generic;
using DataAccess.Interfaces;
using Domain.Models;
using Domain.Models.Enumerations;

namespace DataAccess
{
    public class ProductRepository : IProductRepository
    {
        public void Insert(Product item)
        {
            throw new System.NotImplementedException();
        }

        public Product GetById(int? id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Product modifiedProduct)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Product> GetByStr(string searchStr)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Product> GetByProductType(ProductType productType)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Product> GetByProductColor(ProductColor productColor)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Product> GetByProductMetal(ProductMetal productMetal)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Product> GetByProductStatus(ProductStatus productStatus)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Product> GetAllAvailable(ProductAvailabilityStatus productAvailability)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Product> GetByGender(Gender gender)
        {
            throw new System.NotImplementedException();
        }
    }
}