    const apiUrl = "https://localhost:5001/api/todos";

    document.addEventListener("DOMContentLoaded", function() {
        loadTodos();
        document.getElementById("statusFilter").addEventListener("change", loadTodos);

        document.getElementById("todoForm").addEventListener("submit", function(e) {
            e.preventDefault();
            const todo = {
                id: document.getElementById("todoId").value,
                title: document.getElementById("title").value,
                description: document.getElementById("description").value,
                status: document.getElementById("status").value,
                priority: document.getElementById("priority").value,
                dueDate: document.getElementById("dueDate").value || null
            };
            const method = todo.id ? 'PUT' : 'POST';
            const url = todo.id ? `${apiUrl}/${todo.id}` : apiUrl;
            fetch(url, {
                method,
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(todo)
            }).then(loadTodos);
            bootstrap.Modal.getInstance(document.getElementById('todoModal')).hide();
        });
    });

    function loadTodos() {
        let filter = document.getElementById("statusFilter").value;
        fetch(apiUrl)
            .then(res => res.json())
            .then(todos => {
                let filtered = filter ? todos.filter(t => t.status === filter) : todos;
                document.getElementById("todoTable").innerHTML = filtered.map(t => `
                    <tr>
                        <td>${t.title}</td>
                        <td>${t.status}</td>
                        <td>${t.priority}</td>
                        <td>${t.dueDate ? t.dueDate.split('T')[0] : ''}</td>
                        <td>
                            <button class="btn btn-sm btn-warning" onclick='editTodo(${JSON.stringify(t)})'>Edit</button>
                            <button class="btn btn-sm btn-danger" onclick='deleteTodo("${t.id}")'>Delete</button>
                        </td>
                    </tr>`).join('');
            });
    }

    function editTodo(todo) {
        document.getElementById("todoId").value = todo.id;
        document.getElementById("title").value = todo.title;
        document.getElementById("description").value = todo.description || "";
        document.getElementById("status").value = todo.status;
        document.getElementById("priority").value = todo.priority;
        document.getElementById("dueDate").value = todo.dueDate ? todo.dueDate.split('T')[0] : "";
        new bootstrap.Modal(document.getElementById('todoModal')).show();
    }

    function deleteTodo(id) {
        if (confirm("Are you sure you want to delete this todo?")) {
            fetch(`${apiUrl}/${id}`, { method: 'DELETE' })
                .then(loadTodos);
        }
    }
