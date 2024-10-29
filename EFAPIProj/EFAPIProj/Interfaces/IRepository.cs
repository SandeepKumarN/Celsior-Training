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
