using Domain.SeedWork;
using FluentResults;
using MongoDB.Driver;
using Persistence.Base;

namespace Persistence.Mongo.Base;

public class CommandRepository<TEntity> : ICommandRepository<TEntity> where TEntity : IAggregateRoot
{
	public MongoContext Context { get; }
	protected IMongoCollection<TEntity> Collection { get; private set; }

	public CommandRepository(MongoContext context)
	{
		Context = context;
		Collection = context.Database.GetCollection<TEntity>(typeof(TEntity).Name);
	}

	public async Task<Result> AddAsync(TEntity entity, CancellationToken cancellationToken)
	{
		try
		{
			await Collection.InsertOneAsync(entity, new InsertOneOptions(), cancellationToken);
			return Result.Ok();
		}
		catch (Exception e)
		{
			return Result.Fail(e.Message);
		}
	}

	public async Task<Result> AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
	{
		await Collection.InsertManyAsync(entities, null, cancellationToken);
		return Result.Ok();
	}

	public async Task<Result> RemoveAsync(TEntity entity, CancellationToken cancellationToken = default)
	{
		return await RemoveByIdAsync(entity.Id, cancellationToken);
	}

	public async Task<Result> RemoveByIdAsync(Guid id, CancellationToken cancellationToken = default)
	{
		DeleteResult? result = await Collection.DeleteOneAsync(x => x.Id == id, cancellationToken: cancellationToken);
		return result.DeletedCount == 1 ? Result.Ok() : Result.Fail("");
	}

	public async Task<Result> RemoveRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
	{
		await Collection.DeleteManyAsync(x => entities.Any(y => y.Id == x.Id), cancellationToken);
		return Result.Ok();
	}

	public async Task<Result> UpdateAsync(TEntity entity, CancellationToken cancellationToken)
	{
		await Collection.FindOneAndReplaceAsync(x => x.Id == entity.Id, entity, null, cancellationToken);
		return Result.Ok();
	}

	public Task<Result> UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
	{
		throw new NotImplementedException();
	}
}