
using Athena.Domain;
using Athena.Domain.Categories;

namespace Athena.Application.Categories;

public class UpdateCategoryCommandHandler(ICategoryRepository repository, IUnitOfWork unitOfWork) : ICommandHandler<UpdateCategoryCommand>
{
    private readonly ICategoryRepository _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        Category? category = await _repository.GetByIdAsync(request.CategoryId, cancellationToken);

        if (category is null)
        {
            return new CategoryNotFoundedError(request.CategoryId);
        }

        category.Name = request.CategoryName;

        _repository.Update(category.Id, category);

        await _unitOfWork.CommitAsync(cancellationToken);

        return Result.Success();
    }
}