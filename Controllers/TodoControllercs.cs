using backend_todo.Data;
using backend_todo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_todo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly AppDbContext _context;

    public TodoController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<TodoTask>>> GetTodos()
    {
        var todos = await _context.Todos.ToListAsync();
        return Ok(todos);
    }

    [HttpPost]
    public async Task<ActionResult<TodoTask>> CreateTodo(TodoTask todo)
    {
        _context.Todos.Add(todo);
        await _context.SaveChangesAsync();

        return Ok(todo);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTodo(int id)
    {
        var todo = await _context.Todos.FindAsync(id);

        if (todo == null)
        {
            return NotFound();
        }

        _context.Todos.Remove(todo);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}