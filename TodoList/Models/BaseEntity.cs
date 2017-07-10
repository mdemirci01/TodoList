using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TodoList.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime CreateDate { get; set; }
        public string CreatedBy { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime UpdateDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}