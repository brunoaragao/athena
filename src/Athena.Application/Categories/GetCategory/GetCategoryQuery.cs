namespace Athena.Application.Categories;

public record GetCategoryQuery(Guid Id) : IQuery<GetCategoryQueryResponse>;