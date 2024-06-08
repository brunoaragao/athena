using Athena.Domain.Categories;

using Microsoft.EntityFrameworkCore;

namespace Athena.Infrastructure.Categories;

public class CategoryRepository(AthenaContext context) : ICategoryRepository
{
    private readonly DbSet<Category> _set = context.Set<Category>();

    public async Task<IReadOnlyCollection<Category>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _set.ToListAsync(cancellationToken);
    }

    public async Task<Category?> GetByIdAsync(CategoryId id, CancellationToken cancellationToken = default)
    {
        return await _set.FindAsync([id], cancellationToken);
    }

    public void Add(Category category)
    {
        _set.Add(category);
    }

    public void Update(CategoryId id, Category category)
    {
        var currentCategory = _set.Find(id);

        if (currentCategory is not null)
        {
            _set.Entry(currentCategory).CurrentValues.SetValues(category);
        }
    }

    public void Remove(Category category)
    {
        _set.Remove(category);
    }
}