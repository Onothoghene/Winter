using System.Collections.Generic;
using Winter.ViewModels.Input_Models;
using Winter.ViewModels.Output_Models;

namespace Winter.ILogic
{
    public interface ICartItem
    {
        long GetUserCartItemCount(long userId);
        bool AddToCart(CartIM model);
        bool RemoveItem(long cartId);
        //bool RemoveItem(long cartId, long userId);
        bool RemoveUserItems(long userId);
        CartOM GetCartDetails(long cartId);
        IEnumerable<CartOM> GetUserCartList(long userId);
    }
}
