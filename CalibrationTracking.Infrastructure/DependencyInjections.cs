using CalibrationTracking.Infrastructure.Context;
using CalibrationTracking.Infrastructure.UserRepostories;
using CalibrationTracking.Infrastructure.UserRepostories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CalibrationTracking.Infrastructure
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("IsDevelopment"))
            {
                services.AddDbContext<CalibrationDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DevelopmentCalibrationDbConnection") ??
                    throw new InvalidOperationException("Connection string 'DevelopmentCalibrationDbConnection' not found."),
                    b => b.MigrationsAssembly(typeof(CalibrationDbContext).Assembly.FullName)), ServiceLifetime.Transient);
            }
            else
            {
                services.AddDbContext<CalibrationDbContext>(options =>
                  options.UseSqlServer(configuration.GetConnectionString("CalibrationDbConnection") ??
                    throw new InvalidOperationException("Connection string 'CalibrationDbConnection' not found."),
                    b => b.MigrationsAssembly(typeof(CalibrationDbContext).Assembly.FullName)), ServiceLifetime.Transient);
            }

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IRoleService, RoleService>();

            return services;
        }
    }
}