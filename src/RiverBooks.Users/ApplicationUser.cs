using Ardalis.GuardClauses;
using Microsoft.AspNetCore.Identity;

namespace RiverBooks.Users;

public class ApplicationUser : IdentityUser
{
    public string FullName { get; set; } = string.Empty;
    private readonly List<CartItem> _cartItems = [];
    public IReadOnlyCollection<CartItem> CartItems => _cartItems.AsReadOnly();

    public void AddCartItem(CartItem cartItem)
    {
        Guard.Against.Null(cartItem);
        var existingCartItem = _cartItems.FirstOrDefault(ci => ci.BookId == cartItem.BookId);
        if (existingCartItem is not null)
        {
            existingCartItem.IncreaseQuantity(cartItem.Quantity);
            return;
        }
        _cartItems.Add(cartItem);
    }
}

public class CartItem
{
    public Guid Id { get; private set; }
    public Guid BookId { get; private set; }
    public string Description { get; private set; } = string.Empty;
    public int Quantity { get; private set; }
    public decimal Price { get; private set; }

    public CartItem(Guid bookId, string description, int quantity, decimal price)
    {
        Id = Guid.NewGuid();
        BookId = Guard.Against.NullOrEmpty(bookId);
        Description = Guard.Against.NullOrEmpty(description);
        Quantity = Guard.Against.NegativeOrZero(quantity);
        Price = Guard.Against.NegativeOrZero(price);
    }

    // This constructor is used by EF Core
    private CartItem() { }

    public void IncreaseQuantity(int quantity)
    {
        Guard.Against.NegativeOrZero(quantity);
        Quantity += quantity;
    }
}