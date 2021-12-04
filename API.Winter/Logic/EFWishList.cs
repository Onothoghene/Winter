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
    public class EFWishList : IWishList
    {
        private readonly WinterContext _context;
        private readonly IMapper _mapper;
        //private readonly ModelFactory _modelFactory;

        public EFWishList(WinterContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public bool AddToWishLIst(WishIM model)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var wish = _mapper.Map<Wish>(model);
                    _context.Wish.Add(wish);
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

        public IEnumerable<WishOM> GetUserWishList(long userId)
        {
            try
            {
                var wish = _context.Wish.Where(u => u.UserId == userId)
                                                              .Include(p => p.User)
                                                              .Include(x => x.Product)
                                                              .ToList();

                //var resp = wish.Select(x => _modelFactory.Create(x));

                var resp = _mapper.Map<IEnumerable<WishOM>>(wish);

                return resp;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool RemoveItem(long wishId)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var wish = _context.Wish.Where(x => x.Id == wishId).FirstOrDefault();

                    if (wish != null)
                    {
                        _context.Wish.Remove(wish);
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

        public WishOM GetWishDetail(long wishId)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var wish = _context.Wish.Where(x => x.Id == wishId)
                                                                .Include(i => i.User)
                                                                .Include(e => e.Product)
                                                                .FirstOrDefault();

                    if (wish != null)
                    {
                        // var data = _modelFactory.Create(wish);
                        var data = _mapper.Map<WishOM>(wish);
                        return data;
                    }
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public long GetUserWishListCount(long userId)
        {
            try
            {
                var count = _context.Wish.Where(s => s.UserId == userId)
                                                          .ToList()
                                                          .Count();

                return count;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool RemoveWishListItems(long userId)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var wishes = _context.Wish.Where(x => x.UserId == userId);

                    if (wishes != null)
                    {
                        _context.Wish.RemoveRange(wishes);
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

    }
}
