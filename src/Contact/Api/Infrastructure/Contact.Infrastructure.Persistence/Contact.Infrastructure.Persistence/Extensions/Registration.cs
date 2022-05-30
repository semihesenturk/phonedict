using Contact.Application.Interfaces.Repositories;
using Contact.Infrastructure.Persistence.Context;
using Contact.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Contact.Infrastructure.Persistence.Extensions;

public static class Registration
{
    public static IServiceCollection AddInfrastructureRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ContactContext>(options 
            => options.UseNpgsql("User ID=esenturk;Password=123456789Se;Host=localhost;Port=5432;Database=PhoneDictDb;"));


        #region Seed Data
        var seedData = new SeedData();
        seedData.SeedAsync(configuration).GetAwaiter().GetResult();
        #endregion

        services.AddScoped<IPersonRepository, PersonRepository>();
        services.AddScoped<IContactRepository, ContactRepository>();

        return services;
    }


}
