using Xunit;
using SimpleStore;
namespace SimpleStoreTests
{
    public class StoreTests
    {
        [Fact]
        public void Store_WhenNoProcuctInStore_Then_isEmptyAsTrue()
        {
            // Arrange
            Store myStore = new Store();

            // Assert
            Assert.True(myStore.IsEmpty());
        }

        [Fact]
        public void Store_WhenNoProcuctInStore_Then_ZeroTotalPrice()
        {
            // Arrange
            Store myStore = new Store();

            // Assert
            double expected = 0;
            Assert.Equal(expected, myStore.GetTotalPrice());
        }

        [Fact]
        public void getTotalPrice_ThrowsException_IfStorageUnitIsNull()
        {
            // Arrange
            Store myStore = new Store();
            bool throwException = false;

            // Act & Assert
            try
            {
                var price = myStore.GetTotalPrice(null);
                Assert.True(throwException);
            }
            catch
            {
                throwException = true;
                Assert.True(throwException);
            }  
        }
    }
}
