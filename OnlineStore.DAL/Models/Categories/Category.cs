using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using OnlineStore.DAL.Models.Products;

namespace OnlineStore.DAL.Models.Categories
{
    [Table(nameof(Category))]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        //public bool IsMainCategory { get; set; }

        //[ForeignKey(nameof(Subcategories))]
        public int? CategoryId { get; set; }
        public Category MainCategory { get; set; }

        public virtual ICollection<Category> SubCategories { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
