namespace Athena.Domain.Categories;

public record CategoryName
{
    public CategoryName(string value)
    {
        Ensure.NotNull(value);
        Ensure.NotEmpty(value);
        Ensure.NotWhiteSpaces(value);

        Value = value;
    }

    public string Value { get; }

    public static implicit operator CategoryName(string value) => new(value);

    public static implicit operator string(CategoryName name) => name.Value;
}