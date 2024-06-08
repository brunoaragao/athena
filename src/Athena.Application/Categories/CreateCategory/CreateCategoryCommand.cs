namespace Athena.Application.Categories;

public record CreateCategoryCommand(string CategoryName) : ICommand<CreateCategoryCommandResponse>;