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
        services.AddDbContext<ContactContext>(
            conf =>
            {
                var connStr = configuration["SozlukDbConnectionString"].ToString();
                conf.UseNpgsql(connStr, opt =>
                {
                    opt.EnableRetryOnFailure();
                });
            });

        //Seed startup datas
        var seedData = new SeedData();
        seedData.SeedAsync(configuration).GetAwaiter().GetResult();

        services.AddScoped<IPersonRepository, PersonRepository>();
        services.AddScoped<IContactRepository, ContactRepository>();

        return services;
    }


}
