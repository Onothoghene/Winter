using System.Collections.Generic;

namespace Winter.ILogic
{
    public interface IWishList
    {
        bool AddToWish(WishIM model);
        bool RemoveItem(long wishId);
        IEnumerable<WishOM> GetUserWishList(long UserProfile);
    }
}
