using code.challenge.Core.ServiceInterfaces;
using code.challenge.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace code.challenge.Service
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddTransient<IGetCarsService, GetCarsService>();
            services.AddTransient<IDeleteCarService, DeleteCarService>();
            services.AddTransient<IUpdateCarService, UpdateCarService>();
            services.AddTransient<ISaveCarService, SaveCarService>();

            return services;
        }
    }
}
