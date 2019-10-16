using System.Collections.Generic;
using Domain.Models;

namespace BusinessLogic.Interfaces
{
    public interface IGenderBusinessLogic
    {
        void Insert(Gender item);
        Gender GetById(int? id);
        void Update(Gender modifiedItem);
        void Delete(int id);
        List<Gender> GetByStr(string searchStr);
        IEnumerable<Gender> GetAll();
        IEnumerable<Gender> GetAllAvailable();
    }
}