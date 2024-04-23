using Contracts;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace PoCStarterTemplate.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddSingleton<ILoggerManager, LoggerManager>();

        public static void ConfigureInMemoryContext(this IServiceCollection services) =>
            services.AddDbContext<RepositoryContext>(options =>
                options.UseInMemoryDatabase("PocDatabaseInMemory"));

        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureSqliteContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<RepositoryContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("sqliteConnection")));
    }
}
