namespace Commerce
{
    public abstract class PricingStrategyBase : IPricingStrategie
    {
        protected readonly int productId = 0;
        public int ProductId => productId;
        public abstract decimal Price { get; }
        public abstract int Size { get; }
        protected PricingStrategyBase(int productId)
        {
            this.productId = productId;
        }

        public abstract decimal GetPrice(decimal quantity);

        public IPricingStrategie? ChildStrategy { get; set; }
    }
}
