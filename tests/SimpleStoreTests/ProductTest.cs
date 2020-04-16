using Xunit;
using SimpleStore;
namespace SimpleStoreTests
{
    public class ProductTest
    {
        [Fact]
        public void Product_WhenSetNegativePrice_Return_ZeroPrice()
        {
            // Arrange
            double negPrice = -1;
            Product prod = new Product("Prod", negPrice, 123);

            // Act
            double actualPrice = prod.GetPrice();

            // Assert
            double expectedPrice = 0;
            Assert.Equal(expectedPrice, actualPrice);
        }

        [Fact]
        public void Product_WhenSetZeroPrice_Return_ZeroPrice()
        {
            // Arrange
            double zeroPrice = 0;
            Product prod = new Product("Prod", zeroPrice, 123);

            // Act
            double actualPrice = prod.GetPrice();

            // Assert
            double expectedPrice = 0;
            Assert.Equal(expectedPrice, actualPrice);
        }

        [Fact]
        public void Product_WhenSetNegativeCode_Return_ZeroCode()
        {
            // Arrange
            int negCode = -1;
            Product prod = new Product("Prod", 123, negCode);

            // Act
            double actualCode = prod.GetCode();

            // Assert
            double expectedCode = 0;
            Assert.Equal(expectedCode, actualCode);
        }

        [Fact]
        public void Product_WhenSetZeroCode_Return_ZeroCode()
        {
            // Arrange
            int zeroCode = 0;
            Product prod = new Product("Prod", 123, zeroCode);

            // Act
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
        public void Product_WhenSetPriceIsOk_Return_True(double price, double expectedPrice)
        {
            var prod = new Product("Prod", price, 123);
            Assert.Equal(expectedPrice, prod.GetPrice());
        }

        [Theory]
        [InlineData(10, 10)]
        [InlineData(0, 0)]
        [InlineData(-1, 0)]
        public void Product_WhenSetCodeIsOk_Return_True(int code, int expectedCode)
        {
            var prod = new Product("Prod", 12.5, code);
            Assert.Equal(expectedCode, prod.GetCode());
        }
    }
}