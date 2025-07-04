using TodoApp.DataAccess.Entities;
using TodoApp.Service.Dto;

namespace TodoApp.Service.Mappers
{
    public static class TodoMapper
    {
        public static TodoDto ToDto(Todo todo)
        {
            return new TodoDto
            {
                Id = todo.Id,
                Title = todo.Title,
                Description = todo.Description,
                IsCompleted = todo.IsCompleted,
                CreatedAt = todo.CreatedAt
            };
        }


        public static Todo ToEntity(CreateUpdateTodoDto todoDto)
        {
            return new Todo
            {
                Title = todoDto.Title,
                Description = todoDto.Description,
                IsCompleted = todoDto.IsCompleted
            };
        }


        public static List<TodoDto> ToDtoList(IEnumerable<Todo> todos)
        {
            return todos.Select(todo => ToDto(todo)).ToList();
        }
    }
}