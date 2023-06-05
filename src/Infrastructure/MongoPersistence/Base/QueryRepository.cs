using System.Linq.Expressions;
using Domain.SeedWork;
using MongoDB.Driver;
using Persistence.Base;

namespace MongoDBPersistence.Base;

public class QueryRepository<TEntity> : IQueryRepository<TEntity> where TEntity : IAggregateRoot
{
    public MongoContext Context { get; }

    public IMongoCollection<TEntity> Collection { get; }

    public QueryRepository(MongoContext context)
    {
        Context = context;
        Collection = context.Database.GetCollection<TEntity>(typeof(TEntity).Name);

    }
    public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var result = await Collection.FindAsync(FilterDefinition<TEntity>.Empty, default, cancellationToken);
        return await result.ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<TEntity>> GetSomeAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        var result = await Collection.FindAsync(predicate, default, cancellationToken);
        return await result.ToListAsync(cancellationToken);
    }

    public async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await Collection.FindAsync(x => x.Id == id, default, cancellationToken);
        return await result.SingleOrDefaultAsync(cancellationToken);
    }
}