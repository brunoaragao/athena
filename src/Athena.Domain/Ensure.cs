using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Athena.Domain;

public static class Ensure
{
    public static void NotNull([NotNull] object? @object, [CallerArgumentExpression(nameof(@object))] string? parameterName = null)
    {
        if (@object is null)
        {
            throw new EnsureViolationException($"The value of \"{parameterName}\" cannot be null.");
        }
    }

    public static void NotEmpty<T>(IEnumerable<T> enumerable, [CallerArgumentExpression(nameof(enumerable))] string? parameterName = null)
    {
        if (!enumerable.Any())
        {
            throw new EnsureViolationException($"The value of \"{parameterName}\" cannot be empty.");
        }
    }

    public static void NotEmpty(Guid guid, [CallerArgumentExpression(nameof(guid))] string? parameterName = null)
    {
        if (guid == Guid.Empty)
        {
            throw new EnsureViolationException($"The value of \"{parameterName}\" cannot be empty.");
        }
    }

    public static void NotWhiteSpaces(string @string, [CallerArgumentExpression(nameof(@string))] string? parameterName = null)
    {
        if (@string.All(char.IsWhiteSpace))
        {
            throw new EnsureViolationException($"The value of \"{parameterName}\" cannot be white spaces.");
        }
    }
}