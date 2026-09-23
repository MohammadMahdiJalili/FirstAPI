using System.ComponentModel.DataAnnotations;

namespace FirstAPI.Dtos;

public class CreateTodoItemDto
{
    [Required(ErrorMessage = "Title is required.")]
    [StringLength(200, MinimumLength = 1, ErrorMessage = "Title must be between 1 and 200 character.")]
    public string Title { get; set; } = string.Empty;
    public bool IsComplete { get; set; }
    public int CategoryId { get; set; } 
}