
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Todo_App_Api.Dtos.Request;
using Todo_App_Api.Enums;
using Todo_App_Api.Models.Dtos.Request;
using Todo_App_Api.Models.Dtos.Response;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Todo_App_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TodoController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public TodoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetAllTodos")]
        /// <summary>
        /// Retrieves all todo items
        /// </summary>
        /// <returns>List of all todo items</returns>
        public IActionResult GetAllTodos()
        {
            var todos = _unitOfWork.Todos.Get().ToList();

            if (todos == null || todos.Count == 0)
            {
                return NotFound("No Todo items found.");
            }
            var TodoDtos = todos.Select(todo => new TodoResponseDto
            {
                Id = todo.Id,  
                Title = todo.Title,
                Description = todo.Description,
                Status = todo.Status.ToString(),
                Priority = todo.Priority.ToString(),
                DueDate = todo.DueDate,
                CreatedDate = todo.CreatedDate,
                LastModifiedDate = todo.LastModifiedDate
            }).ToList();

            return Ok(TodoDtos); 
        }
        /// <summary>
        /// Creates a new todo item
        /// </summary>
        /// <param name="todo">Todo item data</param>
        /// <returns>Created todo item</returns>
        [HttpPost("CreateTodo")]
        public async Task<IActionResult> CreateTodo([FromBody] TodoCreateDto todo)
        {
            if (todo == null || !ModelState.IsValid)
            {
                return BadRequest("Invalid Todo data.");
            }

            var todoItem = new TodoItem
            {
                Id = Guid.NewGuid(),
                Title = todo.Title,
                Description = todo.Description,
                Status = todo.Status,
                Priority = todo.Priority,
                DueDate = todo.DueDate,
                CreatedDate = DateTime.UtcNow,
                LastModifiedDate = null
            };


            try
            {
                await _unitOfWork.Todos.CreateAsync(todoItem);
                await _unitOfWork.Todos.CommitAsync();

                var todoResponse = new TodoResponseDto
                {
                    Id = todoItem.Id,
                    Title = todoItem.Title,
                    Description = todoItem.Description,
                    Status = todoItem.Status.ToString(),
                    Priority = todoItem.Priority.ToString(),
                    DueDate = todoItem.DueDate,
                    CreatedDate = todoItem.CreatedDate
                };

                return CreatedAtAction(nameof(CreateTodo), new { id = todoItem.Id }, todoResponse);
            }
            catch (DbUpdateException ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
        /// <summary>
        /// Updates an existing todo item
        /// </summary>
        /// <param name="id">Todo item ID</param>
        /// <param name="todo">Updated todo item data</param>
        /// <returns>Updated todo item</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodo([FromRoute] Guid id, [FromBody] TodoRequestDto todo)
        {
            if (todo == null || !ModelState.IsValid)
                return BadRequest("Invalid data.");

            var existingTodo = await _unitOfWork.Todos.GetOneAsync(x => x.Id == id);
            if (existingTodo == null)
                return NotFound("Todo not found.");

            existingTodo.Title = todo.Title;
            existingTodo.Description = todo.Description;
            existingTodo.Status = todo.Status;
            existingTodo.Priority = todo.Priority;
            existingTodo.DueDate = todo.DueDate;
            existingTodo.LastModifiedDate = DateTime.UtcNow;

            await _unitOfWork.Todos.EditAsync(existingTodo);
            await _unitOfWork.Todos.CommitAsync();

            return Ok(existingTodo);
        }

        [HttpDelete("{id}")]
        /// <summary>
        /// Deletes a todo item
        /// </summary>
        /// <param name="id">Todo item ID to delete</param>
        /// <returns>Deleted todo item</returns>
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            // Check if the ID exists in the database
            var existingTodo = await _unitOfWork.Todos.GetOneAsync(x => x.Id == id);
            if (existingTodo == null)
            {
                // If not found, return a NotFound status
                return NotFound("Todo item not found.");
            }

            try
            {
                // Proceed to delete the item
                await _unitOfWork.Todos.DeleteAsync(existingTodo);
                await _unitOfWork.Todos.CommitAsync();

                // Return the deleted item or a success response
                return Ok(existingTodo);
            }
            catch (DbUpdateException ex)
            {
                // Handle the error and return a 500 status code
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
        [HttpGet("GetFilteredTodos")]
        /// <summary>
        /// Retrieves filtered todo items based on priority and/or end date
        /// </summary>
        /// <param name="priority">Priority level to filter by</param>
        /// <param name="endDate">Maximum due date to filter by</param>
        /// <returns>List of filtered todo items</returns>
        public IActionResult GetFilteredTodos([FromQuery] int? priority, [FromQuery] DateTime? endDate)
        {
            try
            {
                var todosQuery = _unitOfWork.Todos.Get();

                if (priority.HasValue)
                {
                    var priorityEnum = (TodoPriority)priority.Value;
                    todosQuery = todosQuery.Where(todo => todo.Priority == priorityEnum);
                }

                // Apply due date filter if provided
                if (endDate.HasValue)
                {
                    todosQuery = todosQuery.Where(todo => todo.DueDate <= endDate.Value.Date);
                }

                // Fetch filtered results
                var todos = todosQuery.ToList();

                return Ok(todos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
 
            
        
        




        

