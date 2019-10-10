﻿using System.Collections.Generic;
using Domain.Models;

namespace DataAccess.Interfaces
{
    public interface IProductImageRepository
    {
        void Insert(ProductImage item);
        void InsertFew(IEnumerable<ProductImage> items);
        ProductImage GetById(int id);
        void Update(ProductImage modifiedProduct);
        void Delete(int id);
        IEnumerable<ProductImage> GetByStr(string searchStr);
        IEnumerable<ProductImage> GetAll();
        IEnumerable<ProductImage> GetByProductId(int productId);
    }
}