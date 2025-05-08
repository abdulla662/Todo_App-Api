using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Todo_App_Api.DataAcess.DataAcess;
using Todo_App_Api.Models.Repository.IRepository;

namespace Todo_App_Api.Models.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext dbContext;
        public DbSet<T> dbset;

        public Repository(ApplicationDbContext applicationDb)
        {
            this.dbContext = applicationDb;
            dbset = dbContext.Set<T>();
        }

        // Asynchronous Create method (single entity)
        public async Task CreateAsync(T entity)
        {
            dbset.Add(entity);
            await dbContext.SaveChangesAsync(); // Use SaveChangesAsync for async operation
        }

        // Asynchronous Create method (multiple entities)
        public async Task CreateAsync(List<T> entity)
        {
            dbset.AddRange(entity);
            await dbContext.SaveChangesAsync(); // Use SaveChangesAsync for async operation
        }

        // Asynchronous Edit method
        public async Task EditAsync(T entity)
        {
            dbset.Update(entity);
            await dbContext.SaveChangesAsync(); // Use SaveChangesAsync for async operation
        }

        // Asynchronous Delete method (single entity)
        public async Task DeleteAsync(T entity)
        {
            dbset.Remove(entity);
            await dbContext.SaveChangesAsync(); // Use SaveChangesAsync for async operation
        }

        // Asynchronous Delete method (multiple entities)
        public async Task DeleteAsync(List<T> entity)
        {
            dbset.RemoveRange(entity);
            await dbContext.SaveChangesAsync(); // Use SaveChangesAsync for async operation
        }

        // Asynchronous Commit method
        public async Task CommitAsync()
        {
            await dbContext.SaveChangesAsync(); // Use SaveChangesAsync for async operation
        }

        // Asynchronous Get method (returns IQueryable<T>)
        public IQueryable<T> Get(
            Expression<Func<T, bool>>? filter = null,
            Expression<Func<T, object>>[]? includes = null,
            bool tracked = true)
        {
            IQueryable<T> query = dbset;

            // Apply filter only if it's not null
            if (filter != null)
            {
                query = query.Where(filter);
            }

            // Include navigation properties if provided
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            // Disable tracking if specified
            if (!tracked)
            {
                query = query.AsNoTracking();
            }

            return query; // Return IQueryable<T> for further chaining
        }

        // Asynchronous GetOne method (returns a single entity)
        public async Task<T?> GetOneAsync(
            Expression<Func<T, bool>>? filter = null,
            Expression<Func<T, object>>[]? includes = null,
            bool tracked = true)
        {
            var query = Get(filter, includes, tracked); // Get the IQueryable<T> query
            return await query.FirstOrDefaultAsync(); // Use FirstOrDefaultAsync to get the first matching entity
        }
    }
}
