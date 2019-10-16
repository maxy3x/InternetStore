using System.Collections.Generic;
using Domain.Models;

namespace BusinessLogic.Interfaces
{
    public interface IProductAvStatusBusinessLogic
    {
        void Insert(ProductAvailabilityStatus item);
        ProductAvailabilityStatus GetById(int? id);
        void Update(ProductAvailabilityStatus modifiedItem);
        void Delete(int id);
        List<ProductAvailabilityStatus> GetByStr(string searchStr);
        IEnumerable<ProductAvailabilityStatus> GetAll();
        IEnumerable<ProductAvailabilityStatus> GetAllAvailable();
    }
}