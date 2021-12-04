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
    public class EFBrand : IBrand
    {
        private readonly WinterContext _context;
        readonly IMapper _mapper;

        public EFBrand(WinterContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool AddBrand(BrandIM model)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var brand = _mapper.Map<Brand>(model);
                    _context.Brand.Add(brand);
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

        public IEnumerable<BrandOM> GetBrands()
        {
            try
            {
                var brands = _context.Brand.ToList();

                var resp = _mapper.Map<List<BrandOM>>(brands);

                return resp;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public BrandOM GetById(int Id)
        {
            try
            {
                var brand = _context.Brand.Where(w => w.Id == Id).FirstOrDefault();
                var resp = _mapper.Map<BrandOM>(brand);

                return resp;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool DeleteBrand(int Id)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var data = _context.Brand.Find(Id);
                    if (data != null)
                    {
                        _context.Brand.Remove(data);
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

        public bool UpdateBrand(BrandEM model)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var brand = _context.Brand.Where(w => w.Id == model.Id).FirstOrDefault();

                    if (brand != null)
                    {
                        brand.Name = model.Name;
                        brand.Description = model.Description;
                        brand.DateModified = DateTime.Now;
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

        public long CountBrand()
        {
            try
            {
                var count = _context.Brand.ToList().Count();
                return count;
            }
            catch (Exception)
            {

                throw;
            }

        }

    }
}
