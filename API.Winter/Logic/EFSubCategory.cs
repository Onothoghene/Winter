using APi.Winter.DTO.Edit_Models;
using API.Winter.DTO.Input_Models;
using API.Winter.DTO.Output_Models;
using API.Winter.Logic.Interfaces;
using API.Winter.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace API.Winter.Logic
{
    public class EFSubCategory : ISubCategory
    {
        private readonly WinterContext _context;
        readonly IMapper _mapper;

        public EFSubCategory(IMapper mapper)
        {
            _context = new WinterContext();
            _mapper = mapper;
        }

        public bool AddSubCategory(SubCategoryIM model)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var subCategory = _mapper.Map<SubCategory>(model);
                    _context.SubCategory.Add(subCategory);
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

        public IEnumerable<SubCategoryOM> GetSubCategory()
        {
            try
            {
                var subCategory = _context.SubCategory.ToList();
                var resp = _mapper.Map<List<SubCategoryOM>>(subCategory);
                return resp;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public SubCategoryOM GetSubCategoryById(int Id)
        {
            try
            {
                var subCategory = _context.SubCategory.Find(Id);
                var resp = _mapper.Map<SubCategoryOM>(subCategory);
                return resp;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteSubCategory(int Id)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var data = _context.SubCategory.Find(Id);
                    if (data != null)
                    {
                        _context.SubCategory.Remove(data);
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

        public bool UpdateSubCategory(SubCategoryEM model)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var subcategory = _context.SubCategory.Find(model.Id);
                    if (subcategory != null)
                    {
                        subcategory.Name = model.Name;
                        subcategory.CategoryId = model.CategoryId;
                        subcategory.Description = model.Description;
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

        public long CountSubCategory()
        {
            try
            {
                var count = _context.SubCategory.ToList().Count();
                return count;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
