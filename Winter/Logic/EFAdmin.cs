using Winter.Data;
using Winter.ILogic;
using Winter.Services;

namespace Winter.Logic
{
    public class EFAdmin : IAdmin
    {
        private readonly ApplicationDbContext _context;

        public EFAdmin(ApplicationDbContext context)
        {
            _context = context;
        }


    }
}
