namespace Athena.Application.Categories;

public record DeleteCategoryCommand(Guid CategoryId) : ICommand;