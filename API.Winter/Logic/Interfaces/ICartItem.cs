using System.Collections.Generic;
using Winter.API.DTO.Input_Models;
using Winter.API.DTO.Output_Models;

namespace Winter.API.Logic.Interfaces
{
    public interface ICartItem
    {
        long GetUserCartItemCount(long userId);
        bool AddToCart(CartIM model);
        bool RemoveItem(long cartId);
        bool RemoveUserItems(long userId);
        CartOM GetCartDetails(long cartId);
        IEnumerable<CartOM> GetUserCartList(long userId);
    }
}
