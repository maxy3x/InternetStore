using System.Collections.Generic;
using Domain.Models.Enumerations;

namespace Domain.Models
{
    public class Product : Nomenclature
    {
        public int Gender { get; set; }
        public int ProductStatus { get; set; }
        public int AvailabilityStatus { get; set; }
    }
}