using Moq;
using Xunit;
using System.Threading.Tasks;
using System.Collections.Generic;
using TodoApp.Service.Interfaces;
using TodoApp.Service.Services;
using TodoApp.Repository.Interfaces;
using TodoApp.DataAccess.Entities;
using TodoApp.Service.Dto;

namespace TodoApp.Tests.Services
{
    public class TodoServiceTests
    {
        private readonly Mock<ITodoRepository> _todoRepositoryMock;
        private readonly ITodoService _todoService;

        public TodoServiceTests()
        {
            // Setup mock repository
            _todoRepositoryMock = new Mock<ITodoRepository>();

            // Inject mock into the service
            _todoService = new TodoService(_todoRepositoryMock.Object);
        }

        [Fact]
        public async Task GetAllTodosAsync_ShouldReturnListOfTodos()
        {
            // Arrange
            var todos = new List<Todo>
            {
                new Todo { Id = 1, Title = "Learn Unit Testing", Description = "Test the Service Layer", IsCompleted = false },
                new Todo { Id = 2, Title = "Write Tests", Description = "Use xUnit + Moq", IsCompleted = true }
            };

            _todoRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(todos);

            // Act
            var result = await _todoService.GetAllTodosAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("Learn Unit Testing", result[0].Title);
        }

        [Fact]
        public async Task GetTodoByIdAsync_ShouldReturnTodo_WhenTodoExists()
        {
            // Arrange
            var todo = new Todo { Id = 1, Title = "Learn xUnit" };
            _todoRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(todo);

            // Act
            var result = await _todoService.GetTodoByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Learn xUnit", result.Title);
        }

        [Fact]
        public async Task GetTodoByIdAsync_ShouldThrowArgumentException_WhenTodoNotFound()
        {
            // Arrange
            _todoRepositoryMock.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Todo)null);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => _todoService.GetTodoByIdAsync(1));
        }

        [Fact]
        public async Task CreateTodoAsync_ShouldCallAddAsyncOnce()
        {
            // Arrange
            var todoDto = new CreateUpdateTodoDto { Title = "New Todo", Description = "Write a new todo", IsCompleted = false };

            // Act
            await _todoService.CreateTodoAsync(todoDto);

            // Assert
            _todoRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Todo>()), Times.Once);
        }
    }
}