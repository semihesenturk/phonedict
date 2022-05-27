using Contact.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Contact.Infrastructure.Persistence.Repositories;

public class PersonRepository : GenericRepository<Domain.Models.Person>, IPersonRepository
{
    #region Constructor
    public PersonRepository(DbContext contactContext) : base(contactContext)
    {
    } 
    #endregion
}
