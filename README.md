Task Description
This project is a simple Todo Management application that implements basic CRUD operations, status management, and other features like filtering and validation. The backend is built with .NET 9, and the frontend uses Bootstrap for a simple user interface.

Core Features:
CRUD operations: Create, Read, Update, Delete todos.

Filtering by status: View todos based on their status (Pending, InProgress, Completed).

Mark todo as complete: Ability to mark a todo as completed.

Basic validation: Ensures title is required and due dates are valid.

Data Model:
Todo

Id (Guid) - Unique identifier for each todo.

Title (required, max 100 chars) - The title of the todo.

Description (optional) - A description of the todo.

Status (Pending/InProgress/Completed) - The current status of the todo.

Priority (Low/Medium/High) - Priority level of the todo.

DueDate (optional) - The due date for the todo.

CreatedDate - The date when the todo was created.

LastModifiedDate - The date when the todo was last modified.

Technical Requirements:
Backend:
ASP.NET Core 9

Entity Framework Core

Error handling: Proper error handling for all operations.

CRUD operations for todos.

Frontend:
Bootstrap: Simple Bootstrap interface for managing todos.

Todo list with status filter: Filter todos by their status.

Create/Edit form: Form for creating and editing todos.

Delete confirmation: Confirmation before deleting a todo.

Bonus Features:
DDD principles: Using Domain-Driven Design (DDD).

Domain events: Example event like TodoCompletedEvent.

Additional filters: Adding priority and date range filters.

Sorting options: Sort todos by different fields.

API Documentation: Basic API documentation using Swagger or similar.

Setup Instructions:
1-git clone <repository-url>//Clone the repository to your local machine
2-cd TodoManagementAPI//Navigate to the project folder
3-dotnet restore //Restore NuGet packages:
4-dotnet ef database update //Apply database migrations
5-dotnet run//Run the application

Front end 
1-cd front end // to navigate front end file 
2-Update the API endpoint to point to your local backend server ex:(const apiUrl = 'https://localhost:5001/api/todos'; // Update this URL if necessary
)



