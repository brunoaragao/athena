namespace Athena.Domain.Books;

public record BookId
{
    public static readonly BookId New = new(Guid.NewGuid());

    public BookId(Guid value)
    {
        Ensure.NotEmpty(value);

        Value = value;
    }

    public Guid Value { get; }

    public static implicit operator BookId(Guid value) => new(value);

    public static implicit operator Guid(BookId id) => id.Value;
}