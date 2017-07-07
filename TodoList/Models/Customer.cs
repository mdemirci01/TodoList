using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TodoList.Models
{
    public class Customer:BaseEntity
    {
        [StringLength(200)]
        [Required]
        public string Name { get; set; }
        [StringLength(200)]
        public string Email { get; set; }
        [StringLength(200)]
        public string Phone { get; set; }
        [StringLength(200)]
        public string Fax { get; set; }
        [StringLength(200)]
        public string Website { get; set; }
        [StringLength(4000)]
        public string Address { get; set; }
        public virtual ICollection<TodoItem> TodoItems { get; set; }

    }
}