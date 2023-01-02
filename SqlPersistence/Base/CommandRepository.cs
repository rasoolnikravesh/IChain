using Domain.SeedWork;
using FluentResults;
using Persistence.Base;

namespace SqlPersistence.Base;

public class CommandRepository<Tentity>:ICommandRepository<Tentity> where Tentity : IAggregateRoot
{
	public Task<Result> AddAsync(Tentity Entity, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}

	public Task<Result> AddRangeAsync(IEnumerable<Tentity> Entities, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}

	public Task<Result> UpdateAsync(Tentity Entity, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}

	public Task<Result> UpdateRangeAsync(IEnumerable<Tentity> Entities, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}

	public Task<Result> RemoveAsync(Tentity Entity, CancellationToken cancellationToken = default(CancellationToken))
	{
		throw new NotImplementedException();
	}

	public Task<Result> RemoveRangeAsync(IEnumerable<Tentity> Entities, CancellationToken cancellationToken = default(CancellationToken))
	{
		throw new NotImplementedException();
	}

	public Task<Result> RemoveByIdAsync(Guid id, CancellationToken cancellationToken = default(CancellationToken))
	{
		throw new NotImplementedException();
	}
}