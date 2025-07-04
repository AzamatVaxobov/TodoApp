using TodoApp.Service.Dto;

namespace TodoApp.Service.Interfaces
{
    public interface ITodoService
    {
        Task<List<TodoDto>> GetAllTodosAsync();
        Task<TodoDto?> GetTodoByIdAsync(int id);
        Task CreateTodoAsync(CreateUpdateTodoDto todoDto);
        Task UpdateTodoAsync(int id, CreateUpdateTodoDto todoDto);
        Task DeleteTodoAsync(int id);
    }
}