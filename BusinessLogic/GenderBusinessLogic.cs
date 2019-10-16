using System.Collections.Generic;
using BusinessLogic.Interfaces;
using DataAccess.Interfaces;
using Domain.Models;

namespace BusinessLogic
{
    public class GenderBusinessLogic : IGenderBusinessLogic

    {
        private readonly IGenderRepository _repository;
        public GenderBusinessLogic(IGenderRepository repository)
        {
            _repository = repository;
        }
        public void Insert(Gender item)
        {
            _repository.Insert(item);
        }

        public Gender GetById(int? id)
        {
            return _repository.GetById(id);
        }

        public void Update(Gender modifiedItem)
        {
            _repository.Update(modifiedItem);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<Gender> GetByStr(string searchStr)
        {
            return _repository.GetByStr(searchStr);
        }

        public IEnumerable<Gender> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<Gender> GetAllAvailable()
        {
            return _repository.GetAllAvailable();
        }
    }
}