using System.Diagnostics.CodeAnalysis;

namespace Athena.Application;

public class Result(Error? error)
{
    public static implicit operator Result(Error error) => Failure(error);

    public Error? Error { get; } = error;

    [MemberNotNullWhen(true, nameof(Error))]
    public virtual bool IsFailure => Error is not null;

    [MemberNotNullWhen(false, nameof(Error))]
    public virtual bool IsSuccess => !IsFailure;

    public static Result Success() => new(null);
    public static Result<T> Success<T>(T value) => new(value, null);
    public static Result Failure(Error error) => new(error);
    public static Result Failure(string errorMessage) => new(new Error(errorMessage));
    public static Result<T> Failure<T>(Error error) => new(default, error);
    public static Result<T> Failure<T>(string errorMessage) => new(default, new Error(errorMessage));
}