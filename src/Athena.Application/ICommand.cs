using MediatR;

namespace Athena.Application;

public interface ICommand : IRequest<Result>;

public interface ICommand<TResultValue> : IRequest<Result<TResultValue>>;