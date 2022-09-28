using AutoMapper;
using PeakBaggerAPI.Models;
using PeakBaggerAPI.Dtos;

namespace PeakBaggerAPI.Profiles
{
    public class PeaksProfile : Profile
    {

         public PeaksProfile()
        {
            // Source -> Target
            CreateMap<Peak, PeakReadDto>();
            CreateMap<PeakCreateDto, Peak>();
            CreateMap<PeakUpdateDto, Peak>();

        }
        

    }
}
