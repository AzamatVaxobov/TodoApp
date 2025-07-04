using TodoApp.Repository.Implementations;
using TodoApp.Repository.Interfaces;
using TodoApp.Service.Interfaces;
using TodoApp.Service.Services;

namespace TodoApp.Server.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Register Repositories
            services.AddScoped<ITodoRepository, TodoRepository>();

            // Register Services
            services.AddScoped<ITodoService, TodoService>();

            return services; // Return the updated IServiceCollection
        }
    }
}