using System.Collections.Generic;
using OnlineStore.BLL.ViewModels.Category;

namespace OnlineStore.BLL.Services.Categories
{
    public interface ICategoriesService
    {
        ICollection<GetCategoryViewModel> GetCategoriesByName(string textSearch);
        ICollection<GetCategoryViewModel> GetCategories();

        ICollection<GetCategoryViewModel> GetMCategoriesForUpdateModel(int updatedCategoryId);

        GetCategoryViewModel GetCategoryById(int id);
        GetCategoryViewModel Add(CreateCategoryViewModel model);
        bool Update(UpdateCategoryViewModel model);
        bool Delete(int categoryId);
    }
}
