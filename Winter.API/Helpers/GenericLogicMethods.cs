using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace Winter.API.Helpers
{
    public class GenericLogicMethods<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;

        public GenericLogicMethods(DbContext context)
        {
            _context = context;
        }

        //public TEntity GetById(int id)
        //{
        //    try
        //    {
        //        using (TransactionScope ts = new TransactionScope())
        //        {
        //            var data = _context.Set<TEntity>().Find(id);

        //            if (data != null)     
        //            {
        //                return data;
        //            }
        //            return null;
        //        }
        //    }
        //    catch
        //    {

        //    }
        //}

        //public int Add(TEntity entity)
        //{
        //    try
        //    {

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
    }
}
