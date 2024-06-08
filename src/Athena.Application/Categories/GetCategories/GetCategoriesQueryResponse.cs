namespace Athena.Application.Categories;

public record GetCategoriesQueryResponse(IReadOnlyCollection<GetCategoriesQueryResponseItem> Items);