using AutoMapper;
using EventTracingBackend.Dto;
using EventTracingBackend.Models;

namespace EventTracingBackend.AutoMapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Event, EventDto>();
        }
    }
}
