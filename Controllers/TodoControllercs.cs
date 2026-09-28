using backend_todo.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend_todo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private static readonly List<TodoTask> Todos = new();

    [HttpGet]
    public ActionResult<List<TodoTask>> GetTodos()
    {
        return Ok(Todos);
    }

    [HttpPost]
    public ActionResult<TodoTask> CreateTodo(TodoTask todo)
    {
        todo.Id = Todos.Count + 1;
        Todos.Add(todo);

        return Ok(todo);
    }
}