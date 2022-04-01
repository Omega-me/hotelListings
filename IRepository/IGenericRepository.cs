using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Npgsql.Replication.PgOutput.Messages;

namespace HotelListing.IRepository
{
    public interface IGenericRepository<T> where T:class
    {
        Task<IList<T>> GetAll(
            Expression<Func<T,bool>> expression=null,
            Func<IQueryable<T>,IOrderedQueryable<T>> orderBy=null,
            List<String> includes=null);
        Task<T> Get(Expression<Func<T, bool>> expression, List<string> includes = null);
        Task Insert(T entity);
        Task InsertRange(IEnumerable<T> enitites);
        Task Delete(int id);
        void DeleteRange(IEnumerable<T> enitites);
        void Update(T entity);
    }
}