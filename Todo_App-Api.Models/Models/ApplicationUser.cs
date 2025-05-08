using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo_App_Api.Models.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string? Adress { get; set; }
    }
}
