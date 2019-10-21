using Domain.Models;
using System.Collections.Generic;

namespace WebStore.Models.Filters
{
    public class ProductsFilters
    {
        public string Name { get; set; }
        public IEnumerable<ProductColor> ColorList { get; set; }
        public IEnumerable<ProductMetal> MetalList { get; set; }
        public IEnumerable<ProductType> TypeList { get; set; }
        public IEnumerable<ProductStatus> StatusList { get; set; }
        public IEnumerable<ProductAvailabilityStatus> StatusAvList { get; set; }
        public IEnumerable<Gender> GenderList { get; set; }
    }
}