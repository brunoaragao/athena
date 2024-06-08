using Athena.Domain.Categories;

namespace Athena.Application.Categories;

public class GetCategoriesQueryHandler(ICategoryRepository repository) : IQueryHandler<GetCategoriesQuery, GetCategoriesQueryResponse>
{
    private readonly ICategoryRepository _repository = repository;

    public async Task<Result<GetCategoriesQueryResponse>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        IReadOnlyCollection<Category> categories = await _repository.GetAllAsync(cancellationToken);
        return MapCategoriesToResponse(categories);
    }

    private static Result<GetCategoriesQueryResponse> MapCategoriesToResponse(IReadOnlyCollection<Category> categories)
    {
        IReadOnlyCollection<GetCategoriesQueryResponseItem> responseItems = [.. categories.Select(c => new GetCategoriesQueryResponseItem(c.Id, c.Name))];
        return new GetCategoriesQueryResponse(responseItems);
    }
}