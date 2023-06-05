using MongoDBPersistence.Base;
using Persistence.Repositories.Block;

namespace MongoDBPersistence.Repositories.Block;

public class BlockQueryRepository : QueryRepository<Domain.Aggregates.Block.Block>,IBlockQueryRepository
{
	public BlockQueryRepository(MongoContext context) : base(context)
	{
	}
}