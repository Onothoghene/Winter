using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Winter.ILogic;
using Winter.Models;
using Winter.Services;
using Winter.ViewModels.Input_Models;
using Winter.ViewModels.Output_Models;

namespace Winter.Logic
{
    public class EFWishList : IWishList
    {
        private readonly WinterContext _context;
        private readonly ModelFactory _modelFactory;

        public EFWishList(WinterContext context, ModelFactory modelFactory)
        {
            _context = context;
            _modelFactory = modelFactory;
        }

        public bool AddToWishLIst(WishIM model)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var order = _modelFactory.Parse(model);
                    _context.Wish.Add(order);
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

                var resp = wish.Select(x => _modelFactory.Create(x));

                return resp;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
