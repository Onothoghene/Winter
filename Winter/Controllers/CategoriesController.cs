using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Winter.Data;
using Winter.ILogic;

namespace Winter.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategory _category;

        public CategoriesController(ICategory category)
        {
            _category = category;
        }

        [Route("category/index")]
        public async Task<IActionResult> Index()
        {
            try
            {
                var data = await Task.Run(() => _category.GetCategory());
                return View(data);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("category/detail")]
        public async Task<IActionResult> Details(int categoryId)
        {
            try
            {
                if (categoryId > 0)
                {
                    var category = await Task.Run(() => _category.GetCategoryById(categoryId));
                    return View(category);
                }
                return NotFound();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,CategoryName,Description,DateAdded,DateModified")] Category category)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            _context.Add(category);
        //            await _context.SaveChangesAsync();
        //            return RedirectToAction(nameof(Index));
        //        }
        //        return View(category);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //public async Task<IActionResult> Edit(int? id)
        //{
        //    try
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var category = await _context.Category.FindAsync(id);
        //        if (category == null)
        //        {
        //            return NotFound();
        //        }
        //        return View(category);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,CategoryName,Description,DateAdded,DateModified")] Category category)
        //{
        //    try
        //    {
        //        if (id != category.Id)
        //        {
        //            return NotFound();
        //        }

        //        if (ModelState.IsValid)
        //        {
        //            try
        //            {
        //                _context.Update(category);
        //                await _context.SaveChangesAsync();
        //            }
        //            catch (DbUpdateConcurrencyException)
        //            {
        //                if (!CategoryExists(category.Id))
        //                {
        //                    return NotFound();
        //                }
        //                else
        //                {
        //                    throw;
        //                }
        //            }
        //            return RedirectToAction(nameof(Index));
        //        }
        //        return View(category);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //public async Task<IActionResult> Delete(int categoryId)
        //{
        //    try
        //    {
        //        if (categoryId > 0 )
        //        {
        //            var response = await Task.Run(() => _category.DeleteCategory(categoryId));
        //            if (true)
        //            {

        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var category = await _context.Category.FindAsync(id);
        //    _context.Category.Remove(category);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool CategoryExists(int id)
        //{
        //    return _context.Category.Any(e => e.Id == id);
        //}
    }
}
