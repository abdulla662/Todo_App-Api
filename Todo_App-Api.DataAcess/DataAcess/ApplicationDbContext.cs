using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Todo_App_Api.Models.Models;

namespace Todo_App_Api.DataAcess.DataAcess
{
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
        {
        }

        public DbSet<TodoItem> Todos { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }

    }
}
