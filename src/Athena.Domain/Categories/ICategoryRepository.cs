namespace Athena.Domain.Categories;

public interface ICategoryRepository : IRepository
{
    Task<IReadOnlyCollection<Category>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Category?> GetByIdAsync(CategoryId id, CancellationToken cancellationToken = default);
    void Add(Category category);
    void Remove(Category category);
    void Update(CategoryId id, Category category);
}