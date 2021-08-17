using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Winter.DTO.Edit_Models;
using Winter.DTO.Input_Models;
using Winter.DTO.Output_Models;
using Winter.ILogic;
using Winter.Models;
using Winter.Services;

namespace Winter.Logic
{
    public class EFCartItem : ICartItem
    {
        private readonly WinterContext _context;
        readonly ModelFactory _modelFactory = new ModelFactory();

        public EFCartItem(WinterContext context)
        {
            _context = context;
        }

        public bool AddToCart(CartIM model)
        {
            try
            {
                int bit = 0;
                var userCart = _context.Cart.Where(e => e.UserId == model.UserId && e.ProductId == model.ProductId).FirstOrDefault();
                using (TransactionScope ts = new TransactionScope())
                {
                    if (userCart != null)
                    {
                        //userCart.Quantity++;
                    }
                    else
                    {
                        var cartItem = _modelFactory.Parse(model);
                        _context.Cart.Add(cartItem);
                        bit = _context.SaveChanges();
                    }

                    ts.Complete();

                    return true;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        //public bool RemoveItem(long cartId, long userId)
        public bool RemoveItem(long cartId)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var cartItem = _context.Cart.Where(x => x.Id == cartId).FirstOrDefault();

                    if (cartItem != null)
                    {
                        _context.Cart.Remove(cartItem);
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

        public bool RemoveUserItems(long userId)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var cartItem = _context.Cart.Where(x => x.UserId == userId);

                    if (cartItem != null)
                    {
                        _context.Cart.RemoveRange(cartItem);
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

        public CartOM GetCartDetails(long cartId)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var cartItem = _context.Cart.Where(x => x.Id == cartId)
                                                                .Include(i => i.User)
                                                                .Include(e => e.Product)
                                                                .FirstOrDefault();

                    if (cartItem != null)
                    {
                        var data = _modelFactory.Create(cartItem);
                    }
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public long GetUserCartItemCount(long userId)
        {
            try
            {
                var count = _context.Cart.Where(s => s.UserId == userId)
                                                          .ToList()
                                                          .Count();

                return count;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<CartOM> GetUserCartList(long userId)
        {
            try
            {
                var cartItems = _context.Cart.Where(u => u.UserId == userId)
                                                              .Include(p => p.User)
                                                              .Include(x => x.Product)
                                                              .ToList();

                var resp = cartItems.Select(x => _modelFactory.Create(x));

                return resp;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool UpdateCartItem(CartEM model)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    //var cartItem = _context.Cart.Where(f => f.UserId == model.UserId && f.ProductId == model.ProductId).FirstOrDefault();
                    var cartItem = _context.Cart.Where(f => f.Id == model.Id).FirstOrDefault();

                    if (cartItem != null)
                    {
                       // cartItem.Quantity++;
                        //cartItem.DateModified = DateTime.Now;

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
