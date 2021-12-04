using API.Winter.DTO.Input_Models;
using API.Winter.DTO.Output_Models;
using System.Collections.Generic;

namespace API.Winter.Logic.Interfaces
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
