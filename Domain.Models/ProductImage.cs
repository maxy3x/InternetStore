namespace Domain.Models
{
    public class ProductImage : DeletableEntity
    {
        public int Product { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
    }
}