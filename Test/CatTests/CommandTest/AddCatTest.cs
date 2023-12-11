using Application.Commands.Cats.AddCat;
using Application.Dtos;
using Infrastructure.Database;

namespace Test.CatTests.CommandTest
{
    [TestFixture]
    public class AddCatTests
    {
        private AddCatCommandHandler _handler;
        private MockDatabase _mockDatabase;


        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _handler = new AddCatCommandHandler(_mockDatabase);
        }

        [Test]
        public async Task Handle_Add_Cat_To_MockDatabase()
        {
            //Arrange
            var catName = "Bella";

            var dto = new CatDto();

            dto.Name = catName;

            var command = new AddCatCommand(dto);

            //Act
            var result = await _handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.IsNotNull(result);
        }
    }
}