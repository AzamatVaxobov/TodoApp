namespace TodoApp.Service.Dto;

public class CreateUpdateTodoDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
}