namespace RiverBooks.Users.CartEndpoints.ListCartItems;

public record CartResponse(List<CartItemDto> Items)
{
    public static CartResponse FromDomain(List<CartItem> items)
    {
        return new CartResponse(items.Select(CartItemDto.FromDomain).ToList());
    }
};

public record CartItemDto(
    Guid Id,
    Guid BookId,
    string Description,
    int Quantity,
    decimal Price)
{
    public static CartItemDto FromDomain(CartItem item)
    {
        return new CartItemDto(
            item.Id,
            item.BookId,
            item.Description,
            item.Quantity,
            item.Price);
    }
};