using Commerce;

namespace Application.Test
{
    [TestClass]
    public class PricerTest
    {
        [TestMethod]
        public void Should_Price_Empty_Cart_To_Zero()
        {
            //Arrange
            CartModel cart = new CartModel();
            PricingProvider provider = new PricingProvider();
            CartPricer pricer = new CartPricer(provider);
            //Act
            decimal result = pricer.GetCartPrice(cart);
            //Assert
            Assert.AreEqual(result, 0.0M);
        }

        [TestMethod]
        public void Should_Price_Cart_With_One_Item_Unitary_Price()
        {
            //Arrange
            CartModel cart = new CartModel();
            CartItemModel item1 = new CartItemModel() { ProductId = 1, Quantity = 1 };
            cart.AddCardItem(item1);
            PricingProvider provider = new PricingProvider();
            CartPricer pricer = new CartPricer(provider);
            //Act
            decimal result = pricer.GetCartPrice(cart);
            //Assert
            Assert.AreEqual(result, 5.0M);
        }


        [TestMethod]
        public void Should_Price_Cart_With_One_Item_FirstBundle_Price()
        {
            //Arrange
            CartModel cart = new CartModel();
            CartItemModel item1 = new CartItemModel { ProductId = 1, Quantity = 10 };
            cart.AddCardItem(item1);
            PricingProvider provider = new PricingProvider();
            CartPricer pricer = new CartPricer(provider);
            //Act
            decimal result = pricer.GetCartPrice(cart);
            //Assert
            Assert.AreEqual(result, 35.0M);
        }

        [TestMethod]
        public void Should_Price_Cart_With_One_Item_SecondBundle_Price()
        {
            // Arrange
            CartModel cart = new CartModel();
            CartItemModel item1 = new CartItemModel { ProductId = 1, Quantity = 100 };
            cart.AddCardItem(item1);
            PricingProvider provider = new PricingProvider();
            CartPricer pricer = new CartPricer(provider);
            // Act
            decimal result = pricer.GetCartPrice(cart);
            // Assert
            Assert.AreEqual(result, 275.0M);
        }

        [TestMethod]
        public void Should_Price_Cart_With_One_Item_SecondBundle_Price_And_One_Item_Unitary_Price()
        {
            // Arrange
            CartModel cart = new CartModel();
            CartItemModel item1 = new CartItemModel { ProductId = 1, Quantity = 100 };
            cart.AddCardItem(item1);
            CartItemModel item2 = new CartItemModel {ProductId =  2, Quantity = 10 };
            cart.AddCardItem(item2);
            PricingProvider provider = new PricingProvider();
            provider.AddPricingModel(new UnitaryPricingStrategie(2, 3.0M));
            CartPricer pricer = new CartPricer(provider);
            // Act
            decimal result = pricer.GetCartPrice(cart);
            // Assert
            Assert.AreEqual(result, 305.0M);
        }
        [TestMethod]
        public void Should_Throw()
        {
            // Arrange
            CartModel cart = new CartModel();
            CartItemModel item1 = new CartItemModel { ProductId = 2, Quantity = 100 };
            cart.AddCardItem(item1);
            PricingProvider provider = new PricingProvider();
            CartPricer pricer = new CartPricer(provider);
            // Act / Assert
            Assert.ThrowsException<NullReferenceException>(() => pricer.GetCartPrice(cart));
        }
    }
}