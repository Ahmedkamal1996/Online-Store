using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineStore.BLL.ViewModels.Category
{
    public class CreateCategoryViewModel
    {
        [Required(ErrorMessage = "Category Name is required")]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsMainCategory { get; set; }

        [Display(Name = "Select Main Category")]
        public int? CategoryId { get; set; }
        public ICollection<GetCategoryViewModel> MainCategory { get; set; }
    }
}