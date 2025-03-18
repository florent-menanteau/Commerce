using Commerce;

namespace Application
{
    public interface ICartPricer
    {
        public decimal GetCartPrice(CartModel cart);
    }
}
