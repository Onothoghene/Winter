using Winter.ViewModels.Input_Models;
using Winter.ViewModels.Output_Models;
using System.Collections.Generic;

namespace Winter.ILogic
{
    public interface IOrder
    {
        bool AddOrder(OrderInputViewModel model);
        int TotalOrders();
        int UserTotalOrderCount(long userId);
        bool DeleteOrder(int orderId);
        IEnumerable<OrderOutputViewModel> GetUserOrders(long UserId);
        bool CancelOrder(int orderId);
        IEnumerable<OrderOutputViewModel> GetOrders();
        bool EditOrder(OrderOutputViewModel model);
    }
}
