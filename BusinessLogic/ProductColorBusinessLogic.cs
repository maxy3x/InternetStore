using System.Collections.Generic;
using BusinessLogic.Interfaces;
using DataAccess.Interfaces;
using Domain.Models;

namespace BusinessLogic
{
    public class ProductColorBusinessLogic : IProductColorBusinessLogic
    {
        private readonly IProductColorRepository _repository;
        public ProductColorBusinessLogic(IProductColorRepository repository)
        {
            _repository = repository;
        }
        public void Insert(ProductColor item)
        {
            _repository.Insert(item);
        }

        public ProductColor GetById(int? id)
        {
            return _repository.GetById(id);
        }

        public void Update(ProductColor modifiedItem)
        {
            _repository.Update(modifiedItem);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<ProductColor> GetByStr(string searchStr)
        {
            return _repository.GetByStr(searchStr);
        }

        public IEnumerable<ProductColor> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<ProductColor> GetAllAvailable()
        {
            return _repository.GetAllAvailable();
        }
    }
}