//using Application;
//using Commerce;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;

//HostApplicationBuilder builder = Host.CreateApplicationBuilder();

//builder.Services.RegisterDependencies();
//using IHost host = builder.Build();
//Main(host.Services);

////await host.RunAsync();

//static async void Main(IServiceProvider servicesProvider)
//{
//    //IPricingProvider provider = servicesProvider.GetRequiredService<IPricingProvider>();
//    //provider.AddPricingModel(2, new UnitaryPricing(2, 0, 3.0M));

//    //ICartPricerFactory cartPricerFactory = servicesProvider.GetRequiredService<ICartPricerFactory>();
//    //ICartPricer pricer = cartPricerFactory.Create();
//    //Cart cart = new Cart();
//    //CartItem item1 = new CartItem(1, 100);
//    //cart.AddCardItem(item1);
//    //CartItem item2 = new CartItem(2, 10);
//    //cart.AddCardItem(item2);

//    //// See https://aka.ms/new-console-template for more information
//    //Console.WriteLine($"Price : {pricer.GetCartPrice(cart)}");
//}
