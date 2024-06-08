using Athena.Domain.Categories;

namespace Athena.Domain.Books;

public class Book
{
    public Book(BookTitle title, CategoryId categoryId)
    {
        Ensure.NotNull(title);
        Ensure.NotNull(categoryId);

        Id = BookId.New;
        Title = title;
        CategoryId = categoryId;
    }

    public BookId Id { get; }

    public BookTitle Title { get; private set; }

    public CategoryId CategoryId { get; private set; }

    public void SetTitle(BookTitle title)
    {
        Ensure.NotNull(title);
        Title = title;
    }

    public void SetCategoryId(CategoryId categoryId)
    {
        Ensure.NotNull(categoryId);
        CategoryId = categoryId;
    }
}