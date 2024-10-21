using AutoMapper;
using DelCars.Domain.Services;
using DelCars.Infra.CrossCutting.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddScoped<RentCarDomainService>();

            return services;
        }
    }
}
