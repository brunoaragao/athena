
using System.Reflection;

using Microsoft.EntityFrameworkCore;

namespace Athena.Infrastructure;

public class AthenaContext : DbContext
{
    public AthenaContext(DbContextOptions options) : base(options)
    {
    }

    protected AthenaContext()
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.Load("Athena.Infrastructure"));
    }
}