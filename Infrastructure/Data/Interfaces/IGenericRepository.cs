using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.Data.Repository.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetFirstOrDefault(Expression<Func<T, bool>> predicate, string? includeProperties = null);
        Task<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? predicate = null, string? includeProperties = null);

        Task <IEnumerable<T>> ApplyPagination(int skip, int take);
        Task<T> Add(T entity);

        void Update(T entity);
 
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
