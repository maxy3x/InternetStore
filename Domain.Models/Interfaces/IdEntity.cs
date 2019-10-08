using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Interfaces
{
    public class IdEntity : IEntity
    {
        [Key]
        public int Id { get; set; }
    }
}