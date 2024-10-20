using AutoMapper;
using DelCars.Infra.CrossCutting.AutoMapper.MappingProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
