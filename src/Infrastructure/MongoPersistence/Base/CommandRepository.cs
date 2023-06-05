using Domain.SeedWork;
using FluentResults;
using MongoDB.Driver;
using Persistence.Base;

namespace MongoDBPersistence.Base;

public class CommandRepository<TEntity> : ICommandRepository<TEntity> where TEntity : IAggregateRoot
{
	public MongoContext Context { get; }
	private IMongoCollection<TEntity> Collection { get; }

	public CommandRepository(MongoContext context)
	{
		Context = context;
		Collection = context.Database.GetCollection<TEntity>(typeof(TEntity).Name);
	}

	public async Task<Result> AddAsync(TEntity Entity, CancellationToken cancellationToken)
	{
		try
		{
			await Collection.InsertOneAsync(Entity, new InsertOneOptions(), cancellationToken);
			return Result.Ok();
		}
		catch (Exception e)
		{
			return Result.Fail(e.Message);
		}
	}

	public async Task<Result> AddRangeAsync(IEnumerable<TEntity> Entities, CancellationToken cancellationToken)
	{
		await Collection.InsertManyAsync(Entities, null, cancellationToken);
		return Result.Ok();
	}

	public async Task<Result> RemoveAsync(TEntity Entity, CancellationToken cancellationToken = default)
	{
		return await RemoveByIdAsync(Entity.Id, cancellationToken);
	}

	public async Task<Result> RemoveByIdAsync(Guid id, CancellationToken cancellationToken = default)
	{
		var result = await Collection.DeleteOneAsync(x => x.Id == id, cancellationToken: cancellationToken);
		return result.DeletedCount == 1 ? Result.Ok() : Result.Fail("");
	}

	public async Task<Result> RemoveRangeAsync(IEnumerable<TEntity> Entities, CancellationToken cancellationToken = default)
	{
		await Collection.DeleteManyAsync(x => Entities.Any(y => y.Id == x.Id), cancellationToken);
		return Result.Ok();
	}

	public async Task<Result> UpdateAsync(TEntity Entity, CancellationToken cancellationToken)
	{
		await Collection.FindOneAndReplaceAsync(x => x.Id == Entity.Id, Entity, null, cancellationToken);
		return Result.Ok();
	}

	public Task<Result> UpdateRangeAsync(IEnumerable<TEntity> Entities, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}
}