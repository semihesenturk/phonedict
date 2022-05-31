namespace PhoneDict.Common.Models.ViewModels;

public class ContactViewModel
{
    public Guid Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public string PhoneNumber { get; set; }
    public string EmailAddress { get; set; }
    public string Location { get; set; }
    public Guid PersonId { get; set; }

    public PersonViewModel Person { get; set; }
}
