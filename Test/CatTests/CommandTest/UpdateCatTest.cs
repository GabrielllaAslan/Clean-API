﻿using Application.Commands.Cats.UpdateCat;
using Application.Dtos;
using Infrastructure.Database;

namespace Test.CatTests.CommandTest
{
    [TestFixture]
    public class UpdateCatTests
    {
        private UpdateCatByIdCommandHandler _handler;
        private MockDatabase _mockDatabase;

        [SetUp]
        public void SetUp()
        {
            // Initialize the handler and mock database before each test
            _mockDatabase = new MockDatabase();
            _handler = new UpdateCatByIdCommandHandler(_mockDatabase);
        }

        [Test]
        public async Task Handle_Update_Correct_Cat_By_Id()
        {
            //Arrange
            var catId = new Guid("12345678-1234-5678-1234-567812345601");

            var catName = "Ella";

            var dto = new CatDto();

            dto.Name = catName;

            dto.LikesToPlay = false;

            var command = new UpdateCatByIdCommand(dto, catId);

            //Act
            var result = await _handler.Handle(command, CancellationToken.None);

            //Assert
            Assert.That(result.Name, Is.EqualTo(catName));
            Assert.That(result.LikesToPlay, Is.False);
        }
    }
}