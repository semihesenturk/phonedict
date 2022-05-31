using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Report.Application.Repositories;
using Report.Infrastructure.Persistence.Context;
using Report.Infrastructure.Persistence.Repositories;

namespace Report.Infrastructure.Persistence.Extensions;

public static class Registration
{
    public static IServiceCollection AddInfrastructureRegistration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ReportContext>(options
           => options.UseNpgsql("User ID=esenturk;Password=123456789Se;Host=localhost;Port=5432;Database=PhoneDictReportDb;"));

        services.AddScoped<IReportRepository, ReportRepository>();
        return services;
    }
}
