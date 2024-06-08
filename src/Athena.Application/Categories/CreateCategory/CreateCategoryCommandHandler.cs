
using Athena.Domain;
using Athena.Domain.Categories;

namespace Athena.Application.Categories;

public class CreateCategoryCommandHandler(ICategoryRepository repository, IUnitOfWork unitOfWork) : ICommandHandler<CreateCategoryCommand, CreateCategoryCommandResponse>
{
    private readonly ICategoryRepository _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result<CreateCategoryCommandResponse>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        Category category = new(request.CategoryName);

        _repository.Add(category);

        await _unitOfWork.CommitAsync(cancellationToken);

        return new CreateCategoryCommandResponse(category.Id);
    }
}