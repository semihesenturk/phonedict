using MediatR;

namespace PhoneDict.Common.Models.RequestModels;

public class CreatePersonCommand : IRequest<Guid>
{
    #region Constructors
    public CreatePersonCommand()
    {
    }
    public CreatePersonCommand(string firstName, string lastName, string company)
    {
        FirstName = firstName;
        LastName = lastName;
        Company = company;
    }
    #endregion

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Company { get; set; }
}
