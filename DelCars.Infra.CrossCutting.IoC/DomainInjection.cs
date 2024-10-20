using AutoMapper;
using DelCars.Domain.Services;
using DelCars.Infra.CrossCutting.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelCars.Infra.CrossCutting.IoC
{
    public static class DomainInjection
    {
        public static IServiceCollection ConfigureDomain(this IServiceCollection services)
        {
            //AutoMapper
            var config = AutoMapperConfig.RegisterMapping();
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            //Domain
            services.AddScoped<CarsDomainService>();

            return services;
        }
    }
}
