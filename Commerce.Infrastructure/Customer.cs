namespace Commerce.Infrastructure.DAO;

public class Customer: IEntity
{
    public long? Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
