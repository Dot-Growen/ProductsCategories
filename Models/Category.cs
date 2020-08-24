using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductsCategories.Models {
    public class Category {
        [Key]
        public int CategoryId { get; set; }

        [Required (ErrorMessage = "Enter a name")]
        public string Name { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        
        List<Association> AllProducts { get; set; }
    }

}