using Microsoft.AspNetCore.Mvc;
using TodoApp.Service.Dto;
using TodoApp.Service.Interfaces;

namespace TodoApp.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodoController : ControllerBase
{
    private readonly ITodoService _todoService;

    public TodoController(ITodoService todoService)
    {
        _todoService = todoService;
    }


    [HttpGet]
    public async Task<IActionResult> GetAllTodos()
    {
        var todos = await _todoService.GetAllTodosAsync();
        return Ok(todos);
    }


    [HttpGet("{id}")]
    public async Task<IActionResult> GetTodoById(int id)
    {
        try
        {
            var todo = await _todoService.GetTodoByIdAsync(id);
            return Ok(todo);
        }
        catch (ArgumentException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateTodo([FromBody] CreateUpdateTodoDto todoDto)
    {
        try
        {
            await _todoService.CreateTodoAsync(todoDto);
            return Ok();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTodo(int id, [FromBody] CreateUpdateTodoDto todoDto)
    {
        try
        {
            await _todoService.UpdateTodoAsync(id, todoDto);
            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTodo(int id)
    {
        try
        {
            await _todoService.DeleteTodoAsync(id);
            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
}