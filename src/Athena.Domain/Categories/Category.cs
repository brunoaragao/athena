using System.Diagnostics.CodeAnalysis;

namespace Athena.Domain.Categories;

public class Category : IEntity<CategoryId>
{
    private CategoryName _name;

    public Category(CategoryName name)
    {
        Id = CategoryId.New;
        Name = name;
    }

    public CategoryId Id { get; private init; }

    public CategoryName Name
    {
        get => _name;

        [MemberNotNull(nameof(_name))]
        set
        {
            Ensure.NotNull(value);
            _name = value;
        }
    }
}