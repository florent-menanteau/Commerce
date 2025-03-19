namespace Commerce
{
    public class CartItemModel
    {
        public long? Id { get; set; }

        public long ProductId { get; set; }
        public decimal Quantity { get; set; }

        public decimal? Price { get; set; }

    }
}
