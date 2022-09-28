

using AutoMapper;
using PeakBaggerAPI.Models;
using PeakBaggerAPI.Dtos;

namespace PeakBaggerAPI.Profiles
{
    public class CountryProfile : Profile
    {
         public CountryProfile()
        {
            // Source -> Target
            CreateMap<Country, CountryReadDto>();
            CreateMap<CountryCreateDto, Country>();
            CreateMap<CountryUpdateDto, Country>();
            
        }        
    }
}
