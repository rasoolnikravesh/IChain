using Domain.SeedWork;
using FluentResults;

namespace Persistence.Base;

public interface ICommandRepository<in TEntity> : IRepository where TEntity : IAggregateRoot
{

	Task<Result> AddAsync(TEntity Entity, CancellationToken cancellationToken);

	Task<Result> AddRangeAsync(IEnumerable<TEntity> Entities, CancellationToken cancellationToken);

	Task<Result> UpdateAsync(TEntity Entity, CancellationToken cancellationToken);

	Task<Result> UpdateRangeAsync(IEnumerable<TEntity> Entities, CancellationToken cancellationToken);

	Task<Result> RemoveAsync(TEntity Entity, CancellationToken cancellationToken = default(CancellationToken));

	Task<Result> RemoveRangeAsync(IEnumerable<TEntity> Entities, CancellationToken cancellationToken = default(CancellationToken));

	Task<Result> RemoveByIdAsync(Guid id, CancellationToken cancellationToken = default(CancellationToken));

}