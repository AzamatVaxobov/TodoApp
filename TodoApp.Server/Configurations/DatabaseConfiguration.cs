using DataAccess;
using Microsoft.EntityFrameworkCore;
using TodoApp.DataAccess;

namespace TodoApp.Server.Configurations
{
    public static class DatabaseConfiguration
    {
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TodoDbContext>(options =>
                options.UseMySql(
                    configuration.GetConnectionString("DefaultConnection"),
                    new MySqlServerVersion(new Version(8, 0, 42)) // match your version
                ));
        }
    }
}
