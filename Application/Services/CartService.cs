using AutoMapper;
using Commerce;
using Commerce.Infrastructure.DAO;
using Commerce.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class CartService: ICartService
    {
        private readonly IMapper mapper;
        private readonly ILogger<CartService> logger;
        private readonly ICartPricer cartPricer;
        private readonly ICartRepository repository;
        private readonly IRepository<CartItem> cartItemRepository;

        public CartService(IMapper mapper, ILogger<CartService> logger, ICartPricer cartPricer, ICartRepository repository, IRepository<CartItem> cartItemRepository) 
        {
            this.mapper = mapper;
            this.logger = logger;
            this.cartPricer = cartPricer;
            this.repository = repository;
            this.cartItemRepository = cartItemRepository;
        }

        public decimal PriceCart(Commerce.CartModel cart)
        {
            return cartPricer.GetCartPrice(cart);
        }

        public async Task<Commerce.CartModel> CreateCartAsync(Commerce.CartModel cart, CancellationToken cancellationToken)
        {
            cart.Price = cartPricer.GetCartPrice(cart);

            var res = await repository.CreateAsync(mapper.Map<Cart>(cart), cancellationToken);

            //var items = await cartItemRepository.CreateListAsync(mapper.Map<List<CartItem>>(cart.Items), new CancellationToken());
            return mapper.Map<Commerce.CartModel>(res);
        }

        public async Task<IEnumerable<Commerce.CartModel>> GetCustomerCartsAsync(long customerId, CancellationToken cancellationToken)
        {
            var res = await repository.GetCustomerCartsAsync(customerId, cancellationToken);
            return mapper.Map<IEnumerable<CartModel>>(res);
        }
    }
}
