
using Athena.Domain;
using Athena.Domain.Categories;

namespace Athena.Application.Categories;

public class DeleteCategoryCommandHandler(ICategoryRepository repository, IUnitOfWork unitOfWork) : ICommandHandler<DeleteCategoryCommand>
{
    private readonly ICategoryRepository _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Result> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        Category? category = await _repository.GetByIdAsync(request.CategoryId, cancellationToken);

        if (category is null)
            return new CategoryNotFoundedError(request.CategoryId);

        _repository.Remove(category);

        await _unitOfWork.CommitAsync(cancellationToken);

        return Result.Success();
    }
}