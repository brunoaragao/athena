using System.Diagnostics.CodeAnalysis;

namespace Athena.Application;

public class Result<T>(T? value, Error? error) : Result(error)
{
    public static implicit operator Result<T>(T value) => Success(value);
    public static implicit operator Result<T>(Error error) => Failure<T>(error);

    [MemberNotNullWhen(false, nameof(Value))]
    public override bool IsFailure => base.IsFailure;

    [MemberNotNullWhen(true, nameof(Value))]
    public override bool IsSuccess => base.IsSuccess;

    public T? Value { get; } = value;
}