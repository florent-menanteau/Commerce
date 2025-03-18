//namespace Commerce.Api
//{
//    public interface IMapper
//    {

//    }
//    public interface IMapper<T, Tdto> : IMapper
//        where T: class
//        where Tdto: class
//    {
//        public T Map(Tdto dto);
//        public Tdto Map(T t);
//    }
//    public class BundlePricingMapper : IMapper<BundlePricing, BundlePricingDto>
//    {
//        public BundlePricingMapper() { }
//        public BundlePricing Map(BundlePricingDto dto)
//        {
//            return new BundlePricing(dto.ProductId, dto.Order, dto.BundleSize, dto.BundlePrice);
//        }
//        public BundlePricingDto Map(BundlePricing bundlePricing)
//        {
//            return new BundlePricingDto { ProductId = bundlePricing.ProductId, Order = bundlePricing.Order, BundleSize = bundlePricing.BundleSize, BundlePrice = bundlePricing.BundlePrice };
//        }

//    }
//}
