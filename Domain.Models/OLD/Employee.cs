﻿using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Domain.Models
{
    public class Employee : DeletableEntity
    {
        [Required]
        public String Name { get; set; }
        [Required]
        public String FirstName { get; set; }
        [Required]
        public String SecondName { get; set; }
        public long Okpo { get; set; }
        public string Patronymic { get; set; }
        [Required]
        public string User { get; set; }
    }
}