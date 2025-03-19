//namespace Commerce
//{
//    public interface IEntity
//    {

//    }

//    public abstract class PricingBase : IEntity
//    {
//        public readonly int ProductId;
//        public readonly int Order;

//        public IPricingStrategie PricingStrategie { get; protected set; } = null;

//        public PricingBase(int productId, int order)
//        {
//            ProductId = productId;
//            Order = order;
//        }

//    }
//    public class BundlePricing : PricingBase
//    {
//        public readonly int BundleSize = 0;
//        public readonly decimal BundlePrice = 0;
//        public BundlePricing(int productId, int order, int bundleSize, decimal bundlePrice):base(productId, order)
//        {
//            BundleSize = bundleSize;
//            BundlePrice = bundlePrice;
//            PricingStrategie = new BundlePricingStrategie(bundleSize, bundlePrice);
//        }
//    }

//    public class UnitaryPricing : PricingBase
//    {
//        public decimal Price = 0;

//        public UnitaryPricing(int productId, int order, decimal price) : base(productId, order)
//        {
//            PricingStrategie = new UnitaryPricingStrategie(price);
//        }
//    }
//}
