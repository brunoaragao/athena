using MediatR;

namespace Athena.Application;

public interface IQuery<TResultValue> : IRequest<Result<TResultValue>>;