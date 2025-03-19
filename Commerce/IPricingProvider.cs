namespace Commerce
{
    public interface IPricingProvider
    {
        public void AddPricingModel(IPricingStrategie pricingStrategie);
        public IPricingStrategie GetPricingChain(long productId);
        public List<IPricingStrategie> GetPricingConfiguration();
    }
}
