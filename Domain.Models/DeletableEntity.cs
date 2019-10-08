﻿using Domain.Models.Interfaces;

namespace Domain.Models
{
    public class DeletableEntity : IdEntity
    {
        public bool IsDeleted { get; set; }
    }
}