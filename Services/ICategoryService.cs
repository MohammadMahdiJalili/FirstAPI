using FirstAPI.Dtos;

namespace FirstAPI.Services;

public interface ICategoryService
{
    Task<CategoryDto> CreateAsync(CreateCategoryDto Dto);
    Task<bool> DeactivateAsync(int id);
}