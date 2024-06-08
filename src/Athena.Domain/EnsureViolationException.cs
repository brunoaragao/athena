namespace Athena.Domain;

public class EnsureViolationException(string? message) : Exception(message);