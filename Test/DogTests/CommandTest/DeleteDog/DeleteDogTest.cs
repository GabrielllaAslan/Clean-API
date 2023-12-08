using Application.Commands.Dogs.Deletedog;
using Application.Commands.Dogs.Deletedog.Application.Commands.Dogs.DeleteDog;
using Application.Queries.Dogs.GetById;
using Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Test.DogTests.CommandTest.DeleteDog
{
    [TestFixture]
    public class DeleteDogTest
    {
        private  MockDatabase _database;
        private  DeleteDogByIdCommandHandler _command;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _database = new MockDatabase();
            _command = new DeleteDogByIdCommandHandler(_database);
        }
        [Test]
        public async Task IfIdIsOkThendeleteDog()
        {
            // Arrange
            Guid dogToDeleteId = new Guid("12345678-1234-5678-1234-567812345678");

            var deleteDogCommand = new DeleteDogByIdCommand(dogToDeleteId);
            // Act
            var result = await _command.Handle(deleteDogCommand, CancellationToken.None);
            // Assert
            Assert.That(result.Id, Is.EqualTo(dogToDeleteId));
        }
    }

    
}
