using Domain.Models;
using Infrastructure.Database;
using MediatR;

namespace Application.Queries.Cats.GetAll
{
    internal sealed class GetAllCatsQueryHandler : IRequestHandler<GetAllCatsQuery, List<Cat>>
    {
        private readonly MockDatabase _mockDatabase;

        public GetAllCatsQueryHandler(MockDatabase mockDatabase)
        {
            _mockDatabase = mockDatabase;
        }

        Task<List<Cat>> IRequestHandler<GetAllCatsQuery, List<Cat>>.Handle(GetAllCatsQuery request, CancellationToken cancellationToken)
        {
            List<Cat> allCatsFromMockDatabase = _mockDatabase.Cats;
            return Task.FromResult(allCatsFromMockDatabase);
        }
    }
}