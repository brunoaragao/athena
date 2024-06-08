namespace Athena.Application.Categories;

public record CategoryNotFoundedError(Guid Id) : Error($"Category with id \"{Id}\" not founded.");