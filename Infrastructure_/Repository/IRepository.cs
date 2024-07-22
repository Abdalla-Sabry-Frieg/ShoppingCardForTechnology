using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure_.Repository.IRepository
{
    public interface IRepository<T> where T  : class
    {
        T FindById(int id);

        T SelectOne(Expression<Func<T, bool>> match);
        T First (Expression<Func<T,bool>> match);

        IEnumerable<T> FindAll();

        // to Egar loading
        IEnumerable<T> FindAll(params string[] agers);

        // when using async way the return must be Generic Task 
        Task<T> FindByIdAsync(int id);

        Task<IEnumerable<T>> FindAllAsync();

        // to Egar loading
        Task<IEnumerable<T>> FindAllAsync(params string[] agers);

        void AddOne(T myItem);

        void UpdateOne(T myItem);

        void DeleteOne(T myItem);

        void AddList(IEnumerable<T> myList);

        void UpdateList(IEnumerable<T> myList);

        void DeleteList(IEnumerable<T> myList);
    } 
}
