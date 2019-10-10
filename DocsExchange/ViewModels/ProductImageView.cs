using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebStore.ViewModels
{
    public class ProductImageView
    {
        public int Id { get; set; }
        [DisplayName("Видалити")]
        public bool IsDeleted { get; set; }
        [DisplayName("Повідомлення")]
        public String Message { get; set; }
        [DisplayName("Товар")]
        public int Product { get; set; }
        [DisplayName("Ім'я файлу")]
        public string Name { get; set; }
        [Required]
        public string Path { get; set; }
    }
}