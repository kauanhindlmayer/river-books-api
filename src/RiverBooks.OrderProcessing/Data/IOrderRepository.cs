namespace RiverBooks.OrderProcessing;

public interface IOrderRepository
{
    Task<Order> ListOrdersAsync(Guid orderId);
    Task<Order> AddOrderAsync(Order order);
    Task SaveChangesAsync();
}