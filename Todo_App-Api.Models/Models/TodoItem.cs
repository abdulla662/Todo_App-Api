using System.ComponentModel.DataAnnotations;
using Todo_App_Api.Enums;

namespace Todo_App_Api.Models.Models
{


    public class TodoItem
    {
        public Guid Id { get; set; }

        [Required, MaxLength(100)]
        public string Title { get; set; }

        public string? Description { get; set; }

        public TodoStatus Status { get; set; } = TodoStatus.Pending;

        public TodoPriority Priority { get; set; } = TodoPriority.Low;

        public DateTime? DueDate { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }



    }
}


