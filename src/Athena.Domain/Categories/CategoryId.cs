namespace Athena.Domain.Categories;

public record CategoryId
{
    public static readonly CategoryId New = new(Guid.NewGuid());

    public CategoryId(Guid value)
    {
        Ensure.NotEmpty(value);

        Value = value;
    }

    public Guid Value { get; }

    public static implicit operator CategoryId(Guid value) => new(value);

    public static implicit operator Guid(CategoryId id) => id.Value;
}