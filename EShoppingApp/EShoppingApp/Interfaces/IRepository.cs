﻿using EShoppingApp.Models;

namespace EShoppingApp.Interfaces
{
    public interface IRepository<K, T> where T : class
    {
        Task<T> Get(K key);
        Task<IEnumerable<T>> GetAll();
        Task<T> Add(T entity);
        Task<T> Delete(K key);
        Task<T> Update(K key, T entity);
    }
}