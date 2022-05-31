using MediatR;
using PhoneDict.Common.Models.ViewModels;

namespace Contact.Application.Features.Query.Person;

public class GetPersonQuery : IRequest<PersonViewModel>
{
    #region Constructor
    public GetPersonQuery(Guid personId)
    {
        PersonId = personId;
    }
    #endregion
    public Guid PersonId { get; set; }
}
