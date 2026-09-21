using FirstAPI.Dtos;
using FirstAPI.Models;
using FirstAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers;

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
    public async Task<ActionResult<List<TodoItemDto>>> getAll()
    {
        return Ok(await _todoService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TodoItem>> GetById(int id)
    {
        var item = await _todoService.GetByIdAsync(id);
        if(item is null) return NotFound();
        return Ok(item);
    }

    [HttpPost]
    public async Task<ActionResult<TodoItemDto>> Create([FromBody] CreateTodoItemDto dto)
    {
        var created = await _todoService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] CreateTodoItemDto dto)
    {
        var success = await _todoService.UpdateAsync(id, dto);
        if(!success) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _todoService.DeleteAsync(id);
        if(!success) return NotFound();
        return NoContent();
    }
}





