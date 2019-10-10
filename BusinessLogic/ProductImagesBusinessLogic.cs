using System.Collections.Generic;
using BusinessLogic.Interfaces;
using DataAccess.Interfaces;
using Domain.Models;

namespace BusinessLogic
{
    public class ProductImagesBusinessLogic : IProductImagesBusinessLogic
    {
        private readonly IProductImageRepository _repository;
        public ProductImagesBusinessLogic(IProductImageRepository repository)
        {
            _repository = repository;
        }
        public void Insert(ProductImage item)
        {
            _repository.Insert(item);
        }

        public void InsertFew(IEnumerable<ProductImage> items)
        {
            throw new System.NotImplementedException();
        }

        public ProductImage GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Update(ProductImage modifiedItem)
        {
            _repository.Update(modifiedItem);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IEnumerable<ProductImage> GetByStr(string searchStr)
        {
            return _repository.GetByStr(searchStr);
        }

        public IEnumerable<ProductImage> GetAll()
        {
            return _repository.GetAll();
        }

        public IEnumerable<ProductImage> GetByProductId(int productId)
        {
            return _repository.GetByProductId(productId);
        }
    }
}