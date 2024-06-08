namespace Athena.Application.Categories;

public record UpdateCategoryCommand(Guid CategoryId, string CategoryName) : ICommand;