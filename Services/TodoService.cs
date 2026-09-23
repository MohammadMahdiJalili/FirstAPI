using FirstAPI.Data;
using FirstAPI.Dtos;
using FirstAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Services;

public class TodoService : ITodoService
{
    private readonly AppDbContext _context;

    public TodoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<TodoItemDto>> GetAllAsync()
    {
        return await _context.TodoItems
            .Select(t => new TodoItemDto
                {
                    Id = t.Id,
                    Title = t.Title,
                    IsComplete = t.IsComplete,
                    IsActive = t.IsActive
                })
            .ToListAsync();
    }

    public async Task<TodoItemDto?> GetByIdAsync(int id)
    {
        var item = await _context.TodoItems.FindAsync(id);
        if(item is null) return null;

        return new TodoItemDto
        {
            Id = item.Id,
            Title = item.Title,
            IsComplete = item.IsComplete,
            IsActive = item.IsActive
        };
    }

    public async Task<TodoItemDto> CreateAsync(CreateTodoItemDto dto)
    {
        var entity = new TodoItem
        {
            Title = dto.Title,
            IsComplete = dto.IsComplete,
            CategoryId = dto.CategoryId
        };
        _context.TodoItems.Add(entity);
        await _context.SaveChangesAsync();

        return new TodoItemDto
        {
            Id = entity.Id,
            Title = entity.Title,
            IsComplete = entity.IsComplete,
            IsActive = entity.IsActive
        };
    }

    public async Task<bool> UpdateAsync(int id, CreateTodoItemDto dto)
    {
        var existing = await _context.TodoItems.FindAsync(id);
        if(existing is null) return false;

        existing.Title = dto.Title;
        existing.IsComplete = dto.IsComplete;
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var existing = await _context.TodoItems.FindAsync(id);
        if(existing is null) return false;

        _context.TodoItems.Remove(existing);
        await _context.SaveChangesAsync();
        return true;
    }
}
