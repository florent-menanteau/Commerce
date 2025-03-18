namespace Commerce.Infrastructure.DAO
{
    public class Cart : IEntity
    {
        public long? Id { get; set; }
        public long CustomerId { get; set; }
        public decimal Price { get; set; }
        public ICollection<CartItem> Items { get; set; } = new List<CartItem>();

    }
}
