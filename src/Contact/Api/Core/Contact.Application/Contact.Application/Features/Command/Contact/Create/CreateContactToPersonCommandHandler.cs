using AutoMapper;
using Contact.Application.Interfaces.Repositories;
using MediatR;
using PhoneDict.Common.Models.RequestModels;

namespace Contact.Application.Features.Command.Contact.Create;

public class CreateContactToPersonCommandHandler : IRequestHandler<CreateContactToPersonCommand, bool>
{
    #region Variables
    private readonly IContactRepository _contactRepository;
    private readonly IMapper _mapper;
    #endregion

    #region Constructor
    public CreateContactToPersonCommandHandler(IContactRepository contactRepository, IMapper mapper)
    {
        _contactRepository = contactRepository;
        _mapper = mapper;
    }
    #endregion

    public async Task<bool> Handle(CreateContactToPersonCommand request, CancellationToken cancellationToken)
    {
        var dbEntity = _mapper.Map<Domain.Models.Contact>(request);

        var result = await _contactRepository.AddAsync(dbEntity);

        if (result > 0)
            return true;
        else
            return false;
    }
}
