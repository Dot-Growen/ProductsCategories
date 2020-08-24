using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductsCategories.Models {
    public class Product {
        [Key]
        public int ProductId { get; set; }

        [Required (ErrorMessage = "Enter a name")]
        public string Name { get; set; }

        [Required (ErrorMessage = "Enter a Description")]
        public string Description { get; set; }

        [Required (ErrorMessage = "Enter a Price")]
        public decimal Price { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        List<Association> AllCategories { get; set; }
    }

}