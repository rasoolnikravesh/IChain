using Persistence.Base;

namespace MongoDBPersistence.Repositories.Block;

public interface IBlockCommandRepository : ICommandRepository<Domain.Aggregates.Block.Block>
{

}