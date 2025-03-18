namespace Commerce.Infrastructure.DAO;

public class Product : IEntity
{
    public long? Id { get; set; }
    public string Reference { get; set; } = string.Empty;
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; } = decimal.Zero;
}

