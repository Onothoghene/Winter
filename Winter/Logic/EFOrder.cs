using Winter.Data;
using Winter.Services;
using Winter.ViewModels.Input_Models;
using Winter.ViewModels.Output_Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Winter.Logic
{
    public class EFOrder : IOrder
    {
        private readonly WinterContext _context;
        ModelFactory _modelFactory = new ModelFactory();


        public EFOrder(WinterContext context)
        {
            _context = context;
        }

        public int AddOrder(OrderInputViewModel model)
        {
            var order = _modelFactory.Parse(model);
            _context.Order.Add(order);
            _context.SaveChanges();

            return order.Id;
        }

        public IEnumerable<OrderOutputViewModel> GetOrders()
        {

            var order = _context.Order.Include(x => x.Category).Include(x => x.Products).ToList();
            var resp = order.Select(x => _modelFactory.Create(x));

            return resp;
        }

        public bool EditOrder(OrderOutputViewModel model)
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
                _context.SaveChanges();
            }

            return true;
        }
    }
}
