using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo_App_Api.DataAcess.DataAcess;
using Todo_App_Api.DataAcess.Repository.IRepository;
using Todo_App_Api.Models.Models;
using Todo_App_Api.Models.Repository;

namespace Todo_App_Api.DataAcess.Repository
{
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly ApplicationDbContext dbcontext;
        public ApplicationUserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            this.dbcontext = dbContext;
        }

    }
}
