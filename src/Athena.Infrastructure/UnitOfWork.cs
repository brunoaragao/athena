using Athena.Domain;

namespace Athena.Infrastructure;

public class UnitOfWork(AthenaContext context) : IUnitOfWork
{
    private readonly AthenaContext _context = context;

    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task RollbackAsync(CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;
    }
}