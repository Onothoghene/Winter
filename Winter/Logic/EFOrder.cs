using System;
using Winter.Data;
using Winter.Services;
using Winter.ViewModels.Input_Models;
using Winter.ViewModels.Output_Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Winter.ILogic;
using System.Transactions;
using Winter.Models;

namespace Winter.Logic
{
    public class EFOrder : IOrder
    {
        //private readonly ApplicationDbContext _context;
        private readonly WinterContext _context;
        ModelFactory _modelFactory = new ModelFactory();

        public EFOrder(WinterContext context)
        {
            _context = context;
        }

        public bool AddOrder(OrderInputViewModel model)
        {
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    var order = _modelFactory.Parse(model);
                    _context.Order.Add(order);
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

        public IEnumerable<OrderOutputViewModel> GetOrders()
        {
            try
            {
                var order = _context.Order.Include(x => x.Category).Include(x => x.Product).ToList();
                var resp = order.Select(x => _modelFactory.Create(x));

                return resp;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EditOrder(OrderOutputViewModel model)
        {
            try
            {
                var order = _context.Order.Find(model.ProductId);

                if (order != null)
                {
                    order.Id = model.OrderId;
                    order.ProductName = model.ProductName;
                    order.ProductId = model.ProductId;
                    order.CategoryId = model.CategoryId;
                    //order.DateModified = model.DateModified;
                    order.Quantity = model.Quantity;
                    order.TotalPrice = model.TotalPrice;
                    order.DateAdded = model.DateAdded;
                    order.DeliveryDate = model.DeliveryDate;
                    order.Address = model.Address;

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

        public int CountOrders()
        {
            try
            {
                var count = _context.Order.ToList().Count();
                return count;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
