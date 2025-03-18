namespace Commerce.Infrastructure.DAO;

public class Order
{
    public long? Id { get; set; }
    public long? CartId { get; set; }
    public OrderStatus Status { get; set; }
}

public enum OrderStatus
{
    Unknown = 0,
    Ordereded = 1,
    Validated = 2,
}
