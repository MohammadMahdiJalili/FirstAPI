namespace FirstAPI.Dtos;

public class TodoQueryParams
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public bool? IsComplete { get; set; }
}