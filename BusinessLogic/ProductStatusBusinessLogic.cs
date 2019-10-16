using System.Collections.Generic;
using BusinessLogic.Interfaces;
using DataAccess.Interfaces;
using Domain.Models;

namespace BusinessLogic
{
    public class ProductStatusBusinessLogic : IProductStatusBusinessLogic
    {
        private readonly IProductStatusRepository _repository;
        public ProductStatusBusinessLogic(IProductStatusRepository repository)
        {
            _repository = repository;
        }
        public void Insert(ProductStatus item)
        {
            _repository.Insert(item);
        }

        public ProductStatus GetById(int? id)
        {
            return _repository.GetById(id);
        }

        public void Update(ProductStatus modifiedItem)
        {
            _repository.Update(modifiedItem);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<ProductStatus> GetByStr(string searchStr)
        {
            return _repository.GetByStr(searchStr);
        }

        public IEnumerable<ProductStatus> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<ProductStatus> GetAllAvailable()
        {
            return _repository.GetAllAvailable();
        }
    }
}