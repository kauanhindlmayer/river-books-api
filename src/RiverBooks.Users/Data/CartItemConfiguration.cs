using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RiverBooks.Users.Data;

public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> builder)
    {
        builder.Property(ci => ci.Id)
            .ValueGeneratedNever();

        builder.Property(ci => ci.BookId)
            .IsRequired();

        builder.Property(ci => ci.Description)
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(ci => ci.Quantity)
            .IsRequired();

        builder.Property(ci => ci.Price)
            .IsRequired();
    }
}