using System.ComponentModel.DataAnnotations;

namespace ProductsCategories.Models {
    public class Association {
        [Key]
        public int AssociationId { get; set; }

        public int CategoryId { get; set; }

        public Category CatgoryInProduct { get; set; }

        public int ProductId { get; set; }

        public Product ProductInCategory { get; set; }

    }

}