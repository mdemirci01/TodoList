﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TodoList.Models
{
    public class Side : BaseEntity
    {
        [StringLength(200)]
        [Required(ErrorMessage = "Ad alanı gereklidir.")]
        [DisplayName("Ad")]
        public string Name { get; set; }
        [DisplayName("Yapılacaklar")]
        public virtual ICollection<TodoItem> TodoItems { get; set; }
    }
}