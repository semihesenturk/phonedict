using AutoMapper;
using Contact.Application.Interfaces.Repositories;
using Contact.Infrastructure.Persistence.Context;
using PhoneDict.Common.Models.Enums;
using PhoneDict.Common.Models.ViewModels;

namespace Contact.Infrastructure.Persistence.Repositories;

public class ContactRepository : GenericRepository<Domain.Models.Contact>, IContactRepository
{
    #region Variables
    private readonly IMapper _mapper;
    #endregion

    #region Constructor
    public ContactRepository(ContactContext contactContext, IMapper mapper) : base(contactContext)
    {
        _mapper = mapper;
    }
    #endregion

    public async Task<List<ContactViewModel>> GetContactsByLocation(Location location)
    {
        var result = GetList(s => s.Location == location.ToString()).GetAwaiter().GetResult();

        return _mapper.Map<List<ContactViewModel>>(result);
    }
}
