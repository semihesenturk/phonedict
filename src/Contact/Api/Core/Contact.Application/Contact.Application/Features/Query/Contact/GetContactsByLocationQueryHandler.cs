using AutoMapper;
using Contact.Application.Interfaces.Repositories;
using MediatR;
using PhoneDict.Common.Models.ViewModels;

namespace Contact.Application.Features.Query.Contact;

public class GetContactsByLocationQueryHandler : IRequestHandler<GetContactsByLocationQuery, List<ContactViewModel>>
{
    #region MyRegion
    private readonly IContactRepository _contactRepository;
    private readonly IMapper _mapper;
    #endregion
    #region Constructor
    public GetContactsByLocationQueryHandler(IContactRepository contactRepository, IMapper mapper)
    {
        _contactRepository = contactRepository;
        _mapper = mapper;
    }
    #endregion
    public async Task<List<ContactViewModel>> Handle(GetContactsByLocationQuery request, CancellationToken cancellationToken)
    {
        var result = await _contactRepository.GetContactsByLocation(request.Location);

        return result;
    }
}
