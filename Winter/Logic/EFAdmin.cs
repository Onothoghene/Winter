using Winter.Data;
using Winter.Services;

namespace Winter.Logic
{
    public class EFAdmin : IAdmin
    {
        private readonly WinterContext _context;
        private readonly ModelFactory _modelFactory;

        public EFAdmin(WinterContext context)
        {
            _context = context;
        }


    }
}
