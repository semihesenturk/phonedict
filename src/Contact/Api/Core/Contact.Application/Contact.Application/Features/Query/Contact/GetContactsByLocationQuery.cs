using MediatR;
using PhoneDict.Common.Models.Enums;
using PhoneDict.Common.Models.ViewModels;

namespace Contact.Application.Features.Query.Contact;

public class GetContactsByLocationQuery : IRequest<List<ContactViewModel>>
{
    public Location Location { get; set; }

    public GetContactsByLocationQuery(Location location)
    {
        Location = location;
    }
}
