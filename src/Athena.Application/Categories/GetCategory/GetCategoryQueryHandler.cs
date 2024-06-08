using Athena.Domain.Categories;

namespace Athena.Application.Categories;

public class GetCategoryQueryHandler(ICategoryRepository repository) : IQueryHandler<GetCategoryQuery, GetCategoryQueryResponse>
{
    private readonly ICategoryRepository _repository = repository;

    public async Task<Result<GetCategoryQueryResponse>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        Category? category = await _repository.GetByIdAsync(request.Id, cancellationToken);

        if (category is null)
        {
            return new CategoryNotFoundedError(request.Id);
        }

        return new GetCategoryQueryResponse(category.Id, category.Name);
    }
}