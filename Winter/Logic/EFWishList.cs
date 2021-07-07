using Winter.ILogic;
using Winter.Models;

namespace Winter.Logic
{
    public class EFWishList : IWishList
    {
        private readonly WinterContext _context;

        public EFWishList(WinterContext context)
        {
            _context = context;
        }


    }
}
