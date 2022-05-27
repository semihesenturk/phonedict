using Contact.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Contact.Infrastructure.Persistence;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ContactContext>
{
    public ContactContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<ContactContext> dbContextOptionsBuilder = new();
        dbContextOptionsBuilder.UseNpgsql("");

        return new(dbContextOptionsBuilder.Options);
    }
}
