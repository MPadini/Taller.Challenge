using System;
using AutoMapper;
using code.challenge.Api.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace code.challenge.Api.Configurations
{
    public static class AutoMapperConfiguration
    {
        public static void AddMappers(this IServiceCollection services)
        {
            services.AddAutoMapper(new Type[] { typeof(ContractMapping) });
        }
    }
}
