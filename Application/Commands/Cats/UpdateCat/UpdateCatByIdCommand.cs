using Application.Dtos;
using Domain.Models;
using MediatR;

namespace Application.Commands.Cats.UpdateCat
{
    public class UpdateCatByIdCommand : IRequest<Cat>
    {
        public UpdateCatByIdCommand(CatDto catToUpdate, Guid id)
        {
            CatToUpdate = catToUpdate;
            Id = id;
        }

        public CatDto CatToUpdate { get; }
        public Guid Id { get; }
    }
}