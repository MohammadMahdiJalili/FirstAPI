using FirstAPI.Data;
using FirstAPI.Dtos;
using FirstAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Services;

public class CategoryService : ICategoryService
{
    private readonly AppDbContext _context;

    public CategoryService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<CategoryDto> CreateAsync(CreateCategoryDto Dto)
    {
        var entity = new Category {Name = Dto.Name, IsActive = true};
        _context.Categories.Add(entity);
        await _context.SaveChangesAsync();

        return new CategoryDto {Id = entity.Id, Name = entity.Name, IsActive = entity.IsActive};

    }

    public async Task<bool> DeactivateAsync(int id)
    {
        var category = await _context.Categories
        .Include(c => c.TodoItems)
        .FirstOrDefaultAsync(c => c.Id == id);

        if (category == null) return false;
        
        category.IsActive = false;

        foreach (var todoItem in category.TodoItems)
        {
            todoItem.IsActive = false;
        }

        await _context.SaveChangesAsync();

        return true;
 
    }
}