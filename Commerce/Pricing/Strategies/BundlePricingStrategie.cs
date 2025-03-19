
namespace Commerce
{
    public class BundlePricingStrategie :PricingStrategyBase, IPricingStrategie
    {
        int _bundleSize = 0;
        decimal _bundlePrice = 0;
        public override  int Size => _bundleSize;
        public override decimal Price => _bundlePrice;
        public BundlePricingStrategie(int productId, int bundleSize, decimal bundlePrice):base(productId) {
            _bundleSize = bundleSize;
            _bundlePrice = bundlePrice;
        }
        public override decimal GetPrice(decimal quantity)
        {
            int quotient = (int)(quantity / _bundleSize);
            int rest = (int)(quantity % _bundleSize);

            return quotient*_bundlePrice + (ChildStrategy != null?ChildStrategy.GetPrice(rest):0);
        }
    }
}
