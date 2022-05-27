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
            var connStr = "Data Source=127.0.0.1; Initial Catalog=sozlukdb; Persist Security Info=True; User ID=sa; Password=?Se1478963";
          
            optionsBuilder.UseNpgsql(connStr);
            base.OnConfiguring(optionsBuilder);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    public override int SaveChanges()
    {
        OnBeforeSave();
        return base.SaveChanges();
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        OnBeforeSave();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        OnBeforeSave();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        OnBeforeSave();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void OnBeforeSave()
    {
        var addedEntities = ChangeTracker.Entries()
            .Where(i => i.State == EntityState.Added)
            .Select(i => (BaseEntity)i.Entity);

        PrepareAddedEntites(addedEntities);
    }

    private void PrepareAddedEntites(IEnumerable<BaseEntity> entites)
    {
        foreach (var entity in entites)
        {
            if (entity.CreateDate == DateTime.MinValue)
                entity.CreateDate = DateTime.Now;
        }
    }
    #endregion
}