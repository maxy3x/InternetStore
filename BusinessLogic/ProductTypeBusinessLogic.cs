using System.Collections.Generic;
using BusinessLogic.Interfaces;
using DataAccess.Interfaces;
using Domain.Models;

namespace BusinessLogic
{
    public class ProductTypeBusinessLogic : IProductTypeBusinessLogic
    {
        private readonly IProductTypeRepository _repository;
        public ProductTypeBusinessLogic(IProductTypeRepository repository)
        {
            _repository = repository;
        }
        public void Insert(ProductType item)
        {
            _repository.Insert(item);
        }

        public ProductType GetById(int? id)
        {
            return _repository.GetById(id);
        }

        public void Update(ProductType modifiedItem)
        {
            _repository.Update(modifiedItem);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<ProductType> GetByStr(string searchStr)
        {
            return _repository.GetByStr(searchStr);
        }

        public IEnumerable<ProductType> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<ProductType> GetAllAvailable()
        {
            return _repository.GetAllAvailable();
        }
    }
}