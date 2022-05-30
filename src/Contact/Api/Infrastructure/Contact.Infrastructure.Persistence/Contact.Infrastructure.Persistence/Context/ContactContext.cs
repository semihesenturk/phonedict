using Contact.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Contact.Infrastructure.Persistence.Context;

public class ContactContext : DbContext
{
    public const string DEFAULT_SCHEMA = "dbo";

    #region Constructors
    public ContactContext()
    {
    }

    public ContactContext(DbContextOptions dbContextOptions)
        : base(dbContextOptions)
    {
    }
    #endregion

    #region DbSets
    public DbSet<Person> Persons { get; set; }

    public DbSet<Domain.Models.Contact> Contacts { get; set; }
    #endregion

    #region Extensions
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //For Design Time Operations! For Example Migrations.
        if (!optionsBuilder.IsConfigured)
        {
            var connStr = "User ID=esenturk;Password=123456789Se;Host=localhost;Port=5432;Database=PhoneDictDb;";

            optionsBuilder.UseNpgsql(connStr);
            base.OnConfiguring(optionsBuilder);
        }
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var datas = ChangeTracker
             .Entries<BaseEntity>();

        //Interceptor
        foreach (var item in datas)
        {
            _ = item.State switch
            {
                EntityState.Added => item.Entity.CreateDate = DateTime.UtcNow,
                EntityState.Detached => item.Entity.CreateDate = item.Entity.CreateDate,
                EntityState.Unchanged => item.Entity.CreateDate= item.Entity.CreateDate,
                EntityState.Deleted => item.Entity.CreateDate= item.Entity.CreateDate,
                EntityState.Modified => item.Entity.CreateDate= item.Entity.CreateDate,
                _ => item.Entity.CreateDate= item.Entity.CreateDate
            };
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
    #endregion
}