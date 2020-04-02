using Xunit;
using SimpleStore.StoreClasses;

namespace SimpleStoreTests
{
    public class StoreTests
    {
        [Fact]
        public void When_NoProcuctInStore_Then_isEmptyAsTrue()
        {
            // Asset
            Store myStore = new Store();

            // Act

            // Assert
            Assert.True(myStore.IsEmpty());
        }

        [Fact]
        public void When_NoProcuctInStore_Then_ZeroTotalPrice()
        {
            // Asset

            // Act
            Store myStore = new Store();

            // Assert
            double expected = 0;
            Assert.Equal(expected, myStore.GetTotalPrice());
        }

        [Fact]
        public void getTotalPrice_ThrowsException_IfStorageUnitIsNull()
        {
            // Asset
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
