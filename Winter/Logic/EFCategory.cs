using Winter.Data;
using Winter.Services;
using Winter.ViewModels.Edit_Models;
using Winter.ViewModels.Input_Models;
using Winter.ViewModels.Output_Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Winter.Logic
{
    public class EFCategory : ICategory
    {
        private readonly WinterContext _context;
        private readonly ModelFactory _modelFactory;

        public int AddCategory(CategoryInputViewModel model)
        {
            var category = _modelFactory.Parse(model);
            _context.Category.Add(category);
            _context.SaveChanges();

            return category.Id;
        }

        public IEnumerable<CategoryOutputViewModel> GetCategory()
        {

            var category = _context.Category.ToList();
            var resp = category.Select(x => _modelFactory.Create(x));

            return resp;
        }

        public CategoryOutputViewModel GetCategoryById(int? Id)
        {
            var category = _context.Category.Find(Id);
            var resp = _modelFactory.Create(category);

            return resp;
        }

        public bool DeleteCategory(int? Id)
        {
            var category = _context.Category.Find(Id);
            _context.Category.Remove(category);
            _context.SaveChanges();

            return true;
        }

        public bool UpdateCategory(CategoryEditViewModel model)
        {
            var category = _context.Category.Find(model.CategoryId);

            if (category != null)
            {
                category.CategoryName = model.CategoryName;
                category.Id = model.CategoryId;
                category.Description = model.Description;
                category.DateModified = DateTime.Now;
                _context.SaveChanges();
            }

            return true;
        }
    }
}
