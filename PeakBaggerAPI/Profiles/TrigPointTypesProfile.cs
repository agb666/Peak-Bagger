using AutoMapper;
using PeakBaggerAPI.Models;
using PeakBaggerAPI.Dtos;

namespace PeakBaggerAPI.Profiles
{
    public class TrigPointTypesProfile : Profile
    {

         public TrigPointTypesProfile()
        {
            // Source -> Target
            CreateMap<TrigPointType, TrigPointTypeReadDto>();
           
        }
    }
}
