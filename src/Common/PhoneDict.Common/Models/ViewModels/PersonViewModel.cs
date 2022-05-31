namespace PhoneDict.Common.Models.ViewModels;

public class PersonViewModel
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Company { get; set; }
}
