using FirstAPI.Dtos;

namespace FirstAPI.Services;

public interface ITodoService
{
    Task<PagedResult<TodoItemDto>> GetAllAsync(TodoQueryParams queryParams);
    Task<TodoItemDto?> GetByIdAsync(int id);
    Task<TodoItemDto> CreateAsync(CreateTodoItemDto dto);
    Task<bool> UpdateAsync(int id, CreateTodoItemDto dto);
    Task<bool> DeleteAsync(int id);
}