using API.Winter.DTO.Input_Models;
using API.Winter.DTO.Output_Models;
using System.Collections.Generic;

namespace API.Winter.Logic.Interfaces
{
    public interface IWishList
    {
        bool AddToWishLIst(WishIM model);
        bool RemoveItem(long wishId);
        IEnumerable<WishOM> GetUserWishList(long UserProfile);
        WishOM GetWishDetail(long wishId);
        long GetUserWishListCount(long userId);
        bool RemoveWishListItems(long userId);
    }
}
