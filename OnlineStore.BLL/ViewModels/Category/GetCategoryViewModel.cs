using System.Collections.Generic;
using OnlineStore.BLL.ViewModels.Product;

namespace OnlineStore.BLL.ViewModels.Category
{
    public class GetCategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public bool IsMainCategory { get; set; }

        public int? CategoryId { get; set; }
        public GetCategoryViewModel MainCategory { get; set; }

        public ICollection<GetCategoryViewModel> SubCategories { get; set; }
        public ICollection<GetProductViewModel> Products { get; set; }

    }
}