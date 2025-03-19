namespace Commerce
{
    public class UnitaryDiscountPricingStrategie : PricingStrategyBase, IPricingStrategie
    {
        private decimal price;
        private decimal discount;
        public override decimal Price => price;
        public override int Size => 1;

        public UnitaryDiscountPricingStrategie(int productId, decimal price, decimal discount):base(productId) {
            this.price = price;
            this.discount = discount;
        }
        public override decimal GetPrice(decimal quantity)
        {
            return quantity * price*(1-(decimal)discount/100);
        }
    }
}
