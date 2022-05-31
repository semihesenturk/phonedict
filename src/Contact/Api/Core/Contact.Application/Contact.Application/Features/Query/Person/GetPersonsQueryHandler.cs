using AutoMapper;
using Contact.Application.Interfaces.Repositories;
using MediatR;
using PhoneDict.Common.Models.ViewModels;

namespace Contact.Application.Features.Query.Person
{
    public class GetPersonsQueryHandler : IRequestHandler<GetPersonsQuery, List<PersonViewModel>>
    {
        #region Variables
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public GetPersonsQueryHandler(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }
        #endregion

        public async Task<List<PersonViewModel>> Handle(GetPersonsQuery request, CancellationToken cancellationToken)
        {
            var result = await _personRepository.GetAll();

            return _mapper.Map<List<PersonViewModel>>(result);
        }
    }
}
