namespace Commerce
{
    public class UnitaryPricingStrategie : PricingStrategyBase, IPricingStrategie
    {
        private decimal price;
        public override int Size => 1;
        public override decimal Price => price;
        public UnitaryPricingStrategie(int productId, decimal price):base(productId) {
            this.price = price;
        }
        public override decimal GetPrice(decimal quantity)
        {
            return quantity * price;
        }
    }
}
