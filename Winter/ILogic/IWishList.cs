﻿using System.Collections.Generic;
using Winter.ViewModels.Input_Models;
using Winter.ViewModels.Output_Models;

namespace Winter.ILogic
{
    public interface IWishList
    {
        bool AddToWish(WishIM model);
        bool RemoveItem(long wishId);
        IEnumerable<WishOM> GetUserWishList(long UserProfile);
        WishOM GetWishDetail(int wishId);
    }
}
