using System.Collections.Generic;
using Domain.Models;

namespace DataAccess.Interfaces
{
    public interface IGenderRepository
    {
        void Insert(Gender item);
        Gender GetById(int? id);
        void Update(Gender modifiedProduct);
        void Delete(int id);
        List<Gender> GetByStr(string searchStr);
        IEnumerable<Gender> GetAll();
        IEnumerable<Gender> GetAllAvailable();
    }
}