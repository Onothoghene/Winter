using Winter.ViewModels.Input_Models;
using Winter.ViewModels.Output_Models;
using System.Collections.Generic;

namespace Winter.ILogic
{
    public interface IOrder
    {
        bool AddOrder(OrderInputViewModel model);
        //bool DeleteOrder(int? Id);
        //CheckOutInputViewModel GetProductById(int? Id);
        IEnumerable<OrderOutputViewModel> GetOrders();
        bool EditOrder(OrderOutputViewModel model);
        int CountOrders();
    }
}
