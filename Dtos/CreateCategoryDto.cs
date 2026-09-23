using System.ComponentModel.DataAnnotations;

namespace FirstAPI.Dtos;

public class CreateCategoryDto
{
    [Required(ErrorMessage = "Name is required.")]
    [StringLength(100, MinimumLength = 1)]
    public string  Name { get; set; } = string.Empty;
}