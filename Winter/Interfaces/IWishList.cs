using System.Collections.Generic;
using Winter.DTO.Input_Models;
using Winter.DTO.Output_Models;

namespace Winter.ILogic
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
