namespace Contact.Domain.Models;

public class Contact : BaseEntity
{
    public string PhoneNumber { get; set; }
    public string EmailAddress { get; set; }
    public string Location { get; set; }
    public Guid PersonId { get; set; }

    public Person Person { get; set; }

}
