using Contact.Application.Interfaces.Repositories;
using Contact.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Contact.Infrastructure.Persistence.Repositories;

public class ContactRepository : GenericRepository<Domain.Models.Contact>, IContactRepository
{
    #region Constructor
    public ContactRepository(ContactContext contactContext) : base(contactContext)
    {
    } 
    #endregion
}
