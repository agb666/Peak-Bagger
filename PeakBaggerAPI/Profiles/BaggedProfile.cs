using AutoMapper;
using PeakBaggerAPI.Models;
using PeakBaggerAPI.Dtos;

namespace PeakBaggerAPI.Profiles
{
    public class BaggedProfile : Profile
    {

        public BaggedProfile()
        {
            // Source -> Target
            CreateMap<Bagged, BaggedReadDto>();
            CreateMap<BaggedCreateDto, Bagged>();
            CreateMap<BaggedUpdateDto, Bagged>();
            CreateMap<Bagged, BaggedUpdateDto>();   //Patch
        }
    }
}