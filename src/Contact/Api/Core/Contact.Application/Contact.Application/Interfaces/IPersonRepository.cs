using Contact.Application.Interfaces.Repositories;
using Contact.Domain.Models;

namespace Contact.Application.Interfaces;

public interface IPersonRepository : IGenericRepository<Person>
{
}
