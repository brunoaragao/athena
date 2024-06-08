using Athena.Application.Categories;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace Athena.Web.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoriesController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetCategoriesQueryResponse))]
    public async Task<IActionResult> GetCategories(CancellationToken cancellationToken = default)
    {
        var query = new GetCategoriesQuery();

        var result = await _sender.Send(query, cancellationToken);

        return result switch
        {
            { IsSuccess: true }
            => Ok(result.Value),

            { Error: _ }
            => Problem()
        };
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetCategoryQueryResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCategory(Guid id, CancellationToken cancellationToken = default)
    {
        var query = new GetCategoryQuery(id);

        var result = await _sender.Send(query, cancellationToken);

        return result switch
        {
            { IsSuccess: true }
            => Ok(result.Value),

            { Error: CategoryNotFoundedError }
            => NotFound(),

            { Error: _ }
            => Problem()
        };
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CreateCategoryCommandResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    public async Task<IActionResult> CreateCategory(CreateCategoryCommand command, CancellationToken cancellationToken = default)
    {
        var result = await _sender.Send(command, cancellationToken);

        return result switch
        {
            { IsSuccess: true }
            => CreatedAtAction(nameof(GetCategory), new { id = result.Value.CategoryId }, result.Value),

            { Error: _ }
            => Problem()
        };
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command, CancellationToken cancellationToken = default)
    {
        var result = await _sender.Send(command, cancellationToken);

        return result switch
        {
            { IsSuccess: true }
            => NoContent(),

            { Error: CategoryNotFoundedError }
            => NotFound(),

            { Error: _ }
            => Problem()
        };
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteCategory(Guid id, CancellationToken cancellationToken = default)
    {
        var command = new DeleteCategoryCommand(id);

        var result = await _sender.Send(command, cancellationToken);

        return result switch
        {
            { IsSuccess: true }
            => NoContent(),

            { Error: CategoryNotFoundedError }
            => NotFound(),

            { Error: _ }
            => Problem()
        };
    }
}