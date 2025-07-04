using Moq; // For mocking dependencies
using Xunit; // For testing framework
using Microsoft.AspNetCore.Mvc; // For HTTP response types
using System.Threading.Tasks; // For async handling
using System.Collections.Generic; // For lists
using TodoApp.Server.Controllers; // Adjust based on your actual project namespace
using TodoApp.Service.Interfaces; // For ITodoService
using TodoApp.Service.Dto; // For DTOs

namespace TodoApp.Tests.Controllers
{
    public class TodoControllerTests
    {
        private readonly Mock<ITodoService> _todoServiceMock; // Mock ITodoService
        private readonly TodoController _todoController; // Subject Under Test (SUT)

        public TodoControllerTests()
        {
            // Setup the mock service
            _todoServiceMock = new Mock<ITodoService>();

            // Inject the mocked service into the controller
            _todoController = new TodoController(_todoServiceMock.Object);
        }

        [Fact]
        public async Task GetAllTodos_ShouldReturnOkWithTodos()
        {
            // Arrange
            var todos = new List<TodoDto>
            {
                new TodoDto { Id = 1, Title = "Learn xUnit", Description = "Write controller tests", IsCompleted = false },
                new TodoDto { Id = 2, Title = "Master Moq", Description = "Learn mocking", IsCompleted = true }
            };
            _todoServiceMock.Setup(s => s.GetAllTodosAsync()).ReturnsAsync(todos);

            // Act
            var result = await _todoController.GetAllTodos();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result); // HTTP 200
            var returnedTodos = Assert.IsType<List<TodoDto>>(okResult.Value); // Extract value from OkObjectResult
            Assert.Equal(2, returnedTodos.Count); // Verify returned data
        }

        [Fact]
        public async Task GetTodoById_ShouldReturnOk_WhenTodoExists()
        {
            // Arrange
            var todo = new TodoDto
            {
                Id = 1,
                Title = "Test GetTodoById",
                Description = "Should return 200",
                IsCompleted = false
            };
            _todoServiceMock.Setup(s => s.GetTodoByIdAsync(1)).ReturnsAsync(todo);

            // Act
            var result = await _todoController.GetTodoById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result); // HTTP 200
            var returnedTodo = Assert.IsType<TodoDto>(okResult.Value); // Assert returned value is of type TodoDto
            Assert.Equal(1, returnedTodo.Id); // Verify data
            Assert.Equal("Test GetTodoById", returnedTodo.Title);
        }

        [Fact]
        public async Task GetTodoById_ShouldReturnNotFound_WhenTodoDoesNotExist()
        {
            // Arrange
            _todoServiceMock.Setup(s => s.GetTodoByIdAsync(It.IsAny<int>())).Throws<ArgumentException>();

            // Act
            var result = await _todoController.GetTodoById(999);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result); // HTTP 404
            Assert.Equal(404, notFoundResult.StatusCode);
        }

        [Fact]
        public async Task CreateTodo_ShouldReturnOk_WhenTodoIsCreated()
        {
            // Arrange
            var newTodo = new CreateUpdateTodoDto
            {
                Title = "Build TodoApp",
                Description = "Write CreateTodo test",
                IsCompleted = false
            };

            // Act
            var result = await _todoController.CreateTodo(newTodo);

            // Assert
            Assert.IsType<OkResult>(result); // HTTP 200
            _todoServiceMock.Verify(s => s.CreateTodoAsync(newTodo), Times.Once); // Verify service call
        }

        [Fact]
        public async Task UpdateTodo_ShouldReturnNoContent_WhenTodoIsUpdated()
        {
            // Arrange
            var todoUpdateDto = new CreateUpdateTodoDto
            {
                Title = "Update Todo",
                Description = "Update an existing todo",
                IsCompleted = true
            };

            // Act
            var result = await _todoController.UpdateTodo(1, todoUpdateDto);

            // Assert
            Assert.IsType<NoContentResult>(result); // HTTP 204
            _todoServiceMock.Verify(s => s.UpdateTodoAsync(1, todoUpdateDto), Times.Once); // Verify service call
        }

        [Fact]
        public async Task UpdateTodo_ShouldReturnNotFound_WhenTodoDoesNotExist()
        {
            // Arrange
            _todoServiceMock.Setup(s => s.UpdateTodoAsync(It.IsAny<int>(), It.IsAny<CreateUpdateTodoDto>()))
                            .Throws<ArgumentException>();

            // Act
            var result = await _todoController.UpdateTodo(999, new CreateUpdateTodoDto());

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result); // HTTP 404
            Assert.Equal(404, notFoundResult.StatusCode);
        }

        [Fact]
        public async Task DeleteTodo_ShouldReturnNoContent_WhenTodoIsDeleted()
        {
            // Arrange
            _todoServiceMock.Setup(s => s.DeleteTodoAsync(1)).Returns(Task.CompletedTask);

            // Act
            var result = await _todoController.DeleteTodo(1);

            // Assert
            Assert.IsType<NoContentResult>(result); // HTTP 204
            _todoServiceMock.Verify(s => s.DeleteTodoAsync(1), Times.Once); // Verify service call
        }

        [Fact]
        public async Task DeleteTodo_ShouldReturnNotFound_WhenTodoDoesNotExist()
        {
            // Arrange
            _todoServiceMock.Setup(s => s.DeleteTodoAsync(It.IsAny<int>())).Throws<ArgumentException>();

            // Act
            var result = await _todoController.DeleteTodo(999);

            // Assert
            var notFoundResult = Assert.IsType<NotFoundObjectResult>(result); // HTTP 404
            Assert.Equal(404, notFoundResult.StatusCode);
        }
    }
}