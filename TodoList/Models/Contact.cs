using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TodoList.Models
{
    public class Contact:BaseEntity
    {
        [StringLength(200)]
        [Required(ErrorMessage = "Ad alanı gereklidir.")]
        [DisplayName("Ad")]
        public string FirstName { get; set; }
        [StringLength(200)]
        [Required(ErrorMessage = "Soyad alanı gereklidir.")]
        [DisplayName("Soyad")]
        public string LastName { get; set; }
        [StringLength(200)]
        [DisplayName("E-posta")]
        public string Email { get; set; }
        [StringLength(200)]
        [DisplayName("Telefon")]
        public string Phone { get; set; }
        [DisplayName("Yapılacaklar")]
        public virtual ICollection<TodoItem> TodoItems { get; set; }        
    }
}