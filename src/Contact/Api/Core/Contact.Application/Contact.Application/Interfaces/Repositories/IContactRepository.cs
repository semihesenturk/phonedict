using PhoneDict.Common.Models.Enums;
using PhoneDict.Common.Models.ViewModels;

namespace Contact.Application.Interfaces.Repositories
{
    public interface IContactRepository : IGenericRepository<Domain.Models.Contact>
    {
        Task<List<ContactViewModel>> GetContactsByLocation(Location location);
    }
}
