using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RiverBooks.Books.Data;

internal class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.Property(b => b.Title)
            .IsRequired()
            .HasMaxLength(DatabaseConstants.NameMaxLength);

        builder.Property(b => b.Author)
            .IsRequired()
            .HasMaxLength(DatabaseConstants.NameMaxLength);

        builder.HasData(GetSampleBookData());
    }

    private static IEnumerable<Book> GetSampleBookData()
    {
        return
        [
            new Book(Guid.NewGuid(), "Domain-Driven Design", "Eric Evans", 55.90m),
            new Book(Guid.NewGuid(), "Clean Code", "Robert C. Martin", 45.50m),
            new Book(Guid.NewGuid(), "Refactoring", "Martin Fowler", 40.00m),
            new Book(Guid.NewGuid(), "Design Patterns", "Erich Gamma", 48.90m),
            new Book(Guid.NewGuid(), "Working Effectively with Legacy Code", "Michael Feathers", 32.00m),
            new Book(Guid.NewGuid(), "The Pragmatic Programmer", "Andrew Hunt", 42.00m),
            new Book(Guid.NewGuid(), "Code Complete", "Steve McConnell", 38.00m),
            new Book(Guid.NewGuid(), "Patterns of Enterprise Application Architecture", "Martin Fowler", 50.00m),
            new Book(Guid.NewGuid(), "Test Driven Development: By Example", "Kent Beck", 45.00m),
            new Book(Guid.NewGuid(), "Clean Architecture", "Robert C. Martin", 55.00m)
        ];
    }
}
