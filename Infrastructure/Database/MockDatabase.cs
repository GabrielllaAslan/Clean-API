using Domain.Models;

namespace Infrastructure.Database
{
    public class MockDatabase
    {
        public List<Dog> Dogs
        {
            get { return allDogs; }
            set { allDogs = value; }
        }

        private static List<Dog> allDogs = new()
        {
            new Dog { Id = Guid.NewGuid(), Name = "Björn"},
            new Dog { Id = Guid.NewGuid(), Name = "Patrik"},
            new Dog { Id = Guid.NewGuid(), Name = "Alfred"},
            new Dog { Id = new Guid("12345678-1234-5678-1234-567812345678"), Name = "TestDogForUnitTests"}
        };
        public List<Cat> Cats
        {
            get { return allCats; }
            set { allCats = value; }
        }

        private static List<Cat> allCats = new()
        {
            new Cat { Id = Guid.NewGuid(), Name = "Bella", LikesToPlay = true },
            new Cat { Id = Guid.NewGuid(), Name = "Fille", LikesToPlay = true},
            new Cat { Id = Guid.NewGuid(), Name = "Kalle", LikesToPlay = true},
            new Cat { Id = new Guid("12345678-1234-5678-1234-567812345610"), Name = "TestCatForUnitTests", LikesToPlay = true },
            new Cat { Id = new Guid("12345678-1234-5678-1234-567812345609"), Name = "AnotherTestCatForUnitTests", LikesToPlay = false }
        };
    }
}
