using System.Collections.Generic;
using System.Threading.Tasks;

namespace Winter.Helpers
{
    //public interface IHttpClientLogic<T> where T : class
    public interface IHttpClientLogic
    {
        //Task<T> Add(T entity, string Urlendpoint);
        //Task<T> AddRange(IEnumerable<T> entity, string Urlendpoint);

        //Task<T> Delete(T entity, string Urlendpoint);
        //Task<T> DeleteRange(IEnumerable<T> entity, string Urlendpoint);

        //Task<T> GetById(T entity, string Urlendpoint);
        //Task<IEnumerable<T>> GetList(T entity, string Urlendpoint);

        //Task<T> Update(T entity, string Urlendpoint);
        //Task<T> UpdateRange(IEnumerable<T> entity, string Urlendpoint);
        
        Task<T> Add<T>(T entity, string Urlendpoint);
        Task<T> AddRange<T>(IEnumerable<T> entity, string Urlendpoint);

        Task<T> Delete<T>(T entity, string Urlendpoint);
        Task<T> DeleteRange<T>(IEnumerable<T> entity, string Urlendpoint);

        Task<T> GetById<T>(T entity, string Urlendpoint);
        Task<T> GetById<T>(string Urlendpoint);
        Task<IEnumerable<T>> GetList<T>(T entity, string Urlendpoint);

        Task<T> Update<T>(T entity, string Urlendpoint);
        Task<T> UpdateRange<T>(IEnumerable<T> entity, string Urlendpoint);
    }
}