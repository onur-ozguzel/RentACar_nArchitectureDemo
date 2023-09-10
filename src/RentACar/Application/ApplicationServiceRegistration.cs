using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

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
