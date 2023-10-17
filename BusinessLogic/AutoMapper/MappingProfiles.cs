using AutoMapper;
using EventTracingBackend;

namespace EventTracingBackend.BusinessLogic
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Event, EventDto>();
        }
    }
}
