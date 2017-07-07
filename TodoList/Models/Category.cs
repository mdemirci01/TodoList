using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TodoList.Models
{
    public class Category:BaseEntity
    {
        [StringLength(200)]
        [Required]
        public string Name { get; set; }

        public virtual ICollection<TodoItem> TodoItems { get; set; }
    }
}