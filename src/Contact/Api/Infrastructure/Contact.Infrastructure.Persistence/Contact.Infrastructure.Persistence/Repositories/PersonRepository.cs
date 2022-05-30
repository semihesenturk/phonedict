using Contact.Application.Interfaces.Repositories;
using Contact.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Contact.Infrastructure.Persistence.Repositories;

public class PersonRepository : GenericRepository<Domain.Models.Person>, IPersonRepository
{
    #region Constructor
    public PersonRepository(ContactContext contactContext) : base(contactContext)
    {
    } 
    #endregion
}
