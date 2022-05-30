using AutoMapper;
using Contact.Domain.Models;
using PhoneDict.Common.Models.RequestModels;

namespace Contact.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreatePersonCommand, Person>()
            .ReverseMap();
    }
}
