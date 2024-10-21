using AutoMapper;
using DelCars.Infra.CrossCutting.AutoMapper.MappingProfiles;

namespace DelCars.Infra.CrossCutting.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMapping()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ViewModelToDomainMappingProfile());
            });
        }
    }
}
