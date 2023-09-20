using Infrastructure.Data.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataContext _dataContext;
        internal DbSet<T> dbSet;

        public Repository(DataContext dataContext)
        {
            _dataContext = dataContext;
            this.dbSet = _dataContext.Set<T>();
        }


        public async Task<T> Add(T entity)
        {
            var result = await dbSet.AddAsync(entity);
            return result.Entity;
        }

        public async Task<IEnumerable<T>> ApplyPagination(int skip, int take)
        {
            IQueryable<T> query = dbSet;
            query.Skip(skip).Take(take);

            return await query.ToListAsync();
        }



       

        public async Task<IEnumerable<T>> GetAll(Expression<Func<T,bool>>? predicate = null,string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if(predicate != null)
                query = query.Where(predicate);

 
            if(includeProperties != null)
            {
                foreach(var property in includeProperties.Split(new char[] {','}, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);

                }
            }

            return await query.ToListAsync();
        }

        public async Task<T> GetFirstOrDefault(Expression<Func<T, bool>> predicate, string? includeProperties = null)
        {
            IQueryable<T> query = dbSet;

            query = query.Where(predicate);

            if (includeProperties != null)
            {
                foreach (var property in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);

                }
            }

            return await query.FirstOrDefaultAsync();

        }

        public void Remove(T entity)
        {
            
             dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
    }
}
