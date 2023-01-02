using Persistence.Base;

namespace MongoDBPersistence.Repositories.Block;

public interface IBlockQueryRepository : IQueryRepository<Domain.Aggregates.Block.Block>
{

}