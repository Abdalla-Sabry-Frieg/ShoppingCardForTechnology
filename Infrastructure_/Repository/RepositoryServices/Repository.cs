using Infrastructure_.DataBase;
using Infrastructure_.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure_.Repository.RepositoryServices
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public Repository(ShoppingCardDbContext context)
        {
            this.context = context;
        }

        protected ShoppingCardDbContext context;

        public T FindById(int id)
        {
            // Set<T>() => support multiable parallel operation at same time at DbContext , alwayes call await and async immediatelly
            return context.Set<T>().Find(id);
        }

        public T SelectOne(Expression<Func<T, bool>> match)
        {
            return context.Set<T>().SingleOrDefault(match);
        }

        public IEnumerable<T> FindAll()
        {
            return context.Set<T>().ToList();
        }

        public async Task<T> FindByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> FindAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }

        public IEnumerable<T> FindAll(params string[] agers)
        {
            IQueryable<T> query = context.Set<T>();

            // means params string[] => have a data  
            if (agers.Length > 0)
            {
                foreach (var ager in agers)
                {
                    query = query.Include(ager);
                }
            }

            return query.ToList();
        }

        public async Task<IEnumerable<T>> FindAllAsync(params string[] agers)
        {
            IQueryable<T> query = context.Set<T>();

            if (agers.Length > 0)
            {
                foreach (var ager in agers)
                {
                    query = query.Include(ager);
                }
            }

            return await query.ToListAsync();
        }

        //=========================================================================//

        public void AddOne(T myItem)
        {
            context.Set<T>().Add(myItem);
            context.SaveChanges();
        }

        public void UpdateOne(T myItem)
        {
            context.Set<T>().Update(myItem);
            context.SaveChanges();
        }

        public void DeleteOne(T myItem)
        {
            context.Set<T>().Remove(myItem);
            context.SaveChanges();
        }

        public void AddList(IEnumerable<T> myList)
        {
            context.Set<T>().AddRange(myList);
            context.SaveChanges();
        }

        public void UpdateList(IEnumerable<T> myList)
        {
            context.Set<T>().UpdateRange(myList);
            context.SaveChanges();
        }

        public void DeleteList(IEnumerable<T> myList)
        {
            context.Set<T>().RemoveRange(myList);
            context.SaveChanges();
        }

        public T First(Expression<Func<T, bool>> match)
        {
            return context.Set<T>().FirstOrDefault(match);
        }

       






        //public void Add(T entity)
        //{
        //   _dbSet.Add(entity);
        //}

        //public void Delete(T entity)
        //{
        //   _dbSet.Remove(entity);
        //}

        //public void DeleteRange(IEnumerable<T> entities)
        //{
        //    _dbSet.RemoveRange(entities);
        //}

        //public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate = null, string includeProperities = null)
        //{
        //    IQueryable<T> query = _dbSet;
        //    if (predicate != null)
        //    {
        //        query= query.Where(predicate);
        //    }
        //    if (includeProperities != null)
        //    {
        //        foreach (var item in includeProperities.Split(new char[] { ',' } , StringSplitOptions.RemoveEmptyEntries))
        //        {
        //            query = query.Include(item);
        //        }
        //    }
        //    return query.ToList();
        //}

        //public T GetT(Expression<Func<T, bool>> predicate = null, string includeProperities = null)
        //{
        //    IQueryable<T> query = _dbSet;
        //    if (predicate != null)
        //    {
        //        query = query.Where(predicate);
        //    }
        //    if (includeProperities != null)
        //    {
        //        foreach (var item in includeProperities.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        //        {
        //            query = query.Include(item);
        //        }
        //    }
        //    return query.FirstOrDefault();
        //}


    }
}
