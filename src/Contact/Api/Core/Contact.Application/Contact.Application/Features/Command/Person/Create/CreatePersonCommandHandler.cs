using AutoMapper;
using Contact.Application.Interfaces.Repositories;
using MediatR;
using PhoneDict.Common.Models.RequestModels;

namespace Contact.Application.Features.Command.Person.Create;

public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand, Guid>
{
    #region Variables
    private readonly IPersonRepository _personRepository;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public CreatePersonCommandHandler(IPersonRepository personRepository, IMapper mapper)
    {
        _personRepository = personRepository;
        _mapper = mapper;
    }
    #endregion

    public async Task<Guid> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
    {
        var dbEntry = _mapper.Map<Domain.Models.Person>(request);

        await _personRepository.AddAsync(dbEntry);

        return dbEntry.Id;
    }
}
