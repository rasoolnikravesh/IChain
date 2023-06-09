using Persistence.Mongo.Base;
using Persistence.Repositories.Block;

namespace Persistence.Mongo.Repositories.Block;

public class BlockQueryRepository : QueryRepository<Domain.Aggregates.Block.Block>,IBlockQueryRepository
{
	public BlockQueryRepository(MongoContext context) : base(context)
	{
	}
}