using System.Collections.Generic;
using BusinessLogic.Interfaces;
using DataAccess.Interfaces;
using Domain.Models;

namespace BusinessLogic
{
    public class ProductAvStatusBusinessLogic : IProductAvStatusBusinessLogic
    {
        private readonly IProductAvStatusRepository _repository;
        public ProductAvStatusBusinessLogic(IProductAvStatusRepository repository)
        {
            _repository = repository;
        }
        public void Insert(ProductAvailabilityStatus item)
        {
            _repository.Insert(item);
        }

        public ProductAvailabilityStatus GetById(int? id)
        {
            return _repository.GetById(id);
        }

        public void Update(ProductAvailabilityStatus modifiedItem)
        {
            _repository.Update(modifiedItem);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<ProductAvailabilityStatus> GetByStr(string searchStr)
        {
            return _repository.GetByStr(searchStr);
        }

        public IEnumerable<ProductAvailabilityStatus> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<ProductAvailabilityStatus> GetAllAvailable()
        {
            return _repository.GetAllAvailable();
        }
    }
}