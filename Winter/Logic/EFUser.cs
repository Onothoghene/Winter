using System.Linq;
using Winter.Data;
using Winter.Services;

namespace Winter.Logic
{
    public class EFUser : IUsers
    {
        private readonly WinterContext _context;
        ModelFactory _modelFactory = new ModelFactory();


        public EFUser(WinterContext context)
        {
            _context = context;
        }
        //public int CountUser()
        //{
        //    _context.A

        //    return count;
        //}
    }
}
