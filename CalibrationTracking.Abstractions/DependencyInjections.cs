using CalibrationTracking.Abstractions.Base;
using CalibrationTracking.Abstractions.Behaviors;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CalibrationTracking.Abstractions
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services, Assembly assembly)
        {
            services.Scan(scan => scan
                      .FromAssemblies(assembly)
                        .AddClasses(classes => classes.AssignableTo(typeof(IBaseRepository<,>)))
                            .AsImplementedInterfaces()
                            .WithTransientLifetime());

            services.AddTransient(typeof(CalibrationTracking.Abstractions.Behaviors.IPipelineBehaviour<,>), typeof(ValidationBehaviour<,>));

            return services;
        }
    }
}