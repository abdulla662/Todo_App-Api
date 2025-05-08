using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Todo_App_Api.Models.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        // Asynchronous Create method (single entity)
        Task CreateAsync(T entity);

        // Asynchronous Create method (multiple entities)
        Task CreateAsync(List<T> entity);

        // Asynchronous Edit method
        Task EditAsync(T entity);

        // Asynchronous Delete method (single entity)
        Task DeleteAsync(T entity);

        // Asynchronous Delete method (multiple entities)
        Task DeleteAsync(List<T> entity);

        // Asynchronous Commit method
        Task CommitAsync();

        // Asynchronous Get method (returns IQueryable<T>)
        IQueryable<T> Get(
            Expression<Func<T, bool>>? filter = null,
            Expression<Func<T, object>>[]? includes = null,
            bool tracked = true);

        // Asynchronous GetOne method (returns a single entity)
        Task<T?> GetOneAsync(
            Expression<Func<T, bool>>? filter = null,
            Expression<Func<T, object>>[]? includes = null,
            bool tracked = true);
    }
}
