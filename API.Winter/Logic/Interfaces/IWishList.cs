using System.Collections.Generic;
using Winter.API.DTO.Input_Models;
using Winter.API.DTO.Output_Models;

namespace Winter.API.Logic.Interfaces
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
