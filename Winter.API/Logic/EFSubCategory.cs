using Winter.API.Logic.Interfaces;

namespace Winter.API.Logic
{
    public class EFSubCategory : ISubCategory
    {
        //private readonly WinterContext _context;
        //ModelFactory _modelFactory = new ModelFactory();

        //public EFSubCategory(WinterContext context)
        //{
        //    _context = context;
        //}

        //public bool AddSubCategory(CategoryInputViewModel model)
        //{
        //    try
        //    {
        //        var category = _modelFactory.Parse(model);
        //        _context.Category.Add(category);
        //        int bit = _context.SaveChanges();

        //        if (bit > 0)
        //            return true;
        //        else
        //            return false;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //public IEnumerable<CategoryOutputViewModel> GetSubCategory()
        //{

        //    var category = _context.Category.ToList();
        //    var resp = category.Select(x => _modelFactory.Create(x));

        //    return resp;
        //}

        //public CategoryOutputViewModel GetSubCategoryById(int Id)
        //{
        //    var category = _context.Category.Find(Id);
        //    var resp = _modelFactory.Create(category);

        //    return resp;
        //}

        //public bool DeleteSubCategory(int Id)
        //{
        //    try
        //    {
        //        var data = _context.SubCategory.Find(Id);
        //        if (data != null)
        //        {
        //            _context.SubCategory.Remove(data);
        //            _context.SaveChanges();

        //            return true;
        //        }
        //        return false;

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //public bool UpdateSubCategory(CategoryEditViewModel model)
        //{
        //    try
        //    {
        //        using (TransactionScope ts = new TransactionScope())
        //        {
        //            var category = _context.Category.Find(model.CategoryId);

        //            if (category != null)
        //            {
        //                category.CategoryName = model.CategoryName;
        //                category.Id = model.CategoryId;
        //                category.Description = model.Description;
        //                category.DateModified = DateTime.Now;
        //                _context.SaveChanges();

        //                ts.Complete();
        //                return true;
        //            }

        //            return false;
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //public long CountSubCategory()
        //{
        //    try
        //    {
        //        var count = _context.SubCategory.ToList().Count();
        //        return count;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //}

    }
}
