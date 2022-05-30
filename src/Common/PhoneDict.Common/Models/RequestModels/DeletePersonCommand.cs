using MediatR;

namespace PhoneDict.Common.Models.RequestModels;

public class DeletePersonCommand : IRequest<bool>
{
    #region Constructor
    public DeletePersonCommand(Guid personId)
    {
        PersonId = personId;
    }
    #endregion

    public Guid PersonId { get; set; }
}
