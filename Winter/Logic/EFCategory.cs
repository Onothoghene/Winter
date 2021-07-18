using Winter.Services;
using Winter.ViewModels.Edit_Models;
using Winter.ViewModels.Input_Models;
using Winter.ViewModels.Output_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Winter.ILogic;
using System.Transactions;
using Winter.Models;

namespace Winter.Logic
{
    public class EFCategory : ICategory
    {
        private readonly WinterContext _context;
        readonly ModelFactory _modelFactory = new ModelFactory();

        public EFCategory(WinterContext context)
        {
            _context = context;
        }

        public bool AddCategory(CategoryInputViewModel model)
        {
            try
            {
                var category = _modelFactory.Parse(model);
                _context.Category.Add(category);
                int bit = _context.SaveChanges();

                if (bit > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<CategoryOutputViewModel> GetCategory()
        {
            try
            {
                var category = _context.Category.ToList();
                var resp = category.Select(x => _modelFactory.Create(x));

                return resp;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public CategoryOutputViewModel GetCategoryById(int Id)
        {
            try
            {
                var category = _context.Category.Find(Id);
                var resp = _modelFactory.Create(category);

                return resp;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteCategory(int Id)
        {
            try
            {
                var category = _context.Category.Find(Id);
                if (category != null)
                {
                    _context.Category.Remove(category);
                    _context.SaveChanges();

                    return true;
                }
                return false;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool UpdateCategory(CategoryEditViewModel model)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var category = _context.Category.Find(model.CategoryId);

                    if (category != null)
                    {
                        category.CategoryName = model.CategoryName;
                        category.Id = model.CategoryId;
                        category.Description = model.Description;
                        category.DateModified = DateTime.Now;
                        _context.SaveChanges();

                        ts.Complete();
                        return true;
                    }

                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //public int CountCategory(CategoryOutputViewModel model)
        //{
        //    //var count = db.Activities.Cart(c => c.UserName == "dd").ToList().Count;

        //    //var count = _context.Category.ToList().Count();

        //    model.count = _context.Category.ToList().Count();
        //    return model.count;
        //}

        public long CountCategory()
        {
            try
            {
                var count = _context.Category.ToList().Count();
                return count;
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
