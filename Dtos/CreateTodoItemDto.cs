namespace FirstAPI.Dtos;

public class CreateTodoItemDto
{
    public string Title { get; set; } = string.Empty;
    public bool IsComplete { get; set; }
}