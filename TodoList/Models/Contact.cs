using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TodoList.Models
{
    public class Contact:BaseEntity
    {
        [StringLength(200)]
        [Required]
        public string FirstName { get; set; }
        [StringLength(200)]
        [Required]
        public string LastName { get; set; }
        [StringLength(200)]
        public string Email { get; set; }
        [StringLength(200)]
        public string Phone { get; set; }
        public virtual ICollection<TodoItem> TodoItems { get; set; }        
    }
}