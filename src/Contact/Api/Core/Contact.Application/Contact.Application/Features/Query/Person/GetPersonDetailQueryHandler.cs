using AutoMapper;
using Contact.Application.Interfaces.Repositories;
using MediatR;
using PhoneDict.Common.Models.ViewModels;

namespace Contact.Application.Features.Query.Person;

public class GetPersonDetailQueryHandler : IRequestHandler<GetPersonDetailQuery, PersonDetailViewModel>
{
    #region Variables
    private readonly IPersonRepository _personRepository;
    private readonly IMapper _mapper;
    #endregion

    #region Constructor
    public GetPersonDetailQueryHandler(IPersonRepository personRepository, IMapper mapper)
    {
        _personRepository = personRepository;
        _mapper = mapper;
    }
    #endregion

    public async Task<PersonDetailViewModel> Handle(GetPersonDetailQuery request, CancellationToken cancellationToken)
    {
        var dbUser = await _personRepository.GetSingleAsync(s => s.Id == request.PersonId, false, s => s.Contacts);

        return _mapper.Map<PersonDetailViewModel>(dbUser);
    }
}
