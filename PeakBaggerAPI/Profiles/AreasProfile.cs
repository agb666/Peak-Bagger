using AutoMapper;
using PeakBaggerAPI.Models;
using PeakBaggerAPI.Dtos;

namespace PeakBaggerAPI.Profiles
{
    public class AreasProfile : Profile
    {

         public AreasProfile()
        {
            // Source -> Target
            CreateMap<Area, AreaReadDto>();
            CreateMap<AreaCreateDto, Area>();
            CreateMap<AreaUpdateDto, Area>();
            
        }        
    }
}