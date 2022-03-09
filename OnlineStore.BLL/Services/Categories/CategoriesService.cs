using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using OnlineStore.BLL.Exceptions;
using OnlineStore.BLL.ViewModels.Category;
using OnlineStore.DAL.Database;
using OnlineStore.DAL.Models.Categories;

namespace OnlineStore.BLL.Services.Categories
{
    public class CategoriesService : ICategoriesService
    {
        private readonly OnlineStoreDbContext _context;

        public CategoriesService(OnlineStoreDbContext context)
        {
            _context = context;
        }

        public GetCategoryViewModel Add(CreateCategoryViewModel model)
        {
            var isCategoryExist = _context.Categories.Any(x => x.Name.Trim().ToLower() == model.Name.Trim().ToLower());

            if (isCategoryExist)
            {
                throw new CategoryNameAlreadyExistException();
            }

            var category = Mapper.Map<Category>(model);

            _context.Categories.Add(category);

            return _context.SaveChanges() > 0 ? Mapper.Map<GetCategoryViewModel>(category) : null;
        }

        public bool Delete(int categoryId)
        {
            var category = _context.Categories.Find(categoryId);

            if (category == null)
            {
                return false;
            }

            _context.Categories.Remove(category);
            
            return  _context.SaveChanges() > 0;
        }

        public ICollection<GetCategoryViewModel> GetCategories()
        {
            var categories = _context.Categories.ToList();

            return Mapper.Map<ICollection<GetCategoryViewModel>>(categories);
        }

        public ICollection<GetCategoryViewModel> GetMCategoriesForUpdateModel(int updatedCategoryId)
        {
            //var categories = _context.Categories.Where(x=>!x.CategoryId.HasValue).ToList();
            var categories = _context.Categories.Where(x=>x.Id!=updatedCategoryId).ToList();

            return Mapper.Map<ICollection<GetCategoryViewModel>>(categories);
        }

        public ICollection<GetCategoryViewModel> GetCategoriesByName(string textSearch)
        {
            if(string.IsNullOrWhiteSpace(textSearch))
            {
                return null;
            }

            var searchTerm = textSearch.Trim().ToLower();

            var categories = _context.Categories.Where(x=>x.Name.Trim().ToLower().Contains(searchTerm)).ToList();

            return Mapper.Map<ICollection<GetCategoryViewModel>>(categories);

            //return categories.Select(category => new GetCategoryViewModel
            //{
            //    Name = category.Name,
            //    Description = category.Description
            //}).ToList();
        }

        public GetCategoryViewModel GetCategoryById(int id)
        {
            var category = _context.Categories.Find(id);

            return category == null ? null : Mapper.Map<GetCategoryViewModel>(category);
        }

        public bool Update(UpdateCategoryViewModel model)
        {
            var oldCategory = _context.Categories.Find(model.Id);

            if (oldCategory == null)
            {
                return false;
            }

            Mapper.Map(model, oldCategory);

            _context.Entry(oldCategory).State = EntityState.Modified;

            return _context.SaveChanges() > 0;
        }
    }
}
