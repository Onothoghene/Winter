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
    public class EFCategoryType : ICategoryType
    {
        private readonly WinterContext _context;
        readonly IMapper _mapper;

        public EFCategoryType(IMapper mapper)
        {
            //_context = context;
            _context = new WinterContext();
            _mapper = mapper;
        }

        public bool Add(CategoryTypeIM model)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var data = _mapper.Map<CategoryType>(model);
                    _context.CategoryType.Add(data);
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

        public IEnumerable<CategoryTypeOM> GetList()
        {
            try
            {
                var data = _context.CategoryType.ToList();
                var resp = _mapper.Map<List<CategoryTypeOM>>(data);
                return resp;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public CategoryTypeOM GetById(int Id)
        {
            try
            {
                var data = _context.CategoryType.Where(w => w.Id == Id).FirstOrDefault() ;
                var resp = _mapper.Map<CategoryTypeOM>(data);
                return resp;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Delete(int Id)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var data = _context.CategoryType.Find(Id);
                    if (data != null)
                    {
                        _context.CategoryType.Remove(data);
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

        public bool Update(CategoryTypeEM model)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var response = _context.CategoryType.Where(w => w.Id == model.Id).FirstOrDefault();

                    if (response != null)
                    {
                        response.Name = model.Name;
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

        public long Count()
        {
            try
            {
                var count = _context.CategoryType.ToList().Count();
                return count;
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
