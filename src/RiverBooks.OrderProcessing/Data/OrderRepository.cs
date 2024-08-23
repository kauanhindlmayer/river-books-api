
namespace RiverBooks.OrderProcessing.Data;

public class OrderRepository(OrderProcessingDbContext dbContext) : IOrderRepository
{
    private readonly OrderProcessingDbContext _dbContext = dbContext;

    public Task<Order> AddOrderAsync(Order order)
    {
        throw new NotImplementedException();
    }

    public Task<Order> ListOrdersAsync(Guid orderId)
    {
        throw new NotImplementedException();
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}
