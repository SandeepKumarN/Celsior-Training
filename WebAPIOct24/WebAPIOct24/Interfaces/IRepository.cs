using System.Linq.Expressions;

namespace WebAPIOct24.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task Delete(int id);
    }
}


/*
  
 using EFAPIProj.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFAPIProj.Interfaces
{
    public interface IRepository<K, T> where T : class
    {
        Task<T> Get(int id);

        Task<IEnumerable<T>> GetAll();

        Task<T> Add(T entity);

        Task<T> Update(K key, T entity);

        Task<T> Delete(int id);
        Task<Customer> Update(Customer customer);
    }
}

 */