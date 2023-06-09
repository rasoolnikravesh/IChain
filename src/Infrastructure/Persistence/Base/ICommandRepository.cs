using Domain.SeedWork;
using FluentResults;

namespace Persistence.Base;

public interface ICommandRepository<in TEntity> : IRepository where TEntity : IAggregateRoot
{

	Task<Result> AddAsync(TEntity entity, CancellationToken cancellationToken);

	Task<Result> AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken);

	Task<Result> UpdateAsync(TEntity entity, CancellationToken cancellationToken);

	Task<Result> UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken);

	Task<Result> RemoveAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken));

	Task<Result> RemoveRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken));
	 
	Task<Result> RemoveByIdAsync(Guid id, CancellationToken cancellationToken = default(CancellationToken));

}