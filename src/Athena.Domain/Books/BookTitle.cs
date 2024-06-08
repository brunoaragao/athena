namespace Athena.Domain.Books;

public record BookTitle
{
    public BookTitle(string value)
    {
        Ensure.NotNull(value);
        Ensure.NotEmpty(value);
        Ensure.NotWhiteSpaces(value);

        Value = value;
    }

    public string Value { get; }

    public static implicit operator BookTitle(string value) => new(value);

    public static implicit operator string(BookTitle title) => title.Value;
}