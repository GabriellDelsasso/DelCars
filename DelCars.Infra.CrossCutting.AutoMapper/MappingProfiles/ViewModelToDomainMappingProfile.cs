using AutoMapper;
using DelCars.Application.ViewModels;
using DelCars.Domain.Models.Car;

namespace DelCars.Infra.CrossCutting.AutoMapper.MappingProfiles
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CarViewModel, Car>();
        }
    }
}
