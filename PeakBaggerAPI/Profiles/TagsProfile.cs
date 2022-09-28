using AutoMapper;
using PeakBaggerAPI.Models;
using PeakBaggerAPI.Dtos;

namespace PeakBaggerAPI.Profiles
{
    public class TagsProfile : Profile
    {

         public TagsProfile()
        {
            // Source -> Target
            CreateMap<Tag, TagReadDto>();
            CreateMap<TagCreateDto, Tag>();
            CreateMap<TagUpdateDto, Tag>();
            CreateMap<Tag, TagUpdateDto>();   //Patch
        }
    }
}
