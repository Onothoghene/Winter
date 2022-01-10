using APi.Winter.DTO.Edit_Models;
using API.Winter.DTO.Input_Models;
using API.Winter.DTO.Output_Models;
using API.Winter.Logic.Interfaces;
using API.Winter.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace API.Winter.Logic
{
    public class EFCategory : ICategory
    {
        private readonly WinterContext _context;
        readonly IMapper _mapper;

        public EFCategory(IMapper mapper)
        {
            _context = new WinterContext() ;
            _mapper = mapper;
        }

        public bool AddCategory(CategoryIM model)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    //var category = _modelFactory.Parse(model);
                    var category = _mapper.Map<Category>(model);
                    _context.Category.Add(category);
                    int bit = _context.SaveChanges();
                    ts.Complete();

                    if (bit > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<CategoryOM> GetCategory()
        {
            try
            {
                var category = _context.Category.ToList();
                var resp = _mapper.Map<IEnumerable<CategoryOM>>(category);

                return resp;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<CategoryOMLite> GetCategoryLite()
        {
            try
            {
                var category = _context.Category.ToList();
                var resp = _mapper.Map<IEnumerable<CategoryOMLite>>(category);

                return resp;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public CategoryOM GetCategoryById(int Id)
        {
            try
            {
                var category = _context.Category.Find(Id);
                var resp = _mapper.Map<CategoryOM>(category);

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

        public bool UpdateCategory(CategoryEM model)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var category = _context.Category.Find(model.Id);

                    if (category != null)
                    {
                        category.CategoryName = model.CategoryName;
                        //category.Id = model.Id;
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

        public int CountCategory()
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

        //public IEnumerable<CategoryTypeOMLite> GetCategoryList()
        //{
        //    try
        //    {
        //        var brands = _context.Brand.ToList();

        //        var response = new CategoryTypeOMLite
        //        {
        //            Brands = _mapper.Map<IEnumerable<BrandOMLite>>(brands),
        //        };
        //        var data = _context.CategoryType.Include(x => x.Category).ThenInclude(x => x.SubCategory).ToList();
        //        response = _mapper.Map<IEnumerable<CategoryTypeOMLite>>(data);

        //        return response;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

    }
}
