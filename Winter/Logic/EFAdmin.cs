using Winter.Data;
using Winter.Services;

namespace Winter.Logic
{
    public class EFAdmin : IAdmin
    {
        private readonly WinterContext _context;

        public EFAdmin(WinterContext context)
        {
            _context = context;
        }


    }
}
