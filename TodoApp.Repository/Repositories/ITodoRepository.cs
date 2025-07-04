using TodoApp.DataAccess.Entities;

namespace TodoApp.Repository.Interfaces
{
    public interface ITodoRepository
    {

        Task<IEnumerable<Todo>> GetAllAsync();
        Task<Todo> GetByIdAsync(int id);
        Task AddAsync(Todo todo);
        Task UpdateAsync(Todo todo);
        Task DeleteAsync(int id);
    }
}