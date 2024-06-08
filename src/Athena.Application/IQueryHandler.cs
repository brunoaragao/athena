using MediatR;

namespace Athena.Application;

public interface IQueryHandler<TQuery, TResultValue> : IRequestHandler<TQuery, Result<TResultValue>> where TQuery : IRequest<Result<TResultValue>>;