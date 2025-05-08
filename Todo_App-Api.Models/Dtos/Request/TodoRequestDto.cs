using System.ComponentModel.DataAnnotations;
using Todo_App_Api.Enums;
using Todo_App_Api.Models.Models;

namespace Todo_App_Api.Dtos.Request
{

    public class TodoRequestDto
    {
        [Required, MaxLength(100)]
        public string Title { get; set; }

        public string? Description { get; set; }

        public TodoStatus Status { get; set; } = TodoStatus.Pending;

        public TodoPriority Priority { get; set; } = TodoPriority.Low;

        public DateTime? DueDate { get; set; }
    }
}
