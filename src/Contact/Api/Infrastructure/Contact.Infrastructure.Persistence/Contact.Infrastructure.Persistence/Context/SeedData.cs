using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Contact.Infrastructure.Persistence.Context;

internal class SeedData
{
    private static List<Domain.Models.Person> GetPersons()
    {
        var result = new Faker<Domain.Models.Person>("tr")
            .RuleFor(i => i.Id, i => Guid.NewGuid())
            .RuleFor(i => i.CreateDate, i => i.Date.Between(DateTime.Now.AddDays(-100), DateTime.Now))
            .RuleFor(i => i.FirstName, i => i.Person.FirstName)
            .RuleFor(i => i.LastName, i => i.Person.LastName)
            .RuleFor(i => i.Company, i => i.Company.CompanyName())
            .Generate(100);

        return result;
    }

    public async Task SeedAsync(IConfiguration configuration)
    {
        var dbContextBuilder = new DbContextOptionsBuilder();
        dbContextBuilder.UseNpgsql();

        var context = new ContactContext(dbContextBuilder.Options);

        if (context.Persons.Any())
        {
            await Task.CompletedTask;
            return;
        }

        //Seed person datas
        var persons = GetPersons();
        var personIds = persons.Select(i => i.Id);

        await context.AddRangeAsync(persons);

        //Seed contact datas
        var guids = Enumerable.Range(0, 100).Select(i => Guid.NewGuid()).ToList();
        var counter = 0;

        var contacts = new Faker<Domain.Models.Contact>("tr")
            .RuleFor(i => i.Id, i => guids[counter++])
            .RuleFor(i => i.CreateDate, i => i.Date.Between(DateTime.Now.AddDays(-100), DateTime.Now))
            .RuleFor(i => i.PersonId, i => i.PickRandom(personIds))
            .RuleFor(i => i.PhoneNumber, i => i.Phone.PhoneNumber())
            .RuleFor(i => i.EmailAddress, i => i.Internet.Email())
            .RuleFor(i => i.Location, i => i.Address.City())
            .Generate(100);

        await context.Contacts.AddRangeAsync(contacts);

        //Save all fake datas
        await context.SaveChangesAsync();
    }
}
