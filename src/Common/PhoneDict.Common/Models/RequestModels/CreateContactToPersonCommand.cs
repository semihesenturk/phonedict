using MediatR;
using PhoneDict.Common.Models.Enums;

namespace PhoneDict.Common.Models.RequestModels;

public class CreateContactToPersonCommand : IRequest<bool>
{
    #region Constructor
    public CreateContactToPersonCommand(Guid personId,
                                        string phoneNumber,
                                        string emailAddress,
                                        Location location)
    {
        PersonId = personId;
        PhoneNumber = phoneNumber;
        EmailAddress = emailAddress;
        Location = location;
    }
    #endregion

    public Guid PersonId { get; set; }
    public string PhoneNumber { get; set; }
    public string EmailAddress { get; set; }
    public Location Location { get; set; }
}
