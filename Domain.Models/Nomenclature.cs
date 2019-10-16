using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Nomenclature : DeletableEntity
    {
        [Required]
        public string Name { get; set; }
        public int ProductType { get; set; }
        public float Weight { get; set; }
        public float Price { get; set; }
        public float Amount { get; set; }
        public int ProductColor { get; set; }
        public int ProductMetal { get; set; }
    }
}