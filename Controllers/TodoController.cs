using FirstAPI.Dto;
using FirstAPI.Dtos;
using FirstAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TodoController : ControllerBase
{
    private readonly ITodoService _todoService;

    public TodoController(ITodoService todoService)
    {
        _todoService = todoService;
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<List<TodoItemDto>>>> GetAll()
    {
        var items = await _todoService.GetAllAsync();
        return Ok(ApiResponse<List<TodoItemDto>>.SuccessResponse(items));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<TodoItemDto>>> GetById(int id)
    {
        var item = await _todoService.GetByIdAsync(id);
        if(item is null)
            return NotFound(ApiResponse<TodoItemDto>.ErrorResponse("Todo not found."));
            
        return Ok(ApiResponse<TodoItemDto>.SuccessResponse(item));
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

    [HttpGet("boom")]
    public IActionResult Boom()
    {
        throw new Exception("Test Exception");
    }
}





