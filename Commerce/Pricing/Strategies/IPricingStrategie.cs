namespace Commerce
{
    public interface IPricingStrategie
    {
        public decimal Price { get; }
        public int Size { get; }
        public int ProductId { get; }
        public decimal GetPrice(decimal quantity);
        public IPricingStrategie? ChildStrategy { get; set; }

    }
}
