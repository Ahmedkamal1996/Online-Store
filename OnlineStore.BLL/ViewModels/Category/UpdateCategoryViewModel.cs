using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.BLL.ViewModels.Category
{
    public class UpdateCategoryViewModel
    {
        [Required(ErrorMessage = "Category Id is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Category Name is required")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name = "Select Main Category")]
        public int? CategoryId { get; set; }
        public ICollection<GetCategoryViewModel> MainCategory { get; set; }
    }
}