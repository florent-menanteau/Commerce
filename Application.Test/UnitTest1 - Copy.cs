//using Commerce;

//namespace Application.Test
//{
//    [TestClass]
//    public class UnitTest2
//    {
//        //[TestMethod]
//        //public void Should_Price_Empty_Cart_To_Zero()
//        //{
//        //    // Arrange
//        //    Cart cart = new Cart();
//        //    PricingProvider provider = new PricingProvider();
//        //    CartPricer pricer = new CartPricer(provider);
//        //    // Act
//        //    decimal result = pricer.GetCartPrice(cart);
//        //    // Assert
//        //    Assert.AreEqual(result, 0.0M);
//        //}

//        //[TestMethod]
//        //public void Should_Price_Cart_With_One_Item_Unitary_Price()
//        //{
//        //    // Arrange
//        //    Cart cart = new Cart();
//        //    CartItem item1 = new CartItem(1, 1);
//        //    cart.AddCardItem(item1);
//        //    PricingProvider provider = new PricingProvider();
//        //    CartPricer pricer = new CartPricer(provider);
//        //    // Act
//        //    decimal result = pricer.GetCartPrice(cart);
//        //    // Assert
//        //    Assert.AreEqual(result, 5.0M);
//        //}


//        //[TestMethod]
//        //public void Should_Price_Cart_With_One_Item_FirstBundle_Price()
//        //{
//        //    // Arrange
//        //    Cart cart = new Cart();
//        //    CartItem item1 = new CartItem(1, 10);
//        //    cart.AddCardItem(item1);
//        //    PricingProvider provider = new PricingProvider();
//        //    CartPricer pricer = new CartPricer(provider);
//        //    // Act
//        //    decimal result = pricer.GetCartPrice(cart);
//        //    // Assert
//        //    Assert.AreEqual(result, 35.0M);
//        //}

//        [TestMethod]
//        public void Should_Price_Cart_With_One_Item_SecondBundle_Price()
//        {
//            // Arrange
//            Cart cart = new Cart();
//            CartItem item1 = new CartItem(1, 100);
//            cart.AddCardItem(item1);
//            PricingProvider provider = new PricingProvider();
//            CartPricer pricer = new CartPricer(provider);
//            // Act
//            decimal result = pricer.GetCartPrice(cart);
//            // Assert
//            Assert.AreEqual(result, 275.0M);
//        }

//        [TestMethod]
//        public void Should_Price_Cart_With_One_Item_SecondBundle_Price_And_One_Item_Unitary_Price()
//        {
//            // Arrange
//            Cart cart = new Cart();
//            CartItem item1 = new CartItem(1, 100);
//            cart.AddCardItem(item1);
//            CartItem item2 = new CartItem(2, 10);
//            cart.AddCardItem(item2);
//            PricingProvider provider = new PricingProvider();
//            provider.AddPricingModel(new UnitaryPricingStrategie(2, 3.0M));
//            CartPricer pricer = new CartPricer(provider);
//            // Act
//            decimal result = pricer.GetCartPrice(cart);
//            // Assert
//            Assert.AreEqual(result, 305.0M);
//        }
//        [TestMethod]
//        public void Should_Price_Cart_With_One_Item_Unitary_Discount_Price()
//        {
//            // Arrange
//            Cart cart = new Cart();
//            CartItem item1 = new CartItem(1, 100);
//            cart.AddCardItem(item1);
//            PricingProvider provider = new PricingProvider();
//            provider.AddPricingModel(new UnitaryDiscountPricingStrategie(1, 5.0M, 20));
//            CartPricer pricer = new CartPricer(provider);
//            // Act
//            decimal result = pricer.GetCartPrice(cart);
//            // Assert
//            Assert.AreEqual(result, 305.0M);
//        }

//        [TestMethod]
//        public void Should_Throw()
//        {
//            // Arrange
//            Cart cart = new Cart();
//            CartItem item1 = new CartItem(2, 100);
//            cart.AddCardItem(item1);
//            PricingProvider provider = new PricingProvider();
//            CartPricer pricer = new CartPricer(provider);
//            // Act / Assert
//            Assert.ThrowsException<NullReferenceException>(() => pricer.GetCartPrice(cart));
//        }
//    }
//}