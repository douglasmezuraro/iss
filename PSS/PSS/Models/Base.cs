﻿using System.ComponentModel.DataAnnotations;

namespace PSS.Models
{
    public abstract class Base
    {
        [Key][ScaffoldColumn(false)]
        public virtual int Id { get; set; }

        [ScaffoldColumn(false)]
        public bool IsActive { get; set; } = true;
    }
}