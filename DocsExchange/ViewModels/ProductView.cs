using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebStore.ViewModels
{
    public class ProductView
    {
        public int Id { get; set; }
        [DisplayName("Видалити")]
        public bool IsDeleted { get; set; }
        [DisplayName("Повідомлення")]
        public String Message { get; set; }
        [Required]
        [DisplayName("Назва")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Тип")]
        public int ProductType { get; set; }
        [DisplayName("Вага")]
        public float Weight { get; set; }
        [DisplayName("Ціна")]
        public float Price { get; set; }
        [DisplayName("Кількість")]
        public float Amount { get; set; }
        [DisplayName("Колір")]
        public int ProductColor { get; set; }
        [DisplayName("Тип металу")]
        public int ProductMetal { get; set; }
        [DisplayName("Стать")]
        public int Gender { get; set; }
        [DisplayName("Статус")]
        public int ProductStatus { get; set; }
        [DisplayName("Наявність")]
        public int AvailabilityStatus { get; set; }
    }
}