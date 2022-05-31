using MediatR;
using PhoneDict.Common.Models.ViewModels;

namespace Contact.Application.Features.Query.Person;

public class GetPersonDetailQuery : IRequest<PersonDetailViewModel>
{
    #region Constructor
    public GetPersonDetailQuery(Guid personId)
    {
        PersonId = personId;
    }
    #endregion

    public Guid PersonId { get; set; }
}
