using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Transactions;

namespace Winter.API.Helpers
{
    public class GenericLogicMethods<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;
        readonly IMapper _mapper;

        public GenericLogicMethods(DbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public TEntity GetById(int id)
        {
            try
            {
                var data = _context.Set<TEntity>().Find(id);

                if (data != null)
                {
                    return data;
                }

                return null;
            }
            catch(Exception)
            {
                throw;
            }
        }
        
        //public IEnumerable<TEntity> GetRange(int id)
        //{
        //    try
        //    {
        //        var data = _context.Set<TEntity>().Find(id));

        //        if (data != null)
        //        {
        //            return data;
        //        }

        //        return null;
        //    }
        //    catch(Exception)
        //    {
        //        throw;
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
        
        //public int AddRange(IEnumerable<TEntity> entity)
        //{
        //    try
        //    {
        //        using (TransactionScope ts = new TransactionScope())
        //        {

        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
    }
}
