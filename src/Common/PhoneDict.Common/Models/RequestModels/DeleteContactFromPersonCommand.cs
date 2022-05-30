using MediatR;

namespace PhoneDict.Common.Models.RequestModels;

public class DeleteContactFromPersonCommand : IRequest<bool>
{
    #region Constructor
    public DeleteContactFromPersonCommand(Guid contactId)
    {
        ContactId = contactId;
    }
    #endregion

    public Guid ContactId { get; set; }
}
