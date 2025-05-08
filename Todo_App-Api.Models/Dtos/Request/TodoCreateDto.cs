using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo_App_Api.Enums;
using Todo_App_Api.Models.Models;


namespace Todo_App_Api.Models.Dtos.Request
{
    public class TodoCreateDto
    {
        [Required(ErrorMessage = "Title is required.")]
        [MaxLength(100, ErrorMessage = "Title can't exceed 100 characters.")]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public TodoStatus Status { get; set; } = TodoStatus.Pending;

        [Required]
        public TodoPriority Priority { get; set; } = TodoPriority.Low;

        [FutureDate(ErrorMessage = "DueDate must be in the future.")]
        public DateTime? DueDate { get; set; }
    }

}
