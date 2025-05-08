using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo_App_Api.DataAcess.DataAcess;
using Todo_App_Api.DataAcess.Repository.IRepository;
using Todo_App_Api.Models.Models;
using Todo_App_Api.Models.Repository;
using Todo_App_Api.Models.Repository.IRepository;

namespace Todo_App_Api.DataAcess.Repository
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IRepository<TodoItem>? _todoRepository;
        private IRepository<ApplicationUser>? _userRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }
        public IRepository<TodoItem> Todos
       => _todoRepository ??= new Repository<TodoItem>(_context);

        public IRepository<ApplicationUser> Users
            => _userRepository ??= new Repository<ApplicationUser>(_context);


        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
