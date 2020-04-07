using System;
using SimpleZoo.Animals;
using SimpleZoo.Zoo;
using Xunit;

namespace SimpleZooTests
{
    public class ZooTests
    {
        public Zoo Zoo { get; set; }

        public ZooTests()
        {
            Zoo = new Zoo();
        }

        [Fact]
        public void Zoo_WhenNotLoadDefaultZoo_Return_0Animals()
        {
            // Asset
            int expectedAnimalsNumber = 0;

            // Act
            int actualAnimalsNumber = Zoo.GetNumberOfAnimals();

            // Assert
            Assert.Equal(expectedAnimalsNumber, actualAnimalsNumber);
        }

        [Fact]
        public void Zoo_WhenLoadDefaultZoo_Return_13Animals()
        {
            // Asset
            int expectedDefaultAnimalsNumber = 13;

            // Act
            Zoo.LoadDefaultAnimalList();
            int actualAnimalsNumber = Zoo.GetNumberOfAnimals();

            // Assert
            Assert.Equal(expectedDefaultAnimalsNumber, actualAnimalsNumber);
        }

        [Fact]
        public void Zoo_WhenAddMamalAnimalIsOk_Increase_AnimalsNumberBy1()
        {
            // Asset
            Antelope antelope = new Antelope(name: "ant", age: 4, health: 100, Guid.NewGuid());
            int startNumber = Zoo.GetNumberOfAnimals();

            // Act
            Zoo.AddAnimal(antelope);
            int newNumber = Zoo.GetNumberOfAnimals();

            // Assert
            Assert.Equal(startNumber + 1, newNumber);
        }

        [Fact]
        public void Zoo_WhenRemoveMamalAnimalIsOk_Decrease_AnimalsNumberBy1()
        {
            // Asset
            Zoo.LoadDefaultAnimalList();

            var antelope = Zoo.GetAnimal(index: 1);
            int startNumber = Zoo.GetNumberOfAnimals();

            // Act
            Zoo.RemoveAnimal(antelope);
            int newNumber = Zoo.GetNumberOfAnimals();

            // Assert
            Assert.Equal(startNumber - 1, newNumber);
        }

        [Fact]
        public void Zoo_WhenTryToRemoveAnimalFromEmptyZoo_Return_Exception()
        {
            // Asset
            Antelope antelope = new Antelope(name: "ant", age: 4, health: 100, Guid.NewGuid());
            bool isException = false;

            // Act
            try
            {
                Zoo.RemoveAnimal(antelope);
            }
            catch
            {
                isException = true;
            }

            // Assert
            Assert.True(isException);
        }

        [Fact]
        public void Zoo_WhenTryToRemoveNonexistingAnimalFromZoo_Return_Exception()
        {
            // Asset
            Zoo.LoadDefaultAnimalList();
            Antelope antelope = new Antelope(name: "ant", age: 4, health: 100, Guid.NewGuid());
            bool isException = false;

            // Act
            try
            {
                Zoo.RemoveAnimal(antelope);
            }
            catch
            {
                isException = true;
            }

            // Assert
            Assert.True(isException);
        }
    }
}
