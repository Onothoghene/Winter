using API.Winter.Logic.Interfaces;

namespace API.Winter.Logic
{
    public class EFOrder : IOrder
    {
        //private readonly WinterContext _context;
        //ModelFactory _modelFactory = new ModelFactory();

        //public EFOrder(WinterContext context)
        //{
        //    _context = context;
        //}

        //public bool AddOrder(OrderInputViewModel model)
        //{
        //    try
        //    {
        //        using (TransactionScope ts = new TransactionScope())
        //        {
        //            var order = _modelFactory.Parse(model);
        //            _context.OrderRequest.Add(order);
        //            int bit = _context.SaveChanges();
        //            ts.Complete();

        //            if (bit > 0)
        //                return true;
        //            else
        //                return false;
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //public IEnumerable<OrderOutputViewModel> GetOrders()
        //{
        //    try
        //    {
        //        var order = _context.OrderRequest
        //                                            .Include(x => x.Product).ToList();

        //        var resp = order.Select(x => _modelFactory.Create(x));

        //        return resp;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //public bool EditOrder(OrderOutputViewModel model)
        //{
        //    try
        //    {
        //        var order = _context.OrderRequest.Find(model.ProductId);

        //        if (order != null)
        //        {
        //            order.Id = model.OrderId;
        //            order.ProductId = model.ProductId;
        //            //order.AddedBy = model.UserId;
        //            order.Quantity = model.Quantity;
        //            order.Price = model.Price;
        //            order.DateAdded = DateTime.Now;
        //            //order.DeliveryDate = model.DeliveryDate;
        //            //order.Address = model.Address;

        //            _context.SaveChanges();
        //            return true;
        //        }

        //        return false;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //public bool CancelOrder(int orderId)
        //{
        //    try
        //    {
        //        using (TransactionScope ts = new TransactionScope())
        //        {
        //            var order = _context.OrderRequest.Find(orderId);
        //            if (order != null)
        //            {
        //                //order.IsCancelled = true;
        //                //order.DateCancelled = DateTime.Now;

        //                _context.SaveChanges();
        //                ts.Complete();
        //                return true;
        //            }
        //            return false;
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //public bool DeleteOrder(int orderId)
        //{
        //    try
        //    {
        //        using (TransactionScope ts = new TransactionScope())
        //        {
        //            var order = _context.OrderRequest.Find(orderId);
        //            if (order != null)
        //            {
        //                _context.OrderRequest.Remove(order);
        //                _context.SaveChanges();
        //                ts.Complete();
        //                return true;
        //            }
        //            return false;
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //public int TotalOrders()
        //{
        //    try
        //    {
        //        var count = _context.OrderRequest.ToList().Count();
        //        return count;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //public int UserTotalOrderCount(long userId)
        //{
        //    try
        //    {
        //        var count = _context.OrderRequest.Where(x => x.AddedBy == userId)
        //                            .ToList().Count();
        //        return count;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //public IEnumerable<OrderOutputViewModel> GetUserOrders(long UserId)
        //{
        //    try
        //    {
        //        var order = _context.OrderRequest.Where(w => w.AddedBy == UserId)
        //                                                                      .Include(c => c.AddedByNavigation)
        //                                                                      .Include(x => x.Product)
        //                                                                      .ToList();

        //        var resp = order.Select(x => _modelFactory.Create(x));

        //        return resp;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        //public IEnumerable<OrderOutputViewModel> GetUserCancelledORd(long UserId)
        //{
        //    try
        //    {
        //        var order = _context.OrderRequest.Where(w => w.AddedBy == UserId)
        //                                                                      .Include(c => c.AddedByNavigation)
        //                                                                      .Include(x => x.Product)
        //                                                                      .ToList();

        //        var resp = order.Select(x => _modelFactory.Create(x));

        //        return resp;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
    }
}
