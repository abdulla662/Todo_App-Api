using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo_App_Api.Models.Dtos.Response
{
    public class TodoResponseDto
    {
        public Guid Id { get; set; }  
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }  
        public string Priority { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; } = null;
    }
}
