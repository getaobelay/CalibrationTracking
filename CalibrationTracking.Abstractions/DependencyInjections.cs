using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using CalibrationTracking.Abstractions.Behaviors;
using CalibrationTracking.Abstractions.Base;

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
