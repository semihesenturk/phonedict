using AutoMapper;
using Contact.Domain.Models;
using PhoneDict.Common.Models.RequestModels;
using PhoneDict.Common.Models.ViewModels;

namespace Contact.Application.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreatePersonCommand, Person>()
            .ReverseMap();

        CreateMap<CreateContactToPersonCommand, Domain.Models.Contact>()
            .ReverseMap();

        CreateMap<PersonViewModel, Person>()
            .ReverseMap();

        CreateMap<ContactViewModel, Domain.Models.Contact>()
            .ReverseMap();

        CreateMap<PersonDetailViewModel, Person>()
            .ReverseMap();
    }
}
