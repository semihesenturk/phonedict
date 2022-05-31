using MediatR;
using PhoneDict.Common.Models.ViewModels;

namespace Contact.Application.Features.Query.Person;

public class GetPersonsQuery : IRequest<List<PersonViewModel>>
{
}
