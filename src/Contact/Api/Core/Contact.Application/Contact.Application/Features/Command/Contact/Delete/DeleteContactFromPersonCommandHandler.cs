using Contact.Application.Interfaces.Repositories;
using MediatR;
using PhoneDict.Common.Models.RequestModels;

namespace Contact.Application.Features.Command.Contact.Delete;

public class DeleteContactFromPersonCommandHandler : IRequestHandler<DeleteContactFromPersonCommand, bool>
{
    #region Variables
    private readonly IContactRepository _contactRepository;
    #endregion

    #region Constructor
    public DeleteContactFromPersonCommandHandler(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }
    #endregion

    public async Task<bool> Handle(DeleteContactFromPersonCommand request, CancellationToken cancellationToken)
    {
        var result = await _contactRepository.DeleteAsync(request.ContactId);

        if (result > 0)
            return true;
        else
            return false;
    }
}
