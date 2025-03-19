namespace Commerce
{
    public class CartModel
    {
        public long? Id { get; set; }
        public long CustomerId { get; set; }
        public decimal? Price { get; set; }

        public ICollection<CartItemModel> Items { get; set; } = new List<CartItemModel>();

        public void AddCardItem(CartItemModel item)
        {
            Items.Add(item);
        }
    }
}
