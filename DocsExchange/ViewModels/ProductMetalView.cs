using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebStore.ViewModels
{
    public class ProductMetalView
    {
        public int Id { get; set; }
        [DisplayName("Видалити")]
        public bool IsDeleted { get; set; }
        [DisplayName("Повідомлення")]
        public String Message { get; set; }
        [Required]
        [DisplayName("Назва")]
        public string Name { get; set; }
    }
}
