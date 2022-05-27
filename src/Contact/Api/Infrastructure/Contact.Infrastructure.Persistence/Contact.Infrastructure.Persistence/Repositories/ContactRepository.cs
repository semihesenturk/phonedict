using Contact.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Contact.Infrastructure.Persistence.Repositories;

public class ContactRepository : GenericRepository<Domain.Models.Contact>, IContactRepository
{
    #region Constructor
    public ContactRepository(DbContext contactContext) : base(contactContext)
    {
    } 
    #endregion
}
