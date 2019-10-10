using System.Collections.Generic;
using BusinessLogic.Interfaces;
using DataAccess;
using DataAccess.Interfaces;
using Domain.Models;
using Domain.Models.Enumerations;

namespace BusinessLogic
{
    public class ProductBusinessLogic : IProductBusinessLogic
    {
        private readonly IProductRepository _repository;
        public ProductBusinessLogic(IProductRepository repository)
        {
            _repository = repository;
        }
        public void Insert(Product item)
        {
            _repository.Insert(item);
        }

        public Product GetById(int? id)
        {
            return _repository.GetById(id);
        }

        public void Update(Product modifiedItem)
        {
            _repository.Update(modifiedItem);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<Product> GetByStr(string searchStr)
        {
            return _repository.GetByStr(searchStr);
        }

        public IEnumerable<Product> GetAll()
        {
            return _repository.GetAll();
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