using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ApplicationServiceRegistration).Assembly);
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssemblies(typeof(ApplicationServiceRegistration).Assembly);
            });

            return services;
        }
    }
}
