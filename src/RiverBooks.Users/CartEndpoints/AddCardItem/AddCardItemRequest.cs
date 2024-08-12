namespace RiverBooks.Users.CartEndpoints.AddCardItem;

public record AddCardItemRequest(Guid BookId, int Quantity);