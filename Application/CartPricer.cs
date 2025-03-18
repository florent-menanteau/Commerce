using Commerce;
using Commerce.Infrastructure.DAO;

namespace Application
{
    public class CartPricer: ICartPricer
    {
        private readonly IPricingProvider pricingProvider;

        public CartPricer(IPricingProvider pricingProvider)
        {
            this.pricingProvider = pricingProvider;
        }
        public decimal GetCartPrice(CartModel cart)
        {
            return cart.Items.Sum(i => GetPrice(i));
        }


        public decimal GetPrice(CartItemModel item)
        {
            var pricingChain = pricingProvider.GetPricingChain(item.ProductId);
            decimal price = pricingChain.GetPrice(item.Quantity);
            item.Price = price;
            return price;
        }
    }
}
