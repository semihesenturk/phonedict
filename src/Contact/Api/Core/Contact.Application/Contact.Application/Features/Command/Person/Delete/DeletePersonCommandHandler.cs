using Contact.Application.Interfaces.Repositories;
using MediatR;
using PhoneDict.Common.Models.RequestModels;

namespace Contact.Application.Features.Command.Person.Delete;

public class DeletePersonCommandHandler : IRequestHandler<DeletePersonCommand, bool>
{
    #region Variables
    private readonly IPersonRepository _personRepository;
    #endregion

    #region Constructor
    public DeletePersonCommandHandler(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }
    #endregion

    public async Task<bool> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
    {
        var result = await _personRepository.DeleteAsync(request.PersonId);

        if (result > 0)
            return true;
        else
            return false;
    }
}
