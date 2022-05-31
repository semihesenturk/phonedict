using Microsoft.EntityFrameworkCore;
using Report.Domain.Models;

namespace Report.Infrastructure.Persistence.Context;

public class ReportContext : DbContext
{
    #region Constructors
    public ReportContext()
    {
    }

    public ReportContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
    {
    }
    #endregion

    #region Db Sets
    public DbSet<Domain.Models.Report> Reports { get; set; }
    #endregion

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //For Design Time Operations! For Example Migrations.
        if (!optionsBuilder.IsConfigured)
        {
            var connStr = "User ID=esenturk;Password=123456789Se;Host=localhost;Port=5432;Database=PhoneDictReportDb;";

            optionsBuilder.UseNpgsql(connStr);
            base.OnConfiguring(optionsBuilder);
        }
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var datas = ChangeTracker
             .Entries<Domain.Models.Report>();

        //Interceptor
        foreach (var item in datas)
        {
            _ = item.State switch
            {
                EntityState.Added => item.Entity.RequestedDate = DateTime.UtcNow,
                EntityState.Detached => item.Entity.RequestedDate = DateTime.UtcNow,
                EntityState.Unchanged => item.Entity.RequestedDate = DateTime.UtcNow,
                EntityState.Deleted => item.Entity.RequestedDate = DateTime.UtcNow,
                EntityState.Modified => item.Entity.RequestedDate = DateTime.UtcNow,
                _ => item.Entity.RequestedDate = item.Entity.RequestedDate
            };
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}
