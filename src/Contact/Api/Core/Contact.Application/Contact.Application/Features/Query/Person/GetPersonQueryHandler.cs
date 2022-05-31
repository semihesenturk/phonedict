using AutoMapper;
using Contact.Application.Interfaces.Repositories;
using MediatR;
using PhoneDict.Common.Models.ViewModels;

namespace Contact.Application.Features.Query.Person;

public class GetPersonQueryHandler : IRequestHandler<GetPersonQuery, PersonViewModel>
{
    #region Variables
    private readonly IPersonRepository _personRepository;
    private readonly IMapper _mapper;
    #endregion

    #region Constructor
    public GetPersonQueryHandler(IPersonRepository personRepository, IMapper mapper)
    {
        _personRepository = personRepository;
        _mapper = mapper;
    }
    #endregion

    public async Task<PersonViewModel> Handle(GetPersonQuery request, CancellationToken cancellationToken)
    {
        var dbUser = await _personRepository.GetByIdAsync(request.PersonId);

        return _mapper.Map<PersonViewModel>(dbUser);
    }
}
