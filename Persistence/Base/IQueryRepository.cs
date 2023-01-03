using Domain.SeedWork;
using System.Linq.Expressions;

namespace Persistence.Base;

public interface IQueryRepository<Tentity> : IRepository where Tentity : IAggregateRoot
{
	Task<IEnumerable<Tentity>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken));

	Task<IEnumerable<Tentity>> GetSomeAsync(
		Expression<Func<Tentity, bool>> predicate,
		CancellationToken cancellationToken = default(CancellationToken));

	Task<Tentity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default(CancellationToken));
}

