using System;
using Xunit;
using SimpleZoo.Animals;

namespace SimpleZooTest
{
    public class MamalAnimalTests
    {
        public MamalAnimalTests()
        {
        }

        [Theory]
        [InlineData(5, false)]
        [InlineData(0, true)]
        [InlineData(-1, true)]
        public void MamalAnimal_WhenInitWithNonpositiveAge_Return_Exception(int animalAge, bool isExceptionExpected)
        {
            // Asset
            bool isExceptionActual = false;

            // Act
            try
            {
                MamalAnimal animal = new MamalAnimal(name: "Animal", age: animalAge, health: 100, id: Guid.NewGuid());
            }
            catch { isExceptionActual = true; }

            // Assert
            Assert.Equal(isExceptionExpected, isExceptionActual);
        }

		[Fact]
		public void MamalAnimal_WhenInitWithAgeGreaterThenMaxAge_Return_Exception()
		{
            // Asset
            
            // --- Defaul MAX_AGE = 25;
            int age = 30;
            bool isException = false;

            // Act
            try
            {
                MamalAnimal animal = new MamalAnimal(name: "Animal", age: age, health: 100, id: Guid.NewGuid());
            }
            catch { isException = true; }

            // Assert
            Assert.True(isException);
        }

		[Fact]
		public void MamalAnimal_WhenInitWithNullName_Return_Exeption()
		{
            // Asset

            // --- Defaul MAX_AGE = 25;
            string name = null;
            bool isException = false;

            // Act
            try
            {
                MamalAnimal animal = new MamalAnimal(name: name, age: 10, health: 100, id: Guid.NewGuid());
            }
            catch { isException = true; }

            // Assert
            Assert.True(isException);
        }

        [Theory]
        [InlineData(150, true)]
        [InlineData(100, false)]
        [InlineData(5, false)]
        [InlineData(0, false)]
        [InlineData(-1, true)]
        [InlineData(-15, true)]
        public void MamalAnimal_WhenInitWithOutOfRangeHealth_Return_Exeption(int health, bool isExceptionExpected)
        {
            // Asset
            bool isExceptionActual = false;

            // Act
            try
            {
                MamalAnimal animal = new MamalAnimal(name: "Animal", age: 10, health: health, id: Guid.NewGuid());
            }
            catch { isExceptionActual = true; }

            // Assert
            Assert.Equal(isExceptionExpected, isExceptionActual);
        }

        [Theory]
        [InlineData(150, true)]
        [InlineData(100, false)]
        [InlineData(5, false)]
        [InlineData(0, false)]
        [InlineData(-1, true)]
        [InlineData(-15, true)]
        public void MamalAnimal_WhenInitWithOutOfRangeHunger_Return_Exeption(int hunger, bool isExceptionExpected)
        {
            // Asset
            bool isExceptionActual = false;

            // Act
            try
            {
                MamalAnimal animal = new MamalAnimal(name: "Animal", age: 10, health: 100, id: Guid.NewGuid())
                {
                    Hunger = hunger
                };
            }
            catch { isExceptionActual = true; }

            // Assert
            Assert.Equal(isExceptionExpected, isExceptionActual);
        }

    }
}
