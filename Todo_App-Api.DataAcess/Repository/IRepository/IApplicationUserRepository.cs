using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo_App_Api.Models.Models;
using Todo_App_Api.Models.Repository.IRepository;

namespace Todo_App_Api.DataAcess.Repository.IRepository
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
    }
}
