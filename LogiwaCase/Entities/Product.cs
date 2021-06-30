using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LogiwaCase.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [Required,MaxLength(200)]
        public string Title { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public int? CategoryId { get; set; }
        public int Stock { get; set; }
    }
}
