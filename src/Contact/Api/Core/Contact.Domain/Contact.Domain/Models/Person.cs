namespace Contact.Domain.Models;

public class Person : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Company { get; set; }

    public ICollection<Contact> Contacts { get; set; }
}
