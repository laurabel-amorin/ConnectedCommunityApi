using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConnectedCommunity.Model.Repositories
{
    public interface IRepository<T>:IDisposable
    {
        List<T> GetAll();
        List<T> Get(Expression<Func<T, bool>> predicate);
        T Find(int id);
        void Create(T entity);
        void Delete(T entity);
        void Update(T entity);

        //async
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAsync(Expression<Func<T, bool>> predicate);
        Task<T> FindAsync(int id);
        Task CreateAsync(T entity);
        Task DeleteAsync(T entity);
        Task UpdateAsync(T entity);
    }

    public class Repository<T>:IRepository<T> where T:class
    {
        private readonly AppDataContext context;

        public Repository(AppDataContext context){
            this.context = context;
        }

        public T Find(int id)
        {
            return context.Set<T>().Find(id);
        }

        public virtual List<T> GetAll()
        {
            return context.Set<T>().ToList();
        }

        public List<T> Get(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate).ToList();
        }

        public virtual void Create(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }

        //public virtual void Update(T entity)
        //{
        //    context.Entry(entity).State = System.Data.EntityState.Modified;
        //}
        
        public async Task<List<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<T> FindAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task CreateAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }

        //public async Task UpdateAsync(T entity)
        //{
        //    throw new NotImplementedException();
        //}
        
        public void Dispose()
        {
            context.Dispose();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}



