using Commerce;

namespace Application
{
    public class PricingProvider : IPricingProvider
    {
        readonly List<IPricingStrategie> _pricingStrategies;
        public PricingProvider()
        {
            _pricingStrategies = new List<IPricingStrategie>()
            {
                new BundlePricingStrategie(1, 30, 80.0M), new BundlePricingStrategie(1, 3,10.0M), new UnitaryPricingStrategie(1, 5.0M)
            };
        }

        public void AddPricingModel(IPricingStrategie pricingStrategie)
        {
            if (_pricingStrategies.Select(p => new {Strategy = p, Type = p.GetType()}).Any(ps => ps.Type == pricingStrategie.GetType() && ps.Strategy.ProductId == pricingStrategie.ProductId && ps.Strategy.Price == pricingStrategie.Price && ps.Strategy.Size == pricingStrategie.Size)) return;
            _pricingStrategies.Add(pricingStrategie);
        }
        public IPricingStrategie GetPricingChain(long productId)
        {
            var strategies = _pricingStrategies.Where(ps => ps.ProductId == productId);

            if (!strategies.Any()) throw new NullReferenceException($"No pricing model found for productId {productId}");

            IPricingStrategie pricingChain = buildPricingChain(strategies);
            return pricingChain;
        }
        public List<IPricingStrategie> GetPricingConfiguration()
        {
            return _pricingStrategies;
        }

        private IPricingStrategie buildPricingChain(IEnumerable<IPricingStrategie> strategies)
        {
            IPricingStrategie root = null;
            IEnumerable<IPricingStrategie?> b = strategies.Where(s => s.GetType() == typeof(BundlePricingStrategie)).OrderByDescending(ps => ps.Size).ThenBy(ps => ps.Price);
            IPricingStrategie current = null;

            if (b != null && b.Any())
            {
                root = b.ElementAt(0);
                current = root;
                for (int i = 1;i<b.Count();i++)
                {
                    current.ChildStrategy = b.ElementAt(i);
                    current = current.ChildStrategy;
                }
            }
            IPricingStrategie? d = strategies.Where(s => s.GetType() == typeof(UnitaryDiscountPricingStrategie)).OrderBy(ps => ps.Price).FirstOrDefault();
            if(d != null)
            {
                if (current != null)
                {
                    current.ChildStrategy = d;
                }
                else
                {
                    root = d;
                }
                current = d;
            }
            IPricingStrategie? u = strategies.Where(s => s.GetType() == typeof(UnitaryPricingStrategie)).OrderBy(ps => ps.Price).FirstOrDefault();
            if (u != null)
            {
                if (current != null)
                {
                    current.ChildStrategy = u;
                }
                else
                {
                    root = u;
                }
                current = u;
            }
            return root;
        }
    }
}
