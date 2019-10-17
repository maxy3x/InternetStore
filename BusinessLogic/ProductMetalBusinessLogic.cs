using System.Collections.Generic;
using BusinessLogic.Interfaces;
using DataAccess.Interfaces;
using Domain.Models;

namespace BusinessLogic
{
    public class ProductMetalBusinessLogic : IProductMetalBusinessLogic
    {
        private readonly IProductMetalRepository _repository;
        public ProductMetalBusinessLogic(IProductMetalRepository repository)
        {
            _repository = repository;
        }
        public void Insert(ProductMetal item)
        {
            _repository.Insert(item);
        }

        public ProductMetal GetById(int? id)
        {
            if (id == null)
                return null;
            return _repository.GetById(id);
        }

        public void Update(ProductMetal modifiedItem)
        {
            _repository.Update(modifiedItem);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<ProductMetal> GetByStr(string searchStr)
        {
            return _repository.GetByStr(searchStr);
        }

        public IEnumerable<ProductMetal> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<ProductMetal> GetAllAvailable()
        {
            return _repository.GetAllAvailable();
        }
    }
}