using MediatR;

namespace Athena.Application;

public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result> where TCommand : IRequest<Result>;

public interface ICommandHandler<TCommand, TResultValue> : IRequestHandler<TCommand, Result<TResultValue>> where TCommand : IRequest<Result<TResultValue>>;