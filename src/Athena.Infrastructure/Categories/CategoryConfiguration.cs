using Athena.Domain.Categories;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Athena.Infrastructure.Data.Categories;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Category");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .IsRequired()
            .HasConversion(
                categoryId => categoryId.Value,
                value => new CategoryId(value));

        builder.Property(c => c.Name)
            .IsRequired()
            .HasConversion(
                categoryName => categoryName.Value,
                value => new CategoryName(value));
    }
}