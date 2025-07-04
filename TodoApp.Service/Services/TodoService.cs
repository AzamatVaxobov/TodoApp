using TodoApp.DataAccess.Entities;
using TodoApp.Repository.Interfaces;
using TodoApp.Service.Dto;
using TodoApp.Service.Interfaces;
using TodoApp.Service.Mappers;

namespace TodoApp.Service.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;

        public TodoService(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<List<TodoDto>> GetAllTodosAsync()
        {
            var todos = await _todoRepository.GetAllAsync();
            return TodoMapper.ToDtoList(todos);
        }

        public async Task<TodoDto?> GetTodoByIdAsync(int id)
        {
            var todo = await _todoRepository.GetByIdAsync(id);
            if (todo == null)
            {
                throw new ArgumentException($"Todo with ID {id} not found.");
            }
            return TodoMapper.ToDto(todo);
        }

        public async Task CreateTodoAsync(CreateUpdateTodoDto todoDto)
        {
            var todo = TodoMapper.ToEntity(todoDto);
            await _todoRepository.AddAsync(todo);
        }

        public async Task UpdateTodoAsync(int id, CreateUpdateTodoDto todoDto)
        {
            var existingTodo = await _todoRepository.GetByIdAsync(id);
            if (existingTodo == null)
            {
                throw new ArgumentException($"Todo with ID {id} not found.");
            }

            existingTodo.Title = todoDto.Title;
            existingTodo.Description = todoDto.Description;
            existingTodo.IsCompleted = todoDto.IsCompleted;

            await _todoRepository.UpdateAsync(existingTodo);
        }

        public async Task DeleteTodoAsync(int id)
        {
            var todo = await _todoRepository.GetByIdAsync(id);

            if (todo == null)
            {
                throw new ArgumentException($"Todo with ID {id} not found.");
            }

            await _todoRepository.DeleteAsync(id);
        }
    }
}