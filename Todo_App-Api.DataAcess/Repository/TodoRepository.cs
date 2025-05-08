using Todo_App_Api.DataAcess.DataAcess;
using Todo_App_Api.DataAcess.Repository.IRepository;
using Todo_App_Api.Models.Models;
using Todo_App_Api.Models.Repository;

namespace Todo_App_Api.DataAcess.Repository
{
    public class TodoRepository : Repository<TodoItem>, ITodoRepository
    {
        private readonly ApplicationDbContext _dbcontext;

        public TodoRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this._dbcontext = dbContext;
        }
    }
}

