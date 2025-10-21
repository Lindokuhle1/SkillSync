using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkillSync.Application.Common.Interfaces;
using SkillSync.Application.Interfaces;
using SkillSync.Infrastructure.Persistence;
using SkillSync.Infrastructure.Repositories;

namespace SkillSync.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
               this IServiceCollection services,
               IConfiguration configuration)
        {
            // Configure database (SQLite for now)
            services.AddDbContext<SkillSyncDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

            // Register DbContext as the IApplicationDbContext interface
            services.AddScoped<IApplicationDbContext>(provider =>
                provider.GetRequiredService<SkillSyncDbContext>());

            // Register generic repository for DI
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // Here’s where you’d register other infrastructure services
            // e.g., email sender, file storage, external API clients, etc.
            // services.AddScoped<IEmailService, EmailService>();

            return services;
        }
    }
}
