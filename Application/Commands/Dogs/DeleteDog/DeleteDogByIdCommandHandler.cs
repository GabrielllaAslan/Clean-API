using Application.Commands.Dogs.Deletedog.Application.Commands.Dogs.DeleteDog;
using Domain.Models;
using Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Dogs.Deletedog
{
    public class DeleteDogByIdCommandHandler : IRequestHandler<DeleteDogByIdCommand, Dog>
    {
        private readonly MockDatabase _mockDatabase;

        public DeleteDogByIdCommandHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }
        public Task<Dog> Handle(DeleteDogByIdCommand request, CancellationToken cancellationToken)
        {
            Dog dogToDelete = _mockDatabase.Dogs.Where(dog => dog.Id == request.Id).FirstOrDefault()!;

            if (dogToDelete == null)
            {
                return Task.FromResult<Dog>(null!);
            }

            _mockDatabase.Dogs.Remove(dogToDelete);

            return Task.FromResult(dogToDelete);
        }
    }
}
