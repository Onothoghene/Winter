using Winter.ILogic;
using Winter.Models;

namespace Winter.Logic
{
    public class EFCartItem : ICartItem
    {
        private readonly WinterContext _context;

        public EFCartItem(WinterContext context)
        {
            _context = context;
        }


    }
}
