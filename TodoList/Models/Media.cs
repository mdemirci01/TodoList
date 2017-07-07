using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TodoList.Models
{
    public class Media:BaseEntity
    {
        [StringLength(200)]
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [StringLength(200)]
        public string Extension { get; set; }
        [StringLength(200)]
        public string FilePath { get; set; }
        public float FileSize { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
    }
}