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
        public string ProductTypeName { get; set; }
        public int ProductType { get; set; }
        [DisplayName("Вага")]
        public float Weight { get; set; }
        [DisplayName("Ціна")]
        public float Price { get; set; }
        [DisplayName("Кількість")]
        public float Amount { get; set; }
        [DisplayName("Колір")]
        public string ProductColorName { get; set; }
        public int ProductColor { get; set; }
        [DisplayName("Тип металу")]
        public string ProductMetalName { get; set; }
        public int ProductMetal { get; set; }
        [DisplayName("Стать")]
        public string GenderName { get; set; }
        public int GenderId { get; set; }
        [DisplayName("Статус")]
        public string ProductStatusName { get; set; }
        public int ProductStatus { get; set; }
        [DisplayName("Наявність")]
        public int AvailabilityStatus { get; set; }
    }
}