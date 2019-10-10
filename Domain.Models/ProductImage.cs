using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class ProductImage : DeletableEntity
    {
        public int Product { get; set; }
        public string Name { get; set; }
        [Required]
        public string Path { get; set; }
    }
}