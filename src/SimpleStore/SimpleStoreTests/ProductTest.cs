using Xunit;
using SimpleStore;

namespace SimpleStoreTests
{
    public class ProductTest
    {
        [Fact]
        public void When_SetNegativePrice_Expect_ZeroPrice()
        {
            // Asset
            double negPrice = -1;

            // Act
            Product prod = new Product("Prod", negPrice, 123);
            double actualPrice = prod.GetPrice();

            // Assert
            double expectedPrice = 0;
            Assert.Equal(expectedPrice, actualPrice);
        }

        [Fact]
        public void When_SetZeroPrice_Expect_ZeroPrice()
        {
            // Asset
            double zeroPrice = 0;

            // Act
            Product prod = new Product("Prod", zeroPrice, 123);
            double actualPrice = prod.GetPrice();

            // Assert
            double expectedPrice = 0;
            Assert.Equal(expectedPrice, actualPrice);
        }

        [Fact]
        public void When_SetNegativeCode_Expect_ZeroCode()
        {
            // Asset
            int negCode = -1;

            // Act
            Product prod = new Product("Prod", 123, negCode);
            double actualCode = prod.GetCode();

            // Assert
            double expectedCode = 0;
            Assert.Equal(expectedCode, actualCode);
        }

        [Fact]
        public void When_SetZeroCode_Expect_ZeroCode()
        {
            // Asset
            int zeroCode = 0;

            // Act
            Product prod = new Product("Prod", 123, zeroCode);
            double actualCode = prod.GetCode();

            // Assert
            double expectedCode = 0;
            Assert.Equal(expectedCode, actualCode);
        }

        [Theory]
        [InlineData(10,10)]
        [InlineData(1.5, 1.5)]
        [InlineData(0, 0)]
        [InlineData(-10, 0)]
        [InlineData(-1.5, 0)]
        public void Product_CheckPrice(double price, double expectedPrice)
        {
            var prod = new Product("Prod", price, 123);
            Assert.Equal(expectedPrice, prod.GetPrice());
        }


        [Theory]
        [InlineData(10, 10)]
        [InlineData(0, 0)]
        [InlineData(-1, 0)]
        public void Product_CheckCode(int code, int expectedCode)
        {
            var prod = new Product("Prod", 12.5, code);
            Assert.Equal(expectedCode, prod.GetCode());
        }

    }
}
