namespace Commerce.Infrastructure.DAO
{
    public class CartItem : IEntity
    {
        public long? Id { get; set; }
        public long ProductId { get; set; }
        public long CartId { get; set; }
        public Cart Cart { get; set; }

        public decimal Quantity { get; set; }
        public decimal Price { get;set; }
    }
}
